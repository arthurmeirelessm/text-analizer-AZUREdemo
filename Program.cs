using Azure;
using Azure.AI.TextAnalytics;
using DotNetEnv;
using System.Xml.Schema;

public class Program
{
    private static readonly AzureKeyCredential keyCredential = new AzureKeyCredential(Environment.GetEnvironmentVariable("KEYCREDENTIAL"));
    private static readonly Uri endpoint = new Uri(Environment.GetEnvironmentVariable("ENDPOINT"));

    static void Main(string[] args)
    {
        DotNetEnv.Env.Load();

        var client = new TextAnalyticsClient(endpoint, keyCredential);

        SentimentAnalysisExample(client);
    }


    static void SentimentAnalysisExample(TextAnalyticsClient client)
    {
        string input = "dsggggsgdfffdfgssfdsdfsfsfdsffsfdfffsdfs";
        DocumentSentiment documentSentiment = client.AnalyzeSentiment(input);
        Console.WriteLine(documentSentiment.Sentiment);

        foreach (var sentence in documentSentiment.Sentences)
        {
            Console.WriteLine($"\tText: \"{sentence.Text}\"");
            Console.WriteLine($"\tSentence sentiment: \"{sentence.Sentiment}");
            Console.WriteLine($"\tPositive score: \"{sentence.ConfidenceScores.Positive:0.00}");
            Console.WriteLine($"\tNegative score: \"{sentence.ConfidenceScores.Negative:0.00}");
            Console.WriteLine($"\tNeutral score: \"{sentence.ConfidenceScores.Neutral:0.00}\n");
        }
    }

}