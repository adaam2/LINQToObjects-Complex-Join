using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice
{
    public class Entity<T> where T : Tweet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<T> tweets = new List<T>();
    }
}
