using System.Diagnostics.Metrics;

namespace wordle_mini_project_CondesnsedMilk;

class Program
{
    static void Main(string[] args)
    {
        bool done = false;

        CreateAnswer();
        
        while(!done)
        {
            InputAnswer(false);
        }
    }

    static void CheckAnswer(List<int> input, bool done)
    {
        var inputtedAnswer = input;
        var secretAnswer = input;
        int counter = 1;

        while(!done)
        {
            if(inputtedAnswer == secretAnswer)
            {
                Console.WriteLine(string.Join(", ", input));
                if (counter == 1)
                {
                    Console.WriteLine($"You got the answer in {counter} attempt!");
                }
                else
                {
                    Console.WriteLine($"You got the answer in {counter} attempts!");
                }
                done = true;
            }
            else
            {
                InputAnswer(true);
                counter++;
            }
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

        InputAnswer(false, secretAnswer);

        //Console.WriteLine(string.Join(", ", secretAnswer));
    }


    static void InputAnswer(bool retriedYet)
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
        }
        

        for (int i = 0; i < 4; i++)
        {
            input.Add(Convert.ToInt32(Console.ReadLine()));
        }

        CheckAnswer(input, false);
    }
}
