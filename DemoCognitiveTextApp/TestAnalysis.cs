using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.KeyPhrase;
using Microsoft.ProjectOxford.Text.Sentiment;
namespace DemoCognitiveTextApp
{
    public class TextAnalysis
    {
        static readonly string apiKey = ConfigurationManager.AppSettings["TextAPIKey"];
        public static async Task RunSentimentAnalysis(string language, string id, string input)
        {
            //Prepare document object
            var doc = new SentimentDocument()
            {
                Id = id,
                Text = input,
                Language = language
            };
            //get the client and request handler
            var sentimentClient = new SentimentClient(apiKey);
            var sentimentRequest = new SentimentRequest();
            //Add document to the request
            sentimentRequest.Documents.Add(doc);

            try
            {
                //call Azure service for sentiment analysis on given text
                var response = await sentimentClient.GetSentimentAsync(sentimentRequest);
                Console.WriteLine("**Sentiment Analysis Results** ");
                //get the response document
                foreach (var resdoc in response.Documents)
                {
                    Console.WriteLine();
                    Console.WriteLine("Sentiment Score: {0}", (resdoc.Score));
                    Console.WriteLine();
                    Console.WriteLine("Sentiment Score in Percentage: {0}", (resdoc.Score * 100));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}