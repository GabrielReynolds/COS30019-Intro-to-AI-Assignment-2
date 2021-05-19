using System;
using System.Collections.Generic;
using System.IO;

namespace AI_Assignment_2
{
	public class Clause	// very confused about name tbh
	{
		string _value, _operator;
		List<string> _propositions;

		public Clause(List<string> propositions, string op, string value) // conditionals currently string for test
        {
			_propositions = propositions;           // previous conditionals (in a list for convenience, as multiple may be present)
			_value = value;							// current proposition
			_operator = op;					// relevant horn clause
		}

		public Clause(string value)
		{
			_value = value;

		}
		public string Value { get { return _value; } }
		public string Operator { get { return _operator; } }
		public List<string> Proposition { get { return _propositions; } }


	}
}