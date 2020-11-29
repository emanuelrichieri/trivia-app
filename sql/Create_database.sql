--
-- PostgreSQL database dump
--

-- Dumped from database version 12.5 (Ubuntu 12.5-0ubuntu0.20.04.1)
-- Dumped by pg_dump version 12.5 (Ubuntu 12.5-0ubuntu0.20.04.1)

-- Started on 2020-11-29 15:40:14 -03

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3094 (class 1262 OID 35116)
-- Name: trivia-app; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "trivia-app" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.UTF-8' LC_CTYPE = 'en_US.UTF-8';


ALTER DATABASE "trivia-app" OWNER TO postgres;

\connect -reuse-previous=on "dbname='trivia-app'"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 6 (class 2615 OID 35117)
-- Name: dbo; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA dbo;


ALTER SCHEMA dbo OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 204 (class 1259 OID 35120)
-- Name: Answers; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."Answers" (
    "Id" integer NOT NULL,
    "Description" text,
    "IsCorrect" boolean NOT NULL,
    "Question_Id" integer
);


ALTER TABLE dbo."Answers" OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 35118)
-- Name: Answers_Id_seq; Type: SEQUENCE; Schema: dbo; Owner: postgres
--

CREATE SEQUENCE dbo."Answers_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE dbo."Answers_Id_seq" OWNER TO postgres;

--
-- TOC entry 3095 (class 0 OID 0)
-- Dependencies: 203
-- Name: Answers_Id_seq; Type: SEQUENCE OWNED BY; Schema: dbo; Owner: postgres
--

ALTER SEQUENCE dbo."Answers_Id_seq" OWNED BY dbo."Answers"."Id";


--
-- TOC entry 206 (class 1259 OID 35137)
-- Name: Categories; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."Categories" (
    "Id" integer NOT NULL,
    "Name" text,
    "QuestionsSet_Id" integer NOT NULL
);


ALTER TABLE dbo."Categories" OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 35158)
-- Name: Levels; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."Levels" (
    "Id" integer NOT NULL,
    "Name" text,
    "QuestionsSet_Id" integer
);


ALTER TABLE dbo."Levels" OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 35156)
-- Name: Levels_Id_seq; Type: SEQUENCE; Schema: dbo; Owner: postgres
--

CREATE SEQUENCE dbo."Levels_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE dbo."Levels_Id_seq" OWNER TO postgres;

--
-- TOC entry 3096 (class 0 OID 0)
-- Dependencies: 209
-- Name: Levels_Id_seq; Type: SEQUENCE OWNED BY; Schema: dbo; Owner: postgres
--

ALTER SEQUENCE dbo."Levels_Id_seq" OWNED BY dbo."Levels"."Id";


--
-- TOC entry 205 (class 1259 OID 35129)
-- Name: Questions; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."Questions" (
    "Id" integer NOT NULL,
    "Description" text,
    "Multiple" boolean NOT NULL,
    "Category_Id" integer,
    "Level_Id" integer
);


ALTER TABLE dbo."Questions" OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 35147)
-- Name: QuestionsSets; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."QuestionsSets" (
    "Id" integer NOT NULL,
    "Name" text,
    "ExpectedAnswerTime" integer NOT NULL
);


ALTER TABLE dbo."QuestionsSets" OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 35145)
-- Name: QuestionsSets_Id_seq; Type: SEQUENCE; Schema: dbo; Owner: postgres
--

CREATE SEQUENCE dbo."QuestionsSets_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE dbo."QuestionsSets_Id_seq" OWNER TO postgres;

--
-- TOC entry 3097 (class 0 OID 0)
-- Dependencies: 207
-- Name: QuestionsSets_Id_seq; Type: SEQUENCE OWNED BY; Schema: dbo; Owner: postgres
--

ALTER SEQUENCE dbo."QuestionsSets_Id_seq" OWNED BY dbo."QuestionsSets"."Id";


--
-- TOC entry 217 (class 1259 OID 35194)
-- Name: SessionAnswerAnswers; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."SessionAnswerAnswers" (
    "SessionAnswer_Id" integer NOT NULL,
    "Answer_Id" integer NOT NULL
);


ALTER TABLE dbo."SessionAnswerAnswers" OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 35169)
-- Name: SessionAnswers; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."SessionAnswers" (
    "Id" integer NOT NULL,
    "AnswerTime" integer NOT NULL,
    "Question_Id" integer,
    "Session_Id" integer
);


ALTER TABLE dbo."SessionAnswers" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 35167)
-- Name: SessionAnswers_Id_seq; Type: SEQUENCE; Schema: dbo; Owner: postgres
--

CREATE SEQUENCE dbo."SessionAnswers_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE dbo."SessionAnswers_Id_seq" OWNER TO postgres;

--
-- TOC entry 3098 (class 0 OID 0)
-- Dependencies: 211
-- Name: SessionAnswers_Id_seq; Type: SEQUENCE OWNED BY; Schema: dbo; Owner: postgres
--

ALTER SEQUENCE dbo."SessionAnswers_Id_seq" OWNED BY dbo."SessionAnswers"."Id";


--
-- TOC entry 218 (class 1259 OID 35199)
-- Name: SessionQuestions; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."SessionQuestions" (
    "Session_Id" integer NOT NULL,
    "Question_Id" integer NOT NULL
);


ALTER TABLE dbo."SessionQuestions" OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 35177)
-- Name: Sessions; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."Sessions" (
    "Id" integer NOT NULL,
    "Date" timestamp without time zone NOT NULL,
    "Score" double precision NOT NULL,
    "Category_Id" integer,
    "Level_Id" integer,
    "User_Id" integer
);


ALTER TABLE dbo."Sessions" OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 35175)
-- Name: Sessions_Id_seq; Type: SEQUENCE; Schema: dbo; Owner: postgres
--

CREATE SEQUENCE dbo."Sessions_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE dbo."Sessions_Id_seq" OWNER TO postgres;

--
-- TOC entry 3099 (class 0 OID 0)
-- Dependencies: 213
-- Name: Sessions_Id_seq; Type: SEQUENCE OWNED BY; Schema: dbo; Owner: postgres
--

ALTER SEQUENCE dbo."Sessions_Id_seq" OWNED BY dbo."Sessions"."Id";


--
-- TOC entry 216 (class 1259 OID 35185)
-- Name: Users; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."Users" (
    "Id" integer NOT NULL,
    "Username" text,
    "Password" text,
    "Rol" integer NOT NULL
);


ALTER TABLE dbo."Users" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 35183)
-- Name: Users_Id_seq; Type: SEQUENCE; Schema: dbo; Owner: postgres
--

CREATE SEQUENCE dbo."Users_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE dbo."Users_Id_seq" OWNER TO postgres;

--
-- TOC entry 3100 (class 0 OID 0)
-- Dependencies: 215
-- Name: Users_Id_seq; Type: SEQUENCE OWNED BY; Schema: dbo; Owner: postgres
--

ALTER SEQUENCE dbo."Users_Id_seq" OWNED BY dbo."Users"."Id";


--
-- TOC entry 219 (class 1259 OID 35288)
-- Name: __MigrationHistory; Type: TABLE; Schema: dbo; Owner: postgres
--

CREATE TABLE dbo."__MigrationHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ContextKey" character varying(300) NOT NULL,
    "Model" bytea NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE dbo."__MigrationHistory" OWNER TO postgres;

--
-- TOC entry 2890 (class 2604 OID 35123)
-- Name: Answers Id; Type: DEFAULT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Answers" ALTER COLUMN "Id" SET DEFAULT nextval('dbo."Answers_Id_seq"'::regclass);


--
-- TOC entry 2892 (class 2604 OID 35161)
-- Name: Levels Id; Type: DEFAULT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Levels" ALTER COLUMN "Id" SET DEFAULT nextval('dbo."Levels_Id_seq"'::regclass);


--
-- TOC entry 2891 (class 2604 OID 35150)
-- Name: QuestionsSets Id; Type: DEFAULT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."QuestionsSets" ALTER COLUMN "Id" SET DEFAULT nextval('dbo."QuestionsSets_Id_seq"'::regclass);


--
-- TOC entry 2893 (class 2604 OID 35172)
-- Name: SessionAnswers Id; Type: DEFAULT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionAnswers" ALTER COLUMN "Id" SET DEFAULT nextval('dbo."SessionAnswers_Id_seq"'::regclass);


--
-- TOC entry 2894 (class 2604 OID 35180)
-- Name: Sessions Id; Type: DEFAULT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Sessions" ALTER COLUMN "Id" SET DEFAULT nextval('dbo."Sessions_Id_seq"'::regclass);


--
-- TOC entry 2895 (class 2604 OID 35188)
-- Name: Users Id; Type: DEFAULT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Users" ALTER COLUMN "Id" SET DEFAULT nextval('dbo."Users_Id_seq"'::regclass);

--
-- TOC entry 2898 (class 2606 OID 35128)
-- Name: Answers PK_dbo.Answers; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Answers"
    ADD CONSTRAINT "PK_dbo.Answers" PRIMARY KEY ("Id");


--
-- TOC entry 2905 (class 2606 OID 35144)
-- Name: Categories PK_dbo.Categories; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Categories"
    ADD CONSTRAINT "PK_dbo.Categories" PRIMARY KEY ("Id");


--
-- TOC entry 2910 (class 2606 OID 35166)
-- Name: Levels PK_dbo.Levels; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Levels"
    ADD CONSTRAINT "PK_dbo.Levels" PRIMARY KEY ("Id");


--
-- TOC entry 2900 (class 2606 OID 35136)
-- Name: Questions PK_dbo.Questions; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Questions"
    ADD CONSTRAINT "PK_dbo.Questions" PRIMARY KEY ("Id");


--
-- TOC entry 2907 (class 2606 OID 35155)
-- Name: QuestionsSets PK_dbo.QuestionsSets; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."QuestionsSets"
    ADD CONSTRAINT "PK_dbo.QuestionsSets" PRIMARY KEY ("Id");


--
-- TOC entry 2923 (class 2606 OID 35198)
-- Name: SessionAnswerAnswers PK_dbo.SessionAnswerAnswers; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionAnswerAnswers"
    ADD CONSTRAINT "PK_dbo.SessionAnswerAnswers" PRIMARY KEY ("SessionAnswer_Id", "Answer_Id");


--
-- TOC entry 2912 (class 2606 OID 35174)
-- Name: SessionAnswers PK_dbo.SessionAnswers; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionAnswers"
    ADD CONSTRAINT "PK_dbo.SessionAnswers" PRIMARY KEY ("Id");


--
-- TOC entry 2927 (class 2606 OID 35203)
-- Name: SessionQuestions PK_dbo.SessionQuestions; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionQuestions"
    ADD CONSTRAINT "PK_dbo.SessionQuestions" PRIMARY KEY ("Session_Id", "Question_Id");


--
-- TOC entry 2916 (class 2606 OID 35182)
-- Name: Sessions PK_dbo.Sessions; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Sessions"
    ADD CONSTRAINT "PK_dbo.Sessions" PRIMARY KEY ("Id");


--
-- TOC entry 2921 (class 2606 OID 35193)
-- Name: Users PK_dbo.Users; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Users"
    ADD CONSTRAINT "PK_dbo.Users" PRIMARY KEY ("Id");


--
-- TOC entry 2931 (class 2606 OID 35295)
-- Name: __MigrationHistory PK_dbo.__MigrationHistory; Type: CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."__MigrationHistory"
    ADD CONSTRAINT "PK_dbo.__MigrationHistory" PRIMARY KEY ("MigrationId", "ContextKey");


--
-- TOC entry 2896 (class 1259 OID 35204)
-- Name: Answers_IX_Question_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "Answers_IX_Question_Id" ON dbo."Answers" USING btree ("Question_Id");


--
-- TOC entry 2903 (class 1259 OID 35207)
-- Name: Categories_IX_QuestionsSet_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "Categories_IX_QuestionsSet_Id" ON dbo."Categories" USING btree ("QuestionsSet_Id");


--
-- TOC entry 2908 (class 1259 OID 35208)
-- Name: Levels_IX_QuestionsSet_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "Levels_IX_QuestionsSet_Id" ON dbo."Levels" USING btree ("QuestionsSet_Id");


--
-- TOC entry 2901 (class 1259 OID 35205)
-- Name: Questions_IX_Category_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "Questions_IX_Category_Id" ON dbo."Questions" USING btree ("Category_Id");


--
-- TOC entry 2902 (class 1259 OID 35206)
-- Name: Questions_IX_Level_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "Questions_IX_Level_Id" ON dbo."Questions" USING btree ("Level_Id");


--
-- TOC entry 2924 (class 1259 OID 35215)
-- Name: SessionAnswerAnswers_IX_Answer_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "SessionAnswerAnswers_IX_Answer_Id" ON dbo."SessionAnswerAnswers" USING btree ("Answer_Id");


--
-- TOC entry 2925 (class 1259 OID 35214)
-- Name: SessionAnswerAnswers_IX_SessionAnswer_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "SessionAnswerAnswers_IX_SessionAnswer_Id" ON dbo."SessionAnswerAnswers" USING btree ("SessionAnswer_Id");


--
-- TOC entry 2913 (class 1259 OID 35209)
-- Name: SessionAnswers_IX_Question_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "SessionAnswers_IX_Question_Id" ON dbo."SessionAnswers" USING btree ("Question_Id");


--
-- TOC entry 2914 (class 1259 OID 35210)
-- Name: SessionAnswers_IX_Session_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "SessionAnswers_IX_Session_Id" ON dbo."SessionAnswers" USING btree ("Session_Id");


--
-- TOC entry 2928 (class 1259 OID 35217)
-- Name: SessionQuestions_IX_Question_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "SessionQuestions_IX_Question_Id" ON dbo."SessionQuestions" USING btree ("Question_Id");


--
-- TOC entry 2929 (class 1259 OID 35216)
-- Name: SessionQuestions_IX_Session_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "SessionQuestions_IX_Session_Id" ON dbo."SessionQuestions" USING btree ("Session_Id");


--
-- TOC entry 2917 (class 1259 OID 35211)
-- Name: Sessions_IX_Category_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "Sessions_IX_Category_Id" ON dbo."Sessions" USING btree ("Category_Id");


--
-- TOC entry 2918 (class 1259 OID 35212)
-- Name: Sessions_IX_Level_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "Sessions_IX_Level_Id" ON dbo."Sessions" USING btree ("Level_Id");


--
-- TOC entry 2919 (class 1259 OID 35213)
-- Name: Sessions_IX_User_Id; Type: INDEX; Schema: dbo; Owner: postgres
--

CREATE INDEX "Sessions_IX_User_Id" ON dbo."Sessions" USING btree ("User_Id");


--
-- TOC entry 2932 (class 2606 OID 35218)
-- Name: Answers FK_dbo.Answers_dbo.Questions_Question_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Answers"
    ADD CONSTRAINT "FK_dbo.Answers_dbo.Questions_Question_Id" FOREIGN KEY ("Question_Id") REFERENCES dbo."Questions"("Id");


--
-- TOC entry 2935 (class 2606 OID 35233)
-- Name: Categories FK_dbo.Categories_dbo.QuestionsSets_QuestionsSet_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Categories"
    ADD CONSTRAINT "FK_dbo.Categories_dbo.QuestionsSets_QuestionsSet_Id" FOREIGN KEY ("QuestionsSet_Id") REFERENCES dbo."QuestionsSets"("Id") ON DELETE CASCADE;


--
-- TOC entry 2936 (class 2606 OID 35238)
-- Name: Levels FK_dbo.Levels_dbo.QuestionsSets_QuestionsSet_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Levels"
    ADD CONSTRAINT "FK_dbo.Levels_dbo.QuestionsSets_QuestionsSet_Id" FOREIGN KEY ("QuestionsSet_Id") REFERENCES dbo."QuestionsSets"("Id");


--
-- TOC entry 2933 (class 2606 OID 35223)
-- Name: Questions FK_dbo.Questions_dbo.Categories_Category_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Questions"
    ADD CONSTRAINT "FK_dbo.Questions_dbo.Categories_Category_Id" FOREIGN KEY ("Category_Id") REFERENCES dbo."Categories"("Id");


--
-- TOC entry 2934 (class 2606 OID 35228)
-- Name: Questions FK_dbo.Questions_dbo.Levels_Level_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Questions"
    ADD CONSTRAINT "FK_dbo.Questions_dbo.Levels_Level_Id" FOREIGN KEY ("Level_Id") REFERENCES dbo."Levels"("Id");


--
-- TOC entry 2943 (class 2606 OID 35273)
-- Name: SessionAnswerAnswers FK_dbo.SessionAnswerAnswers_dbo.Answers_Answer_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionAnswerAnswers"
    ADD CONSTRAINT "FK_dbo.SessionAnswerAnswers_dbo.Answers_Answer_Id" FOREIGN KEY ("Answer_Id") REFERENCES dbo."Answers"("Id") ON DELETE CASCADE;


--
-- TOC entry 2942 (class 2606 OID 35268)
-- Name: SessionAnswerAnswers FK_dbo.SessionAnswerAnswers_dbo.SessionAnswers_SessionAnswer_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionAnswerAnswers"
    ADD CONSTRAINT "FK_dbo.SessionAnswerAnswers_dbo.SessionAnswers_SessionAnswer_Id" FOREIGN KEY ("SessionAnswer_Id") REFERENCES dbo."SessionAnswers"("Id") ON DELETE CASCADE;


--
-- TOC entry 2937 (class 2606 OID 35243)
-- Name: SessionAnswers FK_dbo.SessionAnswers_dbo.Questions_Question_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionAnswers"
    ADD CONSTRAINT "FK_dbo.SessionAnswers_dbo.Questions_Question_Id" FOREIGN KEY ("Question_Id") REFERENCES dbo."Questions"("Id");


--
-- TOC entry 2938 (class 2606 OID 35248)
-- Name: SessionAnswers FK_dbo.SessionAnswers_dbo.Sessions_Session_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionAnswers"
    ADD CONSTRAINT "FK_dbo.SessionAnswers_dbo.Sessions_Session_Id" FOREIGN KEY ("Session_Id") REFERENCES dbo."Sessions"("Id");


--
-- TOC entry 2945 (class 2606 OID 35283)
-- Name: SessionQuestions FK_dbo.SessionQuestions_dbo.Questions_Question_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionQuestions"
    ADD CONSTRAINT "FK_dbo.SessionQuestions_dbo.Questions_Question_Id" FOREIGN KEY ("Question_Id") REFERENCES dbo."Questions"("Id") ON DELETE CASCADE;


--
-- TOC entry 2944 (class 2606 OID 35278)
-- Name: SessionQuestions FK_dbo.SessionQuestions_dbo.Sessions_Session_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."SessionQuestions"
    ADD CONSTRAINT "FK_dbo.SessionQuestions_dbo.Sessions_Session_Id" FOREIGN KEY ("Session_Id") REFERENCES dbo."Sessions"("Id") ON DELETE CASCADE;


--
-- TOC entry 2939 (class 2606 OID 35253)
-- Name: Sessions FK_dbo.Sessions_dbo.Categories_Category_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Sessions"
    ADD CONSTRAINT "FK_dbo.Sessions_dbo.Categories_Category_Id" FOREIGN KEY ("Category_Id") REFERENCES dbo."Categories"("Id");


--
-- TOC entry 2940 (class 2606 OID 35258)
-- Name: Sessions FK_dbo.Sessions_dbo.Levels_Level_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Sessions"
    ADD CONSTRAINT "FK_dbo.Sessions_dbo.Levels_Level_Id" FOREIGN KEY ("Level_Id") REFERENCES dbo."Levels"("Id");


--
-- TOC entry 2941 (class 2606 OID 35263)
-- Name: Sessions FK_dbo.Sessions_dbo.Users_User_Id; Type: FK CONSTRAINT; Schema: dbo; Owner: postgres
--

ALTER TABLE ONLY dbo."Sessions"
    ADD CONSTRAINT "FK_dbo.Sessions_dbo.Users_User_Id" FOREIGN KEY ("User_Id") REFERENCES dbo."Users"("Id");


-- Completed on 2020-11-29 15:40:14 -03

--
-- PostgreSQL database dump complete
--

