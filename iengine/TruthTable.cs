using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_2
{
    public class TruthTable : SearchMethods
    {
        private List<List<Clause>> _models;
        private int _count;       
        private string _outString;
        public TruthTable(KnowledgeBase kb) : base(kb) 
        {
           _models = new List<List<Clause>>();  // List of rows 
           _count = 0;                          // Amount of times KB is true
        }

        public override bool Solve(Clause q)
        {
            Stack<Clause> symbols = new Stack<Clause>();    // stack for easy management        
            List<Clause> init = new List<Clause>();         // initial row - everything is false
     
            symbols.Push(q);
        
            for(int i = 0; i < Kb.Size; i++)
            { 
                symbols.Push(Kb.Indexer(i));
                init.Add(Kb.Indexer(i));
            }

            // Clause is added to model AFTER knowledge base - this ensures that it
            // does not replace its contents in loops by being at the front of the list
            init.Add(q);

            _models.Add(init);

            List<Clause> test = CloneList(init);
            test[0].Validity = true;

            return CheckAll(Kb, q, symbols, init);
        }

        public bool CheckAll(KnowledgeBase kb, Clause q, Stack<Clause> symbols, List<Clause> model)
        {
            if(symbols.Count == 0)
            {
                if(CheckKB(kb, model))               
                    return (CheckQ(q, model));            
                else
                    return true;    // When KB is false, always return true
            }
            else
            {
                Clause p = symbols.Pop();
                List<Clause> t = CloneList(model);
                List<Clause> f = CloneList(model);

                SetValue(t, p);

                _models.Add(t);
                _models.Add(f);

                bool testT = CheckAll(kb, q, symbols, t);
                bool testF = CheckAll(kb, q, symbols, t);

                if(testT == true || testF == true)
                    return true;
                else
                    return false;
            }
        }

        public bool CheckKB(KnowledgeBase kB, List<Clause> model)
        {
            for(int i = 0; i < kB.Size; i++)           
                if(model[i].Validity == false)
                    return false;  
            _count++;
            return true;
        }

        public bool CheckQ(Clause q, List<Clause> model)
        {
            for(int i = 0; i < model.Count; i++)
                if(model[i].Value == q.Value && model[i].Proposition == q.Proposition)
                    if(model[i].Validity == true)
                        return true;
            return false;
        }


        // Clones each list/model - a deep copy is required to ensure each maintains seperate validity values

        private List<Clause> CloneList(List<Clause> test)
        {
            List<Clause> result = new List<Clause>();

            for(int i = 0; i < test.Count; i++)
            {
                // Gather parameters
                List<string> propositions = test[i].Proposition; 
                string op = test[i].Operator;
                string value = test[i].Value;

                // Instantiate new list/model
                Clause temp = new Clause(propositions, op, value);

                // Set validity (True or False)
                temp.Validity = test[i].Validity;
                
                result.Add(temp);
            }

            return result;
        }

        private void SetValue(List<Clause> container, Clause p)
        {
            for(int i = 0; i < container.Count; i++)
                if(container[i].Value == p.Value && container[i].Proposition == p.Proposition)
                    container[i].Validity = true;
        }

        public override string Result
        {
            get
            {
                _outString = _count.ToString();
                return _outString;
            }
        }
    }
}