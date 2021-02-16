using System;
using System.Collections.Generic;

namespace simple_survey_example
{
    class Program
    {
        public static readonly string[] QUESTIONS = {
            "example question 1",
            "example question 2",
            "example question 3",
            "example question 4",
            "example question 5"
        };
        private static List<byte[]> responses = new List<byte[]>();
        static void Main(string[] _)
        {
            Console.WriteLine("Welcome to the simple survey program!");

            bool exit = false;
            while (!exit)
            {
                Console.Write("(R)eport, (Q)uestionnaire, (E)xit? ");
                string menu_response = Console.ReadLine();

                switch (menu_response.ToUpper())
                {
                    case "R":
                        ShowReport();
                        break;
                    case "Q":
                        ShowQuestionnaire();
                        break;
                    case "E":
                        exit = true;
                        break;
                    default:
                        throw new Exception("Invalid Command");
                }
            }
        }
        static void ShowReport()
        {
            Console.WriteLine("1\t|2\t|3\t|4\t|5\t|6\t|7\t|8\t|9\t|10\t|");
            for (int i = 0; i < QUESTIONS.Length; i++)
            {
                byte[] ratings_total = new byte[10];
                foreach (var ratings in responses)
                {
                    ratings_total[ratings[i] - 1] ++;
                }
                for (int j = 0; j < ratings_total.Length; j++)
                {
                    Console.Write("{0}\t|", ratings_total[j]);
                }
                Console.WriteLine();
            }
        }
        static void ShowQuestionnaire()
        {
            byte[] ratings = new byte[QUESTIONS.Length];
            Console.WriteLine("Rate these questions from 1-10 (1 being less important), press a key to continue");
            Console.ReadKey();
            for (int i = 0; i < QUESTIONS.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, QUESTIONS[i]);
                while (true)
                {
                    Console.Write("Enter rating 1-10: ");
                    string raw_rating = Console.ReadLine();
                    bool rating_valid = byte.TryParse(raw_rating, out byte rating);
                    if (rating_valid)
                    {
                        if (rating >= 1 && rating <= 10)
                        {
                            ratings[i] = rating;
                            break;
                        }
                    }
                    Console.WriteLine("Invalid Input!");
                }
            }
            responses.Add(ratings);
            Console.WriteLine("Thank you for your answers.");
        }
    }
}
