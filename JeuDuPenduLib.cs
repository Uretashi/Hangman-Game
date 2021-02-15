using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    class JeuDuPenduLib
    {
        //Méthode de démarrage du jeu
        public static void Start()
        {
            while (true)
            {
                string word = RandWord();
                string starWord = InitStarWord(word);
                int initRound = 10;
                Console.WriteLine("Welcome to your nightmare ^o^");
                for (int i = 0; i < 10; i++, initRound--)
                {
                    Console.WriteLine("Il vous reste " + initRound + " tours");
                    Console.WriteLine(PenduSchema(i));
                    char userInput = GetCharacter();
                    if(TestIfInWord(userInput, word, ref starWord))
                    {
                        Console.WriteLine("La lettre '" + userInput + "' existe dans le mot !");
                        i--;
                        initRound++;
                    }
                    else
                    {
                        Console.WriteLine("La lettre '" + userInput + "' n\'existe pas dans le mot :/");
                    }

                    if (!starWord.Contains('*'))
                    {
                        Console.WriteLine("Bravo ! le mot était '" + word + "' ^^");
                        break;
                    }

                    if(i == 9)
                    {
                        Console.WriteLine(PenduSchema(10));
                        Console.WriteLine("Vous avez perdu, le mot était '" + word + "' :/");
                    }

                    Console.WriteLine(starWord);
                }

                bool replay = Replay();
                if (!replay)
                {
                    Environment.Exit(0);
                }
            }
        }
        //Obtention d'un chiffre aléatoire
        public static int GetRandNum(int min, int max)
        {
            //Appel de la classe Random
            Random random = new Random();

            //return du chiffre
            return random.Next(min, max);
        }
        //Renvoie un mot aléatoire
        public static string RandWord()
        {
            string[] wordList = {
                "un",
                "deux",
                "cinq",
                "rouge",
                "membre",
                "conseil",
                "donner",
                "reponse",
                "etat",
                "france",
                "son",
                "glock",
                "peu",
                "holy",
                "missile",
                "shit",
                "angel",
                "demon",
                "cool",
                "test"
            };

            return wordList[GetRandNum(0, wordList.Length)];
        }
        //Récupère l'entrée de l'utilisateur
        public static char GetCharacter()
        {
            while(true)
            {
                Console.Write("Veuillez choisir une lettre : ");
                string letter = Console.ReadLine();

                if(letter.Length == 1 && letter.Any(x => char.IsLetter(x)))
                {
                    return char.Parse(letter);
                }
                else if(letter.Length > 1)
                {
                    Console.WriteLine("Veuillez définir une seule lettre :)");
                }
                else if(letter.Any(x => !char.IsLetter(x)))
                {
                    Console.WriteLine("Veuillez choisir une lettre !!");
                }
            }
        }
        public static string InitStarWord(string word)
        {
            return new String('*', word.Length);
        }
        public static bool TestIfInWord(char letter, string word, ref string starWord)
        {
            bool found = false;
            StringBuilder findChar = new StringBuilder(starWord);

            for(int i = 0; i < word.Length; i++)
            {
                if(word[i] == letter)
                {
                    findChar[i] = letter;
                    found = true;
                }
            }

            starWord = findChar.ToString();

            return found;
        }
        public static string PenduSchema(int index)
        {
            List<string> pendu = new List<string>();
            pendu.Add("");

            pendu.Add(String.Join(
                Environment.NewLine,
                "           ",
                "           ",
                "           ",
                "           ",
                " ___     \n"
                ));

            pendu.Add(String.Join(
                Environment.NewLine,
                 "           ",
                 "  |        ",
                 "  |        ",
                 "  |        ",
                 " ___     \n"
                 ));

            pendu.Add(String.Join(
                Environment.NewLine,
                "  _ _ _ _  ",
                "  |        ",
                "  |        ",
                "  |        ",
                " _|_     \n"
                ));

            pendu.Add(String.Join(
                Environment.NewLine,
                "  _ _ _ _  ",
                "  |     |  ",
                "  |        ",
                "  |        ",
                " _|_     \n"
                ));

            pendu.Add(String.Join(
                Environment.NewLine,
                "  _ _ _ _  ",
                "  |     |  ",
                "  |     O  ",
                "  |        ",
                " _|_     \n"
                ));

            pendu.Add(String.Join(
                Environment.NewLine,
                "  _ _ _ _  ",
                "  |     |  ",
                "  |     O  ",
                "  |     |  ",
                " _|_     \n"
                ));

            pendu.Add(String.Join(
                Environment.NewLine,
                "  _ _ _ _  ",
                "  |     |  ",
                "  |     O  ",
                "  |    /|  ",
                " _|_     \n"
                ));

            pendu.Add(String.Join(
                Environment.NewLine,
                "  _ _ _ _  ",
                "  |     |  ",
                "  |     O  ",
                "  |    /|\\",
                " _|_     \n"
                ));

            pendu.Add(String.Join(
                Environment.NewLine,
                "  _ _ _ _  ",
                "  |     |  ",
                "  |     O  ",
                "  |    /|\\",
                " _|_   / \n"
                ));

            pendu.Add(String.Join(
                Environment.NewLine,
                "  _ _ _ _  ",
                "  |     |  ",
                "  |     O  ",
                "  |    /|\\",
                " _|_   / \\\n"
                ));

            return pendu[index];
        }
        public static bool Replay()
        {
            while (true)
            {
                Console.Write("Voulez vous rejouer ? (y / n) : ");
                string replay = Console.ReadLine();
                if (replay.ToLower().Equals("y"))
                {
                    return true;
                }
                else if (replay.ToLower().Equals("n")) {
                    return false;
                }
            }
        }
    }
}
