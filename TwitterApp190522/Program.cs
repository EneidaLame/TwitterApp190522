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
            stream.AddTrack("Python");
            stream.AddTrack("javascript");

            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;

            int howmanytweetssofar = 0;

            stream.MatchingTweetReceived += async (sender, eventReceived) =>

            {



                ITweet tweet = eventReceived.Tweet;
                string tweetText = eventReceived.Tweet.FullText;
                int favoritecount = tweet.FavoriteCount;
                string tweetAuthorName = tweet.CreatedBy.Name;


                Console.WriteLine(tweetAuthorName, " " + " " + favoritecount);
                Console.WriteLine(tweetText);
                Console.WriteLine();
                Console.WriteLine();


                stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                Console.WriteLine(eventReceived.Tweet);
            };

                await stream.StartMatchingAnyConditionAsync();
            };
        }
    }
}
