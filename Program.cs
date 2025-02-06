using System.Diagnostics.Metrics;
using System.Net.Security;

namespace wordle_mini_project_CondesnsedMilk;

class Program
{
    static void Main(string[] args)
    {
        int difficulty;

        Console.WriteLine("This is a spin off of wordle");
        Console.WriteLine("There are 4-8 numbers you need to guess depending on the difficulty. You have 5 attempts");
        difficulty = GetDifficulty();
        CreateAnswer(false, difficulty);

        while (true)
        {
            Console.Write("Would you like to play again? y/n: ");
            string playAgain = Console.ReadLine()!;
            Console.WriteLine();

            if(playAgain == "y")
            {
                difficulty = GetDifficulty();
                CreateAnswer(true, difficulty);
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
        }
    }

    static int GetDifficulty()
    {   
        while (true)
        {
            Console.Write("Choose a difficulty (Easy, Medium, Hard): ");
            string difficulty = Console.ReadLine()!.Trim().ToLower();

            switch (difficulty)
            {
                case "easy":
                    return 4;
                case "medium":
                    return 6;
                case "hard":
                    return 8;
                default:
                    Console.WriteLine("Invalid input. Please enter 'Easy', 'Medium', or 'Hard'.");
                    break;
            }
        }
    }

    static void CreateAnswer(bool playAgain, int numQuestions)
    {
        var rand = new Random();
        List<int> secretAnswer = new List<int>{};

        for (int i = 0; i < numQuestions; i++)
        {
            secretAnswer.Add(rand.Next(10)); // numQuestions amount that are less than 10 
        }

        if (!playAgain)
        {
            Console.WriteLine(string.Join(", ", secretAnswer)); // Writing the answer so debugging is easier
            InputAnswer(false, secretAnswer, 1, numQuestions); // Bool to see if I have done another attempt, list of the generated answer, int of the current number of attempts
        }
        else
        {
            Console.WriteLine(string.Join(", ", secretAnswer)); 
            InputAnswer(false, secretAnswer, 0, numQuestions); 
        }
    }

    static void InputAnswer(bool retriedYet, List<int> secretAnswer, int counter, int numQuestions)
    {
        List<int> input = new List<int>();

        if(retriedYet == true)
        {
            if(counter <= 5)
            {
                Console.WriteLine();
                Console.WriteLine("Try again!");
                counter++;
            }
            else
            {
                Console.WriteLine();
                Console.Write("Sorry! You ran out of attempts! Here was the answer: ");
                Console.Write(string.Join(", ", secretAnswer));
                Console.WriteLine();
                return;
            }
        }
        
        while (true) // To take inputs like "1 3 5 7" and put them into the list
        {
            Console.Write($"Enter your guess ({numQuestions} numbers separated by spaces): ");
            string userInput = Console.ReadLine()!;
            string[] inputs = userInput.Split();

            // Check if there are exactly a certain num elements and all are valid integers
            if (inputs.Length == numQuestions && inputs.All(s => int.TryParse(s, out _)))
            {
                input = inputs.Select(int.Parse).ToList();
                break;
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter exactly {numQuestions} numbers separated by spaces.");
            }
        }

        Hint(input, secretAnswer, counter, numQuestions);
    }

    static void Hint(List<int> userAnswer, List<int> secretAnswer, int counter, int numQuestions)
    {
        List<string> rightOrWrong = new List<string>();
        int rightCounter = 0;
        
        bool[] usedSecret = new bool[secretAnswer.Count]; // A bool array that tracks used numbers in the answer
        bool[] usedUser = new bool[userAnswer.Count]; // Tracks used numbers in the guess

        // Check for correct positions "O"
        for (int i = 0; i < secretAnswer.Count; i++)
        {
            if (userAnswer[i] == secretAnswer[i])
            {
                rightOrWrong.Add("O");
                rightCounter++;
                usedSecret[i] = true; // Mark this answer position as matched
                usedUser[i] = true; // Mark this guess position as matched
            }
            else
            {
                rightOrWrong.Add(""); // Placeholder for second check
            }
        }

        // Check for misplaced numbers "+"
        for (int i = 0; i < userAnswer.Count; i++)
        {
            if (!usedUser[i]) // Only check unmatched numbers
            {
                for (int j = 0; j < secretAnswer.Count; j++)
                {
                    if (!usedSecret[j] && userAnswer[i] == secretAnswer[j])
                    {
                        rightOrWrong[i] = "+"; // Replace placeholder
                        usedSecret[j] = true; // Mark this answer position as used
                        break;
                    }
                }
            }
        }

        // Replace remaining placeholders with "X"
        for (int i = 0; i < rightOrWrong.Count; i++)
        {
            if (rightOrWrong[i] == "")
            {
                rightOrWrong[i] = "X";
            }
        }

        CheckAnswer(secretAnswer, counter, numQuestions, rightCounter, rightOrWrong);
        
    }

    static void CheckAnswer(List<int> secretAnswer, int counter, int numQuestions, int rightCounter, List<string> rightOrWrong) // Are 5 parameters too much? Do I need to seperate the functions
    {// it's like i'm playing a game of hot potato with all this data being passed around. It makes the code hard to read

        if(rightCounter == secretAnswer.Count) // Tell number of attempts it takes
        {
            if (counter == 1) // Grammar
            {      
                Console.WriteLine();      
                Console.WriteLine(string.Join(", ", rightOrWrong));
                Console.WriteLine($"You got the answer in {counter} attempt!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(string.Join(", ", rightOrWrong));
                Console.WriteLine($"You got the answer in {counter} attempts!");
            }
        }
        else
        {
            Console.WriteLine(string.Join(", ", rightOrWrong));
            InputAnswer(true, secretAnswer, counter, numQuestions);
        }
    }
}
