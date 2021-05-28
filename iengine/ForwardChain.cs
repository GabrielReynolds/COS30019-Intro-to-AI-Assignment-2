using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_2
{
    public class ForwardChain : SearchMethods
    {
        private string _outString;
        public ForwardChain(KnowledgeBase kb) : base(kb)
        {
            _outString = "";
        }


        public override bool Solve(Clause query)
        {

            Stack<string> symbols = new Stack<string>();    // list for easy management
            List<string> Inferred = new List<string>();
            for (int i = Kb.Size - 1; i > 0; i--)
            {
                if (Kb.Indexer(i).Proposition.Count == 0)
                    symbols.Push(Kb.Indexer(i).Value);

            }
            while (symbols.Count != 0)
            {
                string p = symbols.Pop();
                if (p == query.Value)
                {
                    _outString = string.Join(" , ", Inferred.ToArray());
                    return true;
                }

                if (!Inferred.Contains(p))
                {
                    Inferred.Add(p);
                    foreach (Clause c in Kb.List)
                    {
                        if (c.Proposition.Contains(p) || c.Value == p)
                        {
                            c.Count--;
                            if (c.Count == 0)
                            {
                                symbols.Push(c.Value);
                                if (c.Value == query.Value)
                                {
                                    Inferred.Add(c.Value);
                                    _outString = string.Join(" , ", Inferred.ToArray());
                                    return true;
                                }

                            }

                        }
                    }
                }
            }
            return false;
        }
        public override string Result
        {
            get
            {
                return _outString;
            }
        }
    }
}
       

