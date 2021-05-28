using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AI_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            if(args.Length < 2)
            {
                Console.WriteLine("Usage: iengine method filename"); // incorrect usage
            }
            string filepath = args[1];
            KnowledgeBase kB = new KnowledgeBase(filepath);
            // read from input
            string method = args[0];
            SearchMethods searchMethod = null;
             // create knowledge base
            Clause query = kB.Query; // assign query
            if(method == "TT" || method == "tt") // check for method
                searchMethod = new TruthTable(kB);
            else if(method == "FC" || method == "fc")
                searchMethod = new ForwardChain(kB);
            else if(method == "BC" || method == "bc")
                searchMethod = new BackwardChain(kB);
            else 
            {
                //incorrect method input, or not found
                Console.WriteLine("Method not found, available methods are: FC, TT, BC");
                System.Environment.Exit(1);
            }
            //
            if (searchMethod.Solve(query))
                Console.WriteLine("YES: " + searchMethod.Result);
          
        }
    }
}