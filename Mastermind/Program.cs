using System;
namespace Mastermind
{
    class Program
    {
        //variables
        public static int[] number = new int[] {1,2,3,4,5,6}; // holds the allowed numbers 1-6
        public static int[] answer = new int[4]; //variable that holds the answer
        public static int attempts = 10; //variable to hold how many attempts the user gets
        public static int currentAttempts = 0; //variable to hold how many attempts have been made
        public static int[] guess = new int[4]; //variable that holds the user's guess
        const int size = 4; // variable containing the size of the answer array
        static void Main()
        {
            bool gameRun = true;
            
            Console.WriteLine("Welcome to Mastermind! You have ten attempts to solve the puzzle." +
                "\nA plus (+) under your number indicates it is the correct number in the correct position. " +
                "\nA minus (-) under your number indicates the number is correct but the position is wrong. " +
                "\nFind the secret 4-digit code to solve the game.");
            CreateRandomNumbers(); //initiates the create of the random number
            
            while (gameRun)
            {
                Console.WriteLine("\nPlease Enter Your Guess:");
                string response = Console.ReadLine(); //this holds the user's input
                for (int i = 0; i < guess.Length; i++) // this loop goes takes the user's input and parses it into integers to store in the guess[] array
                {
                    guess[i] = int.Parse(response.Substring(i, 1));
                }

               gameRun = !CheckAnswer(guess) && !CheckTotalAttempts(); // if user gets right guess/hit max attempts, gameRun becomes false and stops program
            }

        }

         //methods
        public static void CreateRandomNumbers() //This method creates the random 4-digit answer using digits 1-6
        {
            Random random = new Random();
            
            for (var i = 0; i < size ; i++)
            {
                answer[i] = number[random.Next(0, number.Length)];
            }
            
            return;
        }
        public static bool CheckAnswer(int[] guess) //This method checks if user guessed correctly and initiates the hint if not
        {
            string guessString = string.Join("", guess);
            string solutionString = string.Join("", answer);

            if (guessString == solutionString)
            {
                Console.WriteLine("You have guessed correctly.");
                return true;
            }
            else
            {
                Hint(guess, answer);
                return false;
            }
        }
        public static bool CheckTotalAttempts() //This method checks if the user has run out of attempts
        {
            if (currentAttempts <= attempts) {
                return false;
            }
            else
            {
                Console.WriteLine("\nYou have run out of attempts!");
                return true;
            }
        }
   
        public static void Hint(int[] guess, int[] answer) //This method assigns the + or - according to the user's answer
        {
            for (var i = 0; i < guess.Length; i++)
            {
              
                if (guess[i] == answer[i])
                {
                    Console.Write("+");
                }
                else if (answer.Contains(guess[i])) {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(" ");
                }
                
            }
            currentAttempts++;
        }


    }
}

    
