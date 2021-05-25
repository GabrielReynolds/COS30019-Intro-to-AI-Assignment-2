using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_2
{
    public abstract class SearchMethods
    {
        private KnowledgeBase _kb;
        private LinkedList<Clause> _searched;   // chuck searched stuff

        public SearchMethods(KnowledgeBase kb)
        { 
           _kb = kb;
           _searched = new LinkedList<Clause>();
        }

        public abstract bool solve(Clause query);

        public KnowledgeBase kb
        {
            get
            {
                return _kb;
            }
        }
    }
}
