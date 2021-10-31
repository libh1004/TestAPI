using System;
using System.Collections.Generic;
using System.Text;

namespace TestAPI
{
    public class Todo
    {
        public int id { get; set; }
        public string  title { get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }
        public override string ToString()
        {
            return $"Id {id}, Title {title}, Completed {completed}, UserId {userId}";
        }
    }
}
