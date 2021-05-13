using System;
using System.IO;


namespace AI_Assignment_2
{
	public class KnowledgeBase
	{
		public KnowledgeBase(string filepath)
		{
			readFile(filepath);
		}

		private void readFile(filepath)
		{
			StreamReader sR = new StreamReader(filepath);
			string line;
			string[] kBA;
			string q;

			while (!sR.EndOfStream)
			{
				line = sR.ReadLine();

				if (line == "TELL")
				{
					string kB = sR.ReadLine();
					kBA = kB.Split(';');
				}

				if (line == "ASK")
				{
					q = sR.ReadLine();
				}
			}

			foreach (string k in kBA)
			{
				Console.WriteLine(k);
			}

			Console.WriteLine(q);
		}
	}
}