namespace wordle_mini_project_CondesnsedMilk;

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        List<int> input = new List<int>();

        Console.WriteLine("This is a spin off of wordle");
        
        while(!done)
        {
            Console.WriteLine("There are 4 numbers you need to guess. n/ Try inputting 4 numbers.");

            for (int i = 0; i < 4; i++)
            {
                input.Append(Convert.ToInt32(Console.ReadLine()));
            }
            
            done = true;
        }

        Display(input);
        
    }

    static void Display(List<int> input)
    {
        for (int i=0; i < input.Count; i++)
            {
                Console.WriteLine("test");
                Console.WriteLine(input[i]);
            }
    }

    static void Answer()
    {
        List<int> answer = new List<int>{1,2,3,4};
    }
}
