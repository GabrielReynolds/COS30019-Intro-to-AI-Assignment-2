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

            Stack<string> symbols = new Stack<string>();    // list for easy management
            List<string> Inferred = new List<string>();
            for (int i = 0; i < kb.Size; i++)
            {
                if (kb.Indexer(i).Proposition == null)
                    symbols.Push(kb.Indexer(i).Value);
                else
                {
                    foreach(string s in kb.Indexer(i).Proposition)
                    {
                        symbols.Push(s);
                    }
                   
                }
            }
            while (symbols.Count != 0)
            {
                string p = symbols.Pop();
                if (p == query.Value)
                    return true;
                if(!Inferred.Contains(p))
                {
                    Inferred.Add(p);
                    foreach(Clause c in kb.list)
                    {
                        if(c.Proposition.Contains(p))
                        {
                            c.Count--;
                            if (c.Count == 0)
                                symbols.Push(c.Value);
                        }
                    }
                }
            }
            return false ;
        }
    }
}
