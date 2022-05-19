using System;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace TwitterApp190522
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var userCredentials = new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            var userClient = new TwitterClient(userCredentials);


            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack("C#");

            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                Console.WriteLine(eventReceived.Tweet);
            };

            await stream.StartMatchingAnyConditionAsync();
        }
    }
}
