using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AI_Assignment_2
{
	public class KnowledgeBase
	{

		// We need a way to access and sort each proposition (I think that's the right word),
		// to simulate a map of nodes (like in the lectures).
		// Hence the new class: kinda like problem set 3 for data

		List<Clause> _kBList;   // WHY WON'T YOU RECOGNISE // it recognises :)
		string _query;

		public KnowledgeBase(string filepath)
		{
			_kBList = new List<Clause>();
			readFile(filepath);
		}

		// maybe getters n setterz
		private void readFile(string filepath)
		{
			StreamReader sR = new StreamReader(filepath);
			string line;
			List<Clause> kBL = new List<Clause>();
			string[] kBB;
			Regex rgx = new Regex(@"(?>=[=>])");
			Regex rgx2 = new Regex(@"([&])");

			while (!sR.EndOfStream)
			{
				line = sR.ReadLine();

				if (line == "TELL")
				{
					string[] kBA;

					string kB = sR.ReadLine();

					kB = kB.Replace(" ", String.Empty);
					kBA = kB.Split(';');


					foreach (string k in kBA)
					{
						if (rgx.IsMatch(k))
						{
							if (rgx2.IsMatch(k))    // Check for conjunction
							{
								List<string> tempList = new List<string>();
								string[] temp = Regex.Split(k, @"(?>=[=>])"); // isolates value and proposition
								string[] temp2 = Regex.Split(temp[0], @"(?>[&])");   // splits propostion by the & to add to list

								for (int i = 0; i < temp.Length - 1; i++)
									tempList.Add(temp2[i]);


								Clause p = new Clause(tempList, "=>", temp[temp.Length - 1]);
								kBL.Add(p);
							}

							else // No Conjunction - 1 proposition
							{
								List<string> tempList = new List<string>();
								string[] temp = Regex.Split(k, @"(?>=[=>])");   // splits into 2

								tempList.Add(temp[0]);
								Clause p = new Clause(tempList, "=>", temp[1]);
								kBL.Add(p);
							}
						}
						else    // Lone value
						{
							Clause p = new Clause(k);
							kBL.Add(p);
						}
					}
				}

				if (line == "ASK")
					_query = sR.ReadLine(); // TODO: MAYBE FIX NICER?????			
			}

			foreach (Clause c in kBL)
				Console.WriteLine(c.Operator);

		}
	}
}