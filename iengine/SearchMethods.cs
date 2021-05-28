using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_2
{
    public abstract class SearchMethods
    {
        private string _outString;
        private KnowledgeBase _kb;
       

        public SearchMethods(KnowledgeBase kb)
        { 
           _kb = kb;
           
            _outString = "";
        }

        public abstract bool Solve(Clause query);

        public KnowledgeBase Kb
        {
            get
            {
                return _kb;
            }
        }

        public virtual string Result
        {
            get
            {
                return _outString;
            }
        }

    }
}
