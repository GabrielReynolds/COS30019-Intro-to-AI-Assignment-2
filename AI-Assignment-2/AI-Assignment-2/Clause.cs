using System;
using System.Collections.Generic;
using System.IO;

namespace AI_Assignment_2
{
	public class Clause	// very confused about name tbh
	{
		int _count;
		string _value, _operator;
		List<string> _propositions;

		public Clause(List<string> propositions, string op, string value) // conditionals currently string for test
        {
			_propositions = propositions;           // previous conditionals (in a list for convenience, as multiple may be present)
			_value = value;							// current proposition 
			_operator = op;                         // relevant horn clause
			_count = propositions.Count;
		}

		public Clause(string value)
		{
			_value = value;

		}

		public string Value { get { return _value; } }
		public string Operator { get { return _operator; } }
		public List<string> Proposition { get { return _propositions; } }
		public int Count { get { return _count; } set { _count = value;  } }

		// Property to read entire clause:

		public string Sentence 
		{
            get 
			{
				if(_propositions == null)
					return _value;

				else
                { 
					string result = "";

					for(int i = 0; i < _propositions.Count; i++)			
						result += _propositions[i] + " ";					

					result += _operator + " " + _value;

					return result;
				}
			}
		}


	}
}