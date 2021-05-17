using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "test_HornKB.txt";

          

            KnowledgeBase kB = new KnowledgeBase(filepath);

           Console.ReadLine();
        }
    }
}