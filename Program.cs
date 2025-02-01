using System.Diagnostics.Metrics;
using System.Net.Security;

namespace wordle_mini_project_CondesnsedMilk;

class Program
{
    static void Main(string[] args)
    {
        List<int> input = new List<int>();
        //bool done = false;

        CreateAnswer();
        
    }

    static void CheckAnswer(List<int> userAnswer, List<int> secretAnswer, bool done, int counter)
    {
        List<string> rightOrWrong = new List<string>();
        int rightCounter = 0;

        while(!done)
        {
            for (int i = 0; i < secretAnswer.Count; i++)
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

            if(rightCounter == secretAnswer.Count)
            {
                if (counter == 1)
                {            
                    Console.WriteLine(string.Join(", ", rightOrWrong));
                    Console.WriteLine($"You got the answer in {counter} attempt!");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", rightOrWrong));
                    Console.WriteLine($"You got the answer in {counter} attempts!");
                }
                
            }
            else
            {
                Console.WriteLine(string.Join(", ", rightOrWrong));
                InputAnswer(true, secretAnswer, counter);
            }

            done = true;
        }
        
    }

    static void CreateAnswer()
    {
        var rand = new Random();
        List<int> secretAnswer = new List<int>{};

        for (int i = 0; i < 4; i++)
        {
            secretAnswer.Add(rand.Next(10));
        }

        Console.WriteLine(string.Join(", ", secretAnswer));
        InputAnswer(false, secretAnswer, 1);

    }


    static void InputAnswer(bool retriedYet, List<int> secretAnswer, int counter)
    {
        List<int> input = new List<int>();

        if(retriedYet == false)
        {
            Console.WriteLine("This is a spin off of wordle");
            Console.WriteLine("There are 4 numbers you need to guess. Try inputting 4 numbers.");
        }
        else
        {
            Console.WriteLine("Try again!");
            counter++;
        }
        
        input = Console.ReadLine()!.Split().Select(int.Parse).ToList();

        CheckAnswer(input, secretAnswer, false, counter);
    }
}
