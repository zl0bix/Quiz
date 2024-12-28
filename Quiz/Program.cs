using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuizProgram quizProgram = new QuizProgram();
            
            Registration registration = new Registration();

            string Choice = "";
            string name = "";
            string password = "";
            string LogOut = "exit";

            registration.SetList();

            Console.WriteLine("Нужна регистрация");

            while(!registration.IsUsed(name))
            {
                Console.Write("Введите Имя -> ");
                name = Console.ReadLine();
            }
            Console.Write("Введите пароль -> ");
            password = Console.ReadLine();
            registration.SavedData(name,password,0);
            registration.SetList();

            quizProgram.Quiz1();
            quizProgram.ShowYourAnswers();

            if (quizProgram.CheckTheResult())
            {
                Console.WriteLine("Ты молодей!!!");
            }
            else
            {
                Console.WriteLine("Ты nooby или я напортачил!!!");
            }

            //Console.WriteLine((int)1 / (double)5);
        }
    }

    class Data
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public int Score { get; private set; }

        public Data(string name, string password, int score)
        {
            Name = name;
            Password = password;
            Score = score;
        }     
    }

    class Registration
    {
        List<Data> _data = new List<Data>();

        string path = @"C:/txt/quiz.txt";

        public bool IsUsed(string str)
        {
            foreach(Data it in _data)
            {
                if(it.Name == str) 

                    return false;
            }

            return true;
        }

        public void ShowListData()
        {
            foreach(Data it in _data)
            {
                Console.WriteLine(it.Name + " " + it.Password + " " + it.Score);
            }
        }

        public void SetList() 
        {
            string strTmp = ReadFile();

            string[] arr = strTmp.Split('\n');
            string[] arrWords = new string[3];

            for(int i = 0; i < arr.Length - 1; i++)
            {
                arrWords = arr[i].Split(' ');

                _data.Add(new Data(arrWords[0] , arrWords[1] , Convert.ToInt32(arrWords[2])));
            }
        }

        public void SavedData(string name, string password, int num)
        {
            using(FileStream fs = new FileStream(path, FileMode.Append))
            {
                using(StreamWriter sr = new StreamWriter(fs))

                        sr.WriteLine(name + " " + password + " " + num);
            }
        }

        public string ReadFile()
        {
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }

    class QuizProgram
    {
        string[] strQue = { "Сколько будет (int)1 / (double)5?", "Какая столица РФ?", "Какие из чисел натуральные?",
                "Сколько будет num? i = 5; num = ++i + ++i(i и num типа данных integer)" +
                    "в ЯП C++"};
        string[] strAns = { "1, 0, 0.2, 0.1", "Москва, Питер, Воронеж, Берлин", "-1, 0, 0.1, 1", "10, 14, 12, 13" };


        List<string> CorrectAns = new List<string>() { "0.2", "Москва", "1", "14" };

        List<string> YoursAns = new List<string>();

        int Score;

        public void Quiz1()
        {                                 
            string strPic = "";                    
            for(int i = 0; i < strQue.Length; i++)
            {
                Console.Clear();

                strPic = "";

                Console.WriteLine(strQue[i]);

                Console.WriteLine(strAns[i]);
               
                while (strPic != "q".ToLower())
                {
                    Console.Write("\nВведите ваш вариант или q для перехода к следующему вопросу -> ");

                    strPic = Console.ReadLine();

                    if(strPic != "q")
                    {
                        YoursAns.Add(strPic);
                    }
                }                                                       
            }                   
        }

        public void ShowYourAnswers()
        {
            foreach(string it in YoursAns)
            {
                int num = 1;

                Console.WriteLine(" Ответ на " + num + " вопрос " + it);

                num++;
            }
        }

        public bool CheckTheResult()
        {
            Score = 0;

            if (YoursAns.Count == CorrectAns.Count)
            {
                for (int i = 0; i < YoursAns.Count; i++)
                {
                    if (YoursAns[i] == CorrectAns[i])
                    {
                        Score += 10;
                    }
                }
                if (Score == 40)

                    return true;

                else

                    return false;
            }
            else

                Console.WriteLine("Что-то не так...");

            return false;
        }

    }
}
