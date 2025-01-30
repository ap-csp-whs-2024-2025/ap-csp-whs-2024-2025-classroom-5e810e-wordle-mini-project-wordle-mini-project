using System.Diagnostics.Metrics;

namespace wordle_mini_project_CondesnsedMilk;

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        List<int> input = new List<int>();
        
        while(!done)
        {
            InputAnswer(input);
        }
    }

    static void CheckAnswer(List<int> input, bool done)
    {
        var inputtedAnswer = input;
        var secretAnswer = input;
        int counter = 0;

        while(!done)
        {
            if(inputtedAnswer == secretAnswer)
            {
                done = true;
                Console.WriteLine($"You got the answer in {counter} times!");
            }
            else
            {
                InputAnswer(input);
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

        CheckAnswer(secretAnswer, false);

        //Console.WriteLine(string.Join(", ", secretAnswer));
    }


    static void InputAnswer(List<int> input)
    {
        Console.WriteLine("This is a spin off of wordle");
        Console.WriteLine("There are 4 numbers you need to guess. Try inputting 4 numbers.");

        for (int i = 0; i < 4; i++)
        {
            input.Add(Convert.ToInt32(Console.ReadLine()));
        }

        CheckAnswer(input, false);
    }
}
