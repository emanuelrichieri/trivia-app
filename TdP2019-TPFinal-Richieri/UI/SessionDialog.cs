using System;
using System.Linq;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri
{
    using System.Timers;
    using DTO;
    using Gtk;
    using UI;

    public partial class SessionDialog : Dialog
    {

        protected TriviaApp _triviaApp;
        protected QuestionDTO _question;
        protected IList<AnswerDTO> _answers;
        protected Timer _answerTimer;

        public SessionDialog(TriviaApp pTriviaApp)
        {
            this.Build();
            this._triviaApp = pTriviaApp;
            this.cbbAnswers.Model = new ListStore(typeof(string));
            this.SetAnswerLimitTimer();
            this.LoadNextQuestion();
        }

        protected void OnBtnAnswerClicked(object sender, EventArgs e)
        {
            this.Answer();
        }

        protected void Answer()
        {
            this._answerTimer.Stop();
            this._answerTimer.Dispose();

            var answers = new List<AnswerDTO>();
            if (cbbAnswers.Active >= 0)
            {
                answers.Add(_answers.ElementAt(cbbAnswers.Active));
            }
            var response = this._triviaApp.AddAnswer(_question, answers);
            if (response.Success)
            {
                var answerResult = response.Data;
                if (answerResult.IsCorrect)
                {
                    ModalMessage.Info(this, response.Message);
                }
                else
                {
                    ModalMessage.Error(this, $"{response.Message}. Correct Answer: {response.Data.GetCorrectAnswers()}");
                }
                new SessionDialog(_triviaApp).Show();
                this.Hide();
            }
            else
            {
                ModalMessage.Error(this, response.Message);
            }
        }

        protected void OnBtnCloseClicked(object sender, EventArgs e)
        {
            MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Question,
                ButtonsType.YesNo, "Are you sure to quit?");
            ResponseType response = (ResponseType) md.Run();
            if (response == ResponseType.Yes)
            {
                this.Hide();
            }
            else
            {
                md.Hide();
            }
            md.Destroy();

        }

        protected void LoadNextQuestion()
        {
            var nextQuestionResponse = _triviaApp.NextQuestion();
            if (nextQuestionResponse.Success)
            {
                _question = nextQuestionResponse.Data;
                this.entryQuestion.Text = _question.Question;

                _answers = _question.GetAnswers();
                foreach (AnswerDTO answer in _answers)
                {
                    this.cbbAnswers.AppendText(answer.Answer);
                }
            }
            else
            {
                if (ResponseCode.NoContent == nextQuestionResponse.Code)
                {
                    var sessionResultResponse = this._triviaApp.FinishSession();
                    if (sessionResultResponse.Success)
                    {
                        ModalMessage.Info(this, sessionResultResponse.Message);
                    }
                    else
                    {
                        ModalMessage.Error(this, sessionResultResponse.Message);
                    }
                }
                this._answerTimer.Stop();
                this._answerTimer.Dispose();
                this.Hide();
            }
        }

        private void SetAnswerLimitTimer()
        {
            this._answerTimer = new Timer(_triviaApp.SelectedQuestionsSet.ExpectedAnswerTime * 1000.0)
            {
                AutoReset = false
            };
            _answerTimer.Elapsed += (sender, e) =>
            {
                Application.Invoke(delegate
                {
                    this.Answer();
                });
            };
            _answerTimer.Enabled = true;
        }
    }
}
