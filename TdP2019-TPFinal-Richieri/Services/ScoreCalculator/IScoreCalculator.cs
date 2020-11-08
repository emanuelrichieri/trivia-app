using System;
namespace TdP2019TPFinalRichieri.Services.ScoreCalculator
{
    using Entities;

    public interface IScoreCalculator
    {
        double CalculateScore(Session pSession);
    }
}
