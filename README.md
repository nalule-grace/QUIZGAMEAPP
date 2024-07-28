Quiz Game Application
Overview
This Quiz Game Application is a Windows Forms application developed in C#. The game presents a series of multiple-choice questions to the user, each with an associated image. Users get immediate feedback on whether their answers are correct or wrong. The application tracks the user's score and provides a final percentage score at the end of the quiz.

Features
Multiple-choice questions with images.
Immediate feedback on answer selection.
Score tracking and final score presentation.
Questions with different weightings to reflect their importance.

Installation
Prerequisites
.NET SDK
Visual Studio Code
Visual Studio Code Extensions:
C#
.NET Core Test Explorer
NUnit (if using NUnit for tests)
Steps
Clone the repository:


Restore dependencies and build the solution:


Run the application:


Usage
Upon starting the application, users will be presented with a list of available quizzes to select which one to attempt.(Avengers is currently the only active quiz)
The quiz has a series of questions. Each question is accompanied by an image and multiple-choice answers. Users select an answer by clicking one of the buttons. Immediate feedback is provided for each answer. At the end of the quiz, the total score and percentage are displayed.