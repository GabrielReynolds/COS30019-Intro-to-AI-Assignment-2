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

        public TruthTable() 
        {
           _models = new List<List<Clause>>();  // List of rows 
           _count = 0;                          // Amount of times KB is true
        }

        public override bool solve(KnowledgeBase kb, Clause q)
        {
            Stack<Clause> symbols = new Stack<Clause>();    // stack for easy management        
            List<Clause> init = new List<Clause>();         // initial row - everything is false
     
            symbols.Push(q);
        
            for(int i = 0; i < kb.Size; i++)
            { 
                symbols.Push(kb.Indexer(i));
                init.Add(kb.Indexer(i));
            }

            // Clause is added to model AFTER knowledge base - this ensures that it
            // does not replace its contents in loops by being at the front of the list
            init.Add(q);

            _models.Add(init);

            List<Clause> test = cloneList(init);
            test[0].Validity = true;

            return checkAll(kb, q, symbols, init);
        }

        public bool checkAll(KnowledgeBase kb, Clause q, Stack<Clause> symbols, List<Clause> model)
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
                Clause p = symbols.Pop();
                List<Clause> t = cloneList(model);
                List<Clause> f = cloneList(model);

                setValue(t, p);

                _models.Add(t);
                _models.Add(f);

                bool testT = checkAll(kb, q, symbols, t);
                bool testF = checkAll(kb, q, symbols, t);

                if(testT == true || testF == true)
                    return true;
                else
                    return false;
            }
        }

        public bool checkKB(KnowledgeBase kB, List<Clause> model)
        {
            for(int i = 0; i < kB.Size; i++)           
                if(model[i].Validity == false)
                    return false;  
            _count++;
            return true;
        }

        public bool checkQ(Clause q, List<Clause> model)
        {
            for(int i = 0; i < model.Count; i++)
                if(model[i].Value == q.Value && model[i].Proposition == q.Proposition)
                    if(model[i].Validity == true)
                        return true;
            return false;
        }


        // Clones each list/model - a deep copy is required to ensure each maintains seperate validity values

        private List<Clause> cloneList(List<Clause> test)
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

        private void setValue(List<Clause> container, Clause p)
        {
            for(int i = 0; i < container.Count; i++)
                if(container[i].Value == p.Value && container[i].Proposition == p.Proposition)
                    container[i].Validity = true;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }
    }
}