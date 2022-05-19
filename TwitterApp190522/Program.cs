using System;
using Tweetinvi;
using Tweetinvi.Models;

namespace TwitterApp190522
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var userCredentials = new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            var userClient = new TwitterClient(userCredentials);
        }
    }
}
