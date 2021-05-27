using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_2
{
    public class ForwardChain : SearchMethods
    {
        public ForwardChain(KnowledgeBase kb) : base(kb) { }


        public override bool solve(Clause query)
        {
            string outString;
            Stack<string> symbols = new Stack<string>();    // list for easy management
            List<string> Inferred = new List<string>();
            for (int i = kb.Size-1; i > 0; i--)
            {
                if (kb.Indexer(i).Proposition.Count == 0)
                    symbols.Push(kb.Indexer(i).Value);
                
            }
            while (symbols.Count != 0)
            {
                string p = symbols.Pop();
                if (p == query.Value)
                {
                    
                    outString = string.Join(" , ", Inferred.ToArray());
                    Console.Write("YES: ");
                    Console.Write(outString);
                    Console.Write("\n");
                    return true;

                }
                  
                if(!Inferred.Contains(p))
                {
                    Inferred.Add(p);
                    foreach(Clause c in kb.list)
                    {
                        if(c.Proposition.Contains(p) || c.Value == p)
                        {
                            c.Count--;
                            if (c.Count == 0)
                            { 
                                symbols.Push(c.Value);
                                if(c.Value == query.Value)
                                {
                                    Inferred.Add(c.Value);
                                    outString = string.Join(" , ", Inferred.ToArray());
                                    Console.Write("YES: ");
                                    Console.Write(outString);
                                    Console.Write("\n"); ;
                                    return true;
                                }

                            }
                            
                        }
                    }
                }
            }
            return false ;
        }
    }
}
