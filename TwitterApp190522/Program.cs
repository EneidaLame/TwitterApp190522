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

            string filter1 = "C#";
            string filter2 = "Python";
            string filter3 = "javascript";
            string filter4 = "pascal";

            var userCredentials = new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            var userClient = new TwitterClient(userCredentials);


            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack("C#");
            stream.AddTrack("Python");
            stream.AddTrack("javascript");
            stream.AddTrack("pascal");

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

                if (tweetText.Contains(filter1))

                {
                    counter1++;
                }
                if (tweetText.Contains(filter2))
                {

                    counter2++;
                }
                if (tweetText.Contains(filter3))
                {
                    counter3++;
                }
                if (tweetText.Contains(filter4))
                {
                    counter4++;
                }
                Console.WriteLine(
                    filter1 + ":" + counter1 + ", " +
                    filter2 + ":" + counter2 + ", " +
                    filter3 + ":" + counter3 + ", " +
                    filter4 + ":" + counter4



                    );
                Console.WriteLine("----------------");

                if (howmanytweetssofar == 100)
                {
                    stream.Stop();
                    Console.WriteLine("Complete!");
                }

                howmanytweetssofar++;
            };

            await stream.StartMatchingAnyConditionAsync();
            }
        }
    }

