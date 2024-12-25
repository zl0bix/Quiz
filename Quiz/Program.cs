using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuizProgram quizProgram = new QuizProgram();
            quizProgram.Quiz1();

            //Console.WriteLine((int)1 / (double)5);
        }
    }

    class Data
    {
        string[] Questions;
        string[] Answers;
        string[] IsCorrect;
        int Score;

        Data(string[] questions, string[] answers, string[] isCorrect, int score)
        {
            Questions = questions;
            Answers = answers;
            IsCorrect = isCorrect;
            Score = score;
        }
    }

    class QuizProgram
    {
        public void Quiz1()
        {
            string[] strQue = { "Сколько будет (int)1 / (double)5?", "Какая столица РФ?", "Какие из чисел натуральные?", 
                "Сколько будет num? i = 5; num = ++i + ++i(i и num типа данных integer)" +
                    "в ЯП C++"};
            string[] strAns1 = {"1", "0", "0.2", "0.1" };
            string[] strAns2 = {"Москва", "Питер", "Воронеж", "Берлин" };
            string[] strAns3 = {"-1", "0", "0.1", "1"};
            string[] strAns4 = {"10", "14", "12", "13"};

            string[] CorrectAns1 = { "0.2" };
            string[] CorrectAns2 = { "Москва" };
            string[] CorrectAns3 = { "1" };
            string[] CorrectAns4 = { "14" };
            List<string> YoursAns1 = new List<string>();
            List<string> YoursAns2 = new List<string>();
            List<string> YoursAns3 = new List<string>();
            List<string> YoursAns4 = new List<string>();
            

            string strPic = "";
            int index;
            //Data data = new Data();
            for(int i = 0; i < strQue.Length; i++)
            {
                Console.Clear();

                strPic = "";

                Console.WriteLine(strQue[i]);

                for (int j = 0; j < strAns1.Length; j++)
                {
                    Console.Write(strAns1[j] + "\t");
                }

                index = 0;

                while (strPic != "q")
                {
                    Console.Write("\nВведите ваш вариант или q для перехода к следующему вопросу -> ");

                    strPic = Console.ReadLine();

                    if(strPic != "q")
                    {
                        YoursAns1.Add(strPic);
                    }
                }

                for(int k = 0; k < strAns2.Length; k++)
                
                    Console.Write(strAns2[k] + "\t");

                while (strPic != "q")
                {
                    Console.Write("\nВведите ваш вариант или q для перехода к следующему вопросу -> ");

                    strPic = Console.ReadLine();

                    if (strPic != "q")
                    {
                        YoursAns2.Add(strPic);
                    }
                }

                for (int y = 0; y < strAns3.Length; y++)

                    Console.Write(strAns3[y] + "\t");

                while (strPic != "q")
                {
                    Console.Write("\nВведите ваш вариант или q для перехода к следующему вопросу -> ");

                    strPic = Console.ReadLine();

                    if (strPic != "q")
                    {
                        YoursAns3.Add(strPic);
                    }
                }

                for (int z = 0; z < strAns4.Length; z++)

                    Console.Write(strAns4[z] + "\t");

                while (strPic != "q")
                {
                    Console.Write("\nВведите ваш вариант или q для перехода к следующему вопросу -> ");

                    strPic = Console.ReadLine();

                    if (strPic != "q")
                    {
                        YoursAns4.Add(strPic);
                    }
                }

            }

        
            
        }



    }
}
