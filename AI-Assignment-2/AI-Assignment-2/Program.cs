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
            Clause query = kB.Query;
            
           
            TruthTable test = new TruthTable(kB);
            ForwardChain fctest = new ForwardChain(kB);
            BackwardChain bctest = new BackwardChain(kB);
            if(test.solve(query) == true)
                Console.WriteLine("success");
            else
                Console.WriteLine("failure");
            if (fctest.solve(query) == true)
                Console.WriteLine("success");
            else
                Console.WriteLine("failure");
            if (bctest.solve(query) == true)
                Console.WriteLine("success");
            else
                Console.WriteLine("failure");
            Console.ReadLine();
        }
    }
}