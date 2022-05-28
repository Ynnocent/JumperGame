using System;

namespace Jumpergame
{
    public class Program {
        static void Main() {
            Word x = new Word();
            // Console.WriteLine(x.selectedWords);
            Validator y = new Validator();
            Player z = new Player();
            Graphics w = new Graphics();

            Console.WriteLine(z.guessedWord);
            while(z.attempts > 0 && z.guessedWordstr != x.selectedWords) {
                w.Update(z);
                y.WordChecker(z,x);
            }
            if (z.attempts == 0) {
                w.Update(z);
                Console.WriteLine("You lost, try line");
            }
            else {
                w.Update(z);
                Console.WriteLine("You won! Congrats");
            }
        }
    }

    public class Player {
        public int attempts = 4;
        public char[] guessedWord = {'_','_','_','_','_','_','_','_'};
        public string guessedWordstr = "";
        public string guesssLetter = "";
        public string Guess() {
            Console.Write("Guess a letter: ");
            guesssLetter = Console.ReadLine()!.ToLower();
            return guesssLetter;
 
        }
    }

    public class Word {
        Random rnd = new Random();
        public string[] guessWords = {"absolute","epiphany","comprise","bacteria","yourself","unlikely","keyboard","volatile","symbolic","tangible"};

        public string selectedWords = "";
        public Word () {
            selectedWords = guessWords[rnd.Next(0,5)];
        }
    }

    public class Validator {
        public void WordChecker(Player player, Word word) {
            bool isCorrect = false; 
            player.Guess();
            for (int i = 0; i < 8; i++) {
                if (player.guesssLetter == word.selectedWords[i].ToString()) {
                    player.guessedWord[i] = word.selectedWords[i];
                    player.guessedWordstr = new string(player.guessedWord);
                    isCorrect = true;
                }
            }
            if (isCorrect == false) {
                player.attempts -=1;
            }
            else {
                isCorrect = false;
            }
            Console.WriteLine(player.guessedWord);
        }
    }

    public class Graphics {
         public void Update(Player player) {
            if(player.attempts == 4) {
                Console.WriteLine("  ___ \n /___\\\n \\   /\n  \\ /\n   O  \n  /|\\ \n  / \\\n\n^^^^^^^");
            }
            else if(player.attempts == 3) {
                Console.WriteLine("\n /___\\\n \\   /\n  \\ /\n   O  \n  /|\\ \n  / \\\n\n^^^^^^^");
            }
            else if(player.attempts == 2) {
                Console.WriteLine("\n \\   /\n  \\ /\n   O  \n  /|\\ \n  / \\\n\n^^^^^^^");
            }
            else if(player.attempts == 1) {
                Console.WriteLine("\n  \\ /\n   O  \n  /|\\ \n  / \\\n\n^^^^^^^");
            }
            else if(player.attempts == 0) {
                Console.WriteLine("\n   x  \n  /|\\ \n  / \\\n^^^^^^^");
            }
        }
    }

}