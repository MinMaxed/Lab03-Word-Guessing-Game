using System;
using System.IO;

namespace Lab03WordGuessingGame
{
    class Program
    {
        static string path = "../../../WordGame.txt";


        static void Main(string[] args)
        {

            string[] starterWords = { "hug", "coffee", "raccoon", "nachos", "demi" };


            bool gameplay = true;
            while (gameplay)
            {

                GameMenu();

                Int32.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        {
                            Play();
                            break;
                        }

                    case 2:
                        {
                            AdminCommands();
                            break;
                        }

                    case 3:
                        {
                            gameplay = false;
                            Environment.Exit(0);
                            break;
                        }
                }
            }

        }

        static void GameMenu()
        {
            Console.WriteLine("Welcome to the Word Guess Game!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Play Game");
            Console.WriteLine("2) Admin");
            Console.WriteLine("3) Exit");
        }


        //this code takes in the array of words, and then writes them out. 
        static void CreateWords()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                try
                {
                    foreach (string word in words)
                    {
                        sw.WriteLine(word);
                    }
                }
                finally
                {
                    sw.Close();
                }

            }
        }

        //this code reads and displays the file
        static void ReadWords()
        {
            using (StreamReader read = File.OpenText(path))
            {
                string line = "";
                while ((line = read.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            try
            {
                string[] myText = File.ReadAllLines(path);

                foreach (string value in myText)
                {
                    Console.WriteLine(value);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read all lines");
            }

        }

        //this is allowing the user to add lines to the main file
        static void UpdateFile()
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("This is a test line");
            }
        }

        //this allows the user to delete the file. this is safe to have as the CreateFile method functionally saves a copy
        static void DestroyFile()
        {
            File.Delete(path);
        }

        static string[] GetWords()
        {
            string[] words;
            words = File.ReadAllLines(path);
            return words;
        }


        //initiate the game
        static void Play()
        {
            Random random = new Random();
            int randomWord = random.Next(0, GetWords().Length);

            string guesses = "";
            string gameWord = GetWords()[randomWord];
            string[] display = new string[gameWord.Length];

            for (int i = 0; i < display.Length; i++)
            {
                display[i] = " _ ";
            }

            foreach (string letter in display)
            {
                Console.Write(letter);
            }



            Console.WriteLine("Guess a letter");
            string userGuess = Console.ReadLine();
            userGuess = userGuess.ToLower();

            for (int i = 0; i < gameWord.Length; i++)
            {
                if (userGuess == gameWord[i])
                {
                    //gameWord[Array.IndexOf];
                    Console.WriteLine(i);
                }
            }
        }
    }



    //direct the user to the commands to CRUD the game words. 
    static void AdminCommands()
    {
        bool modifying = true;
        while (modifying)
        {
            Console.WriteLine("1. View Words");
            Console.WriteLine("2. Add Word");
            Console.WriteLine("3. Delete Word");
            Console.WriteLine("4. Return");

            Int32.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    foreach (string word in GetWords())
                    {
                        ReadWords();
                    }
                    break;

                case 2:
                    //CreateWords();
                    Console.Clear();
                    break;

                case 3:
                    DestroyFile();
                    break;

                case 4:
                    break;

            }

        }
    }

}

