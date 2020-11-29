INSERT INTO dbo."QuestionsSets" ("Name","ExpectedAnswerTime") VALUES
	 ('OpenTriviaDB',15);

INSERT INTO dbo."Levels" ("Name","QuestionsSet_Id") VALUES
	 ('Easy',1),
	 ('Medium',1),
	 ('Hard',1);

INSERT INTO dbo."Users" ("Username","Password","Rol") VALUES
	 ('admin','admin',0);