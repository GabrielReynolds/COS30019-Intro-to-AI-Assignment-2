using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AI_Assignment_2
{

    public class BackwardChain : SearchMethods
    {
        private string _outString;
       
        public BackwardChain(KnowledgeBase kb) : base(kb)
        { 
             _outString = "";
        }
        
        public override bool Solve(Clause query)
        {
            Stack<string> symbols = new Stack<string>();    // list for easy management
            List<string> Inferred = new List<string>();

            symbols.Push(query.Value);

            while (symbols.Count != 0)
            {
                string p = symbols.Pop();
                foreach (Clause c in Kb.List)
                {
                    if (c.Proposition.Count == 0)
                        if (c.Value == p)
                        {
                            Inferred.Add(c.Value);
                            Inferred.Reverse();
                            _outString = string.Join(" , ", Inferred.ToArray());
                            return true;
                        }
                }

                if (!Inferred.Contains(p))
                {
                    Inferred.Add(p);
                    foreach (Clause c in Kb.List)
                    {
                        if (c.Value == p || c.Proposition.Contains(p))
                        {
                           foreach(string s in c.Proposition)
                                symbols.Push(s);

                            if (c.Proposition.Count == 0)
                                if (c.Value == p)
                                {
                                    Inferred.Add(c.Value);
                                    Inferred.Reverse();
                                    _outString = string.Join(" , ", Inferred.ToArray());
                                    return true;
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
