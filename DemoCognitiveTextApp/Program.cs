using System;
namespace DemoCognitiveTextApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask for input text
            Console.WriteLine("Provide the Text: ");
            string input = Console.ReadLine();
            //generate guid
            string id = Guid.NewGuid().ToString();
            //run the sentiment analysis for input value
            TextAnalysis.RunSentimentAnalysis("en", id, input).Wait();
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}