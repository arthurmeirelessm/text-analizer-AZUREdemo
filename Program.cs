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
        var test = Environment.GetEnvironmentVariable("ENDPOINT");
        Console.WriteLine(test);
    }
}