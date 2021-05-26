using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_2
{
    public class TruthTable : SearchMethods
    {

        public TruthTable(KnowledgeBase kb) : base(kb) { }

        public override bool solve(Clause query)
        {
            Stack<Clause> symbols = new Stack<Clause>();    // stack for easy management

            for(int i = 0; i < kb.Size; i++)
            {     
                symbols.Push(kb.Indexer(i));
            }

            List<Clause> model = new List<Clause>(); 
            return CheckAll(kb, query, symbols, model);
        }

        public bool CheckAll(KnowledgeBase kb, Clause q, Stack<Clause> symbols, List<Clause> model)
        {
            if(symbols.Count == 0)
            {
                if(checkKB(kb, model))               
                    return (checkQ(q, model));            
                else
                    return true;    // When KB is false, always return true
            }
            else
            {
                Clause p = symbols.Pop();   // Effectively pops kB

                return CheckAll(kb, q, symbols, model);
            }
        }

        public bool checkKB(KnowledgeBase kB, List<Clause> model)
        {
            return true;
        }

        public bool checkQ(Clause q, List<Clause> model)
        {
            return true;
        }
    }
}