﻿using System;
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

		List<Proposition> _kBList;
		string _query;

		public KnowledgeBase(string filepath)
		{
			_kBList = null;
				readFile(filepath);

		}

		// maybe getters n setterz
		private void readFile(string filepath)
		{
			StreamReader sR = new StreamReader(filepath);
			string line;
			List<Proposition> kBL = new List<Proposition>();

			while (!sR.EndOfStream)
			{
				line = sR.ReadLine();

				if (line == "TELL")
				{
					string[] kBA;
					string[] kBB;
					string kB = sR.ReadLine();

					kB = kB.Replace(" ", String.Empty);
					kBA = kB.Split(';');

					foreach(string k in kBA)
                    { 
						string[] temp = Regex.Split(k, @"(?<=[=])");

                    }
				}

				if (line == "ASK")
					_query = sR.ReadLine(); // TODO: MAYBE FIX NICER?????			
			}

			foreach (string k in kBB)				
				Console.WriteLine(k);	

		}
	}
}