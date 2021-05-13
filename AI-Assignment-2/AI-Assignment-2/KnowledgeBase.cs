using System;
using System.IO;
using System.Collections.Generic;


namespace AI_Assignment_2
{
	public class KnowledgeBase
	{
		List<string> _kBList;
		string _query;
		public KnowledgeBase(string filepath)
		{
			_kBList = readFile(filepath);
		}
		// maybe getters n setterz
		private List<string> readFile(string filepath)
		{
			StreamReader sR = new StreamReader(filepath);
			string line;
			List<string> kBL = new List<string>();
			string q = "cuck"; // change later

			while (!sR.EndOfStream)
			{
				line = sR.ReadLine();

				if (line == "TELL")
				{
					string[] kBA;
					string kB = sR.ReadLine();
					kB = kB.Replace(" ", String.Empty);
					kBA = kB.Split(';');
					foreach(string k in kBA)
                    {
						kBL.Add(k);
                    }
					

				}

				if (line == "ASK")
				{
					_query = sR.ReadLine(); // TODO: MAYBE FIX NICER?????
				}
			}

			foreach (string k in kBL)
			{
				
				Console.WriteLine(k);
			}

			Console.WriteLine(q);
			return kBL;
		}
	}
}