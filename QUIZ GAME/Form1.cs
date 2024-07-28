using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QUIZ_GAME
{
    public partial class Form1 : Form
    {

        //quiz game variables

        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;

        public Form1()
        {
            InitializeComponent();

            askQuestion(questionNumber);

            totalQuestions = quizQuestions.Count;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// handles the event when answer button is clicked
        /// </summary>
        /// <param name="sender">source of event</param>
        /// <param name="e">event data</param>

        private void checkAnswerEvent(object sender, EventArgs e)
        {
            try
            {
                var senderObject = (Button)sender;

                int buttonTag = Convert.ToInt32(senderObject.Tag);

                if (buttonTag == correctAnswer)
                {
                    score += quizQuestions[questionNumber -1].Weight;
                    MessageBox.Show("correct!");
                }
                else if (buttonTag != correctAnswer)
                {
                    MessageBox.Show(
                        "Wrong choice"
                        );
                }

                if (questionNumber == totalQuestions)
                {
                    //score percentage


                   // percentage = (int)Math.Round((double)(score * 100) / totalQuestions * quizQuestions[0].Weight);
                   percentage =(int)Math.Round((double))(score/17) * 100;


                    MessageBox.Show(
                        "QUIZ ENDED!!!" + Environment.NewLine +
                        "You have answered " + score + " questions correctly" + Environment.NewLine +
                        "Your score is" + score + "/" + "17" + Environment.NewLine +
                        "Your total percentage is " + percentage + "%" + Environment.NewLine +
                        "click OK to play again"

                        );


                    score = 0;
                    questionNumber = 0;
                    // askQuestion(questionNumber);
                }

                questionNumber++;
                askQuestion(questionNumber);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }

        /// <summary>
        /// shows quiz questions
        /// </summary>
        public class QuizQuestion
        {
            public Image Image { get; set; }
            public string QuestionText { get; set; }
            public List<string> Answers { get; set; }
            public int correctAnswer { get; set; }
            public int Weight { get; set; }

        }

        //initializing question
        List<QuizQuestion> quizQuestions = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Image = Properties.Resources.quiz,
                QuestionText = "Which studio produces the Avengers?",
                Answers = new List<string> { "cartoon network", "DC", "Marvel", "ALU" },
                correctAnswer = 3,
                Weight = 2
            },
            new QuizQuestion
            {

                Image = Properties.Resources.ironman,
                QuestionText = "What is the name of the main character from IronMan?",
                Answers = new List<string> { "Bang olufsen", "Tony Stark", "The grinch", "Itachi" },
                correctAnswer = 2,
                Weight=1
            },
            new QuizQuestion
            {

                Image = Properties.Resources.avengers1,
                QuestionText = "How much do the avengers pay if they destroy your car?",
                Answers = new List<string> { "1 million", "2 infinity stones", "10$", "😂😂😂😂😂" },
                correctAnswer = 4,
                Weight = 2
            },
            new QuizQuestion
            {

                Image = Properties.Resources.spider_man,
                QuestionText = "Which city does spiderman protect from crime?",
                Answers = new List<string> { "kigali", "Queens", "Newyork", "Canon event" },
                correctAnswer = 2,
                Weight = 2
            },
            new QuizQuestion
            {

                Image = Properties.Resources.hulk,
                QuestionText = "What does the hulk do for a job?",
                Answers = new List<string> { "street dancer", "genetic researcher", "actor", "bio technology" },
                correctAnswer = 2,
                Weight = 3
            },
            new QuizQuestion
            {

                Image = Properties.Resources.thanos,
                QuestionText = "What did thanos believe in?",
                Answers = new List<string> { "world peace", "Jesus Christ", "Universal balance", "Almighty" },
                correctAnswer = 3,
                Weight = 2
            },
            new QuizQuestion
            {

                Image = Properties.Resources.captain_america,
                QuestionText = "What is another name for captain America?",
                Answers = new List<string> { "The goat", "cap", "captain man", "winter's soilder" },
                correctAnswer = 2,
                Weight = 1
            },
            new QuizQuestion
            {

                Image = Properties.Resources.avengers2,
                QuestionText = "Which avengers installation has this posterMan?",
                Answers = new List<string> { "infinity war", "Age of ultron", "endgame", "dawn of justice" },
                correctAnswer = 3,
                Weight = 1
            },
            new QuizQuestion
            {

                Image = Properties.Resources.quiz,
                QuestionText = "Which letter is outside of Avengers HQ?",
                Answers = new List<string> { "A", "B", "HQ", "M" },
                correctAnswer = 1,
                Weight = 1
            },
            new QuizQuestion
            {

                Image = Properties.Resources.quiz,
                QuestionText = "The avengers are...?",
                Answers = new List<string> { "Villains", "Antagonists", "Heroes", "Have no side" },
                correctAnswer = 3,
                Weight = 2
            }
        };

        /// <summary>
        /// Asks a question based on number
        /// </summary>
        /// <param name="qnum">The question number to ask</param>
        private void askQuestion(int qnum)
        {
            try
            {

                if (qnum < 1 || qnum > quizQuestions.Count)
                {
                    //ivalid question
                    return;
                }

                QuizQuestion question = quizQuestions[qnum - 1];

                pictureBox1.Image = question.Image;
                lblQuestion.Text = question.QuestionText;
                button1.Text = question.Answers[0];
                button2.Text = question.Answers[1];
                button3.Text = question.Answers[2];
                button4.Text = question.Answers[3];

                correctAnswer = question.correctAnswer;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error ocurred while asking the question: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }

        }
    }
    }

