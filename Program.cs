using System.Diagnostics.Metrics;
using System.Net.Security;

namespace wordle_mini_project_CondesnsedMilk;

class Program
{
    static void Main(string[] args)
    {
        List<int> input = new List<int>();

        CreateAnswer(false);
        while (true)
        {
            Console.Write("Would you like to play again? y/n: ");
            string playAgain = Console.ReadLine()!;

            if(playAgain == "y")
            {
                CreateAnswer(true);
            }
            else
            {
                break;
            }
        }

        // I have yet to implement if the user wants to play another game
    }

    static void CheckAnswer(List<int> userAnswer, List<int> secretAnswer, int counter) // Are 4 parameters too much? Do I need to seperate the functions
    {
        List<string> rightOrWrong = new List<string>();
        int rightCounter = 0;

        while(true)
        {
            for (int i = 0; i < secretAnswer.Count; i++) // Loop to see if each individual element is equal to the answer
            {
                if(userAnswer[i] == secretAnswer[i])
                {
                    rightOrWrong.Add("O");
                    rightCounter++;
                }
                else
                {
                    rightOrWrong.Add("X");
                }
            }

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
                InputAnswer(true, secretAnswer, counter);
            }
            break;
        }
    }

    static void CreateAnswer(bool playAgain)
    {
        var rand = new Random();
        List<int> secretAnswer = new List<int>{};

        for (int i = 0; i < 4; i++)
        {
            secretAnswer.Add(rand.Next(10)); // 4 Nums > 10 
        }

        if (!playAgain)
        {
            Console.WriteLine(string.Join(", ", secretAnswer)); // Writing the answer so debugging is easier
            InputAnswer(false, secretAnswer, 1); // Bool to see if I have done another attempt, list of the generated answer, int of the current number of attempts
        }
        else
        {
            Console.WriteLine(string.Join(", ", secretAnswer)); // Writing the answer so debugging is easier
            InputAnswer(true, secretAnswer, 0); // Bool to see if I have done another attempt, list of the generated answer, int of the current number of attempts
        }
    }


    static void InputAnswer(bool retriedYet, List<int> secretAnswer, int counter)
    {
        List<int> input = new List<int>();

        if(retriedYet == false)
        {
            Console.WriteLine("This is a spin off of wordle");
            Console.WriteLine("There are 4 numbers you need to guess. Try inputting 4 numbers. You have 10 attempts");
            Console.WriteLine();
        }
        else
        {
            if(counter <= 10)
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
                return;
            }
        }
        
        input = Console.ReadLine()!.Split().Select(int.Parse).ToList(); // To take inputs like "1 3 5 7" and put them into the list
        // I have yet to add checks if the input is correct

        CheckAnswer(input, secretAnswer, counter);
    }
}
