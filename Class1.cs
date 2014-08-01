using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            // Representative of static collection
            Tweet t1 = new Tweet()
            {
                Author = "Adam",
                CreatedTime = DateTime.Now,
                Text = "Hello this is a test tweet from Adam"
            };
            Tweet t2 = new Tweet()
            {
                Author = "Ellie",
                CreatedTime = DateTime.Now.Subtract(new TimeSpan(1, 0, 0)),
                Text = "Hello this is a test tweet from Ellie and Adam"
            };
            Tweet t3 = new Tweet()
            {
                Author = "Adam",
                CreatedTime = DateTime.Now,
                Text = "Hello this is a test tweet from John and Adam"
            };
            Entity<Tweet> adamEntity1 = new Entity<Tweet>();
            adamEntity1.tweets.Add(t1);
            adamEntity1.tweets.Add(t2);
            adamEntity1.tweets.Add(t3);

            Tweet t5 = new Tweet()
            {
                Author = "Bob",
                CreatedTime = DateTime.Now,
                Text = "Yes this is a tweet about Lindsay"
            };
            Tweet t6 = new Tweet()
            {
                Author = "Mellish",
                CreatedTime = DateTime.Now,
                Text = "Another tweet about Lindsay"
            };
            Entity<Tweet> lindsayEntity = new Entity<Tweet>();
            lindsayEntity.Name = "Lindsay";
            lindsayEntity.Type = "Person";
            lindsayEntity.tweets.Add(t5);
            lindsayEntity.tweets.Add(t6);

            adamEntity1.Name = "Adam";
            adamEntity1.Type = "Person";
            List<Entity<Tweet>> list1 = new List<Entity<Tweet>>();
            list1.Add(adamEntity1);
            list1.Add(lindsayEntity);

            // Representative of current tweet - may have multiple entities so therefore a list<T>
            Tweet t4 = new Tweet()
            {
                Author = "Ellie",
                CreatedTime = DateTime.Now.Subtract(new TimeSpan(1, 0, 0)),
                Text = "Hello this is a test from Ellie and Adam"
            };
            Entity<Tweet> adamEntity2 = new Entity<Tweet>();
            
            adamEntity2.Type = "Person";
            adamEntity2.Name = "Adam";
            adamEntity2.tweets.Add(t4);

            Tweet t7 = new Tweet()
            {
                Author = "Bob",
                CreatedTime = DateTime.Now,
                Text = "Yes this is a tweet about Lindsay and stuff"
            };
            Tweet t8 = new Tweet()
            {
                Author = "Mellish",
                CreatedTime = DateTime.Now,
                Text = "Another tweet djdjd about Lindsay"
            };
            Entity<Tweet> lindsayEntity2 = new Entity<Tweet>();
            lindsayEntity2.Name = "Lindsay";
            lindsayEntity2.Type = "Person";
            lindsayEntity2.tweets.Add(t7);
            lindsayEntity2.tweets.Add(t8);

            List<Entity<Tweet>> list2 = new List<Entity<Tweet>>();
            list2.Add(adamEntity2);
            list2.Add(lindsayEntity2);

            List<Entity<Tweet>> joined = Join(list1, list2);

            joined.ForEach(item =>
            {
                item.tweets.ForEach(tweet =>
                {
                    Console.WriteLine(item.Name + " tweet:" + tweet.Text);
                });
                //Console.WriteLine(item.Name);
            });

            Console.ReadKey();
        }
        public static List<Entity<Tweet>> Join(List<Entity<Tweet>> list1,List<Entity<Tweet>> list2)
        {
            return list1.Join(list2, item => item.Name, item => item.Name, (outer, inner) =>
            {
                outer.tweets.AddRange(inner.tweets);
                return outer;
            }).ToList();
        }
    }
}
