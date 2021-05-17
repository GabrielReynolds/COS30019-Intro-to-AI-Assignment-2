using System;
using System.Collections.Generic;
using System.IO;

namespace AI_Assignment_2
{
	public class Proposition	// very confused about name tbh
	{
		string _value, _clause;
		string _conditionals;

		public Proposition(string value, string clause, string conditionals)
		{
			_value = value;							// current proposition
			_clause = clause;						// relevant horn clause
			_conditionals = conditionals;			// previous conditionals (in a list for convenience, as multiple may be present)
		}
	}
}