using NUnit.Framework;
using System;
using System.Collections.Generic;
using QUIZ_GAME;
//using System.Windows.Forms;

namespace QUIZ_GAME.Tests
{
    [TestFixture]
    public class Form1Tests
    {
        private Form1 form;

        [SetUp]
        public void SetUp()
        {
            form = new Form1Tests();
        }

        [Test]
        public void TestFormInitialization()
        {
            Assert.IsNotNull(form);
            Assert.AreEqual(1, form.questionNumber);
            Assert.AreEqual(0, form.score);
            Assert.AreEqual(10, form.totalQuestions); // Assuming you have 10 questions in the quiz
        }

        [Test]
        public void TestAskQuestion_ValidQuestionNumber()
        {
            form.askQuestion(1);

            Assert.AreEqual("Which studio produces the Avengers?", form.lblQuestion.Text);
            Assert.AreEqual("cartoon network", form.button1.Text);
            Assert.AreEqual("DC", form.button2.Text);
            Assert.AreEqual("Marvel", form.button3.Text);
            Assert.AreEqual("ALU", form.button4.Text);
            Assert.AreEqual(3, form.correctAnswer);
        }

        [Test]
        public void TestAskQuestion_InvalidQuestionNumber()
        {
            form.askQuestion(11); // Assuming you have only 10 questions, this should not set any question

            Assert.IsEmpty(form.lblQuestion.Text);
            Assert.IsEmpty(form.button1.Text);
            Assert.IsEmpty(form.button2.Text);
            Assert.IsEmpty(form.button3.Text);
            Assert.IsEmpty(form.button4.Text);
        }

        [Test]
        public void TestCheckAnswerEvent_CorrectAnswer()
        {
            form.askQuestion(1);

            // Simulate correct answer button click
            var button = new Button();
            button.Tag = form.correctAnswer.ToString();
            form.checkAnswerEvent(button, EventArgs.Empty);

            Assert.AreEqual(2, form.score); // Assuming the first question has a weight of 2
            Assert.AreEqual(2, form.questionNumber);
        }

        [Test]
        public void TestCheckAnswerEvent_WrongAnswer()
        {
            form.askQuestion(1);

            // Simulate wrong answer button click
            var button = new Button();
            button.Tag = "1"; // Assuming 1 is not the correct answer for the first question
            form.checkAnswerEvent(button, EventArgs.Empty);

            Assert.AreEqual(0, form.score); // Score should not increase
            Assert.AreEqual(2, form.questionNumber);
        }

        [Test]
        public void TestQuizEnd()
        {
            form.questionNumber = form.totalQuestions; // Simulate last question
            form.score = 15; // Simulate some score

            var button = new Button();
            button.Tag = form.correctAnswer.ToString();
            form.checkAnswerEvent(button, EventArgs.Empty);

            Assert.AreEqual(0, form.score); // Score should reset
            Assert.AreEqual(0, form.questionNumber); // Question number should reset
        }
    }
}
