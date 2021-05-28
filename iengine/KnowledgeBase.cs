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

		private List<Clause> _kB;   
		private Clause _query;

		public KnowledgeBase(string filepath)
		{
			_kB = new List<Clause>();
			ReadFile(filepath);
		}

		private void ReadFile(string filepath)
		{
			StreamReader sR = new StreamReader(filepath);
			string line;
			
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
								string[] temp = Regex.Split(k, @"(?>=[=>])");		// isolates value and proposition
								string[] temp2 = Regex.Split(temp[0], @"(?>[&])");  // splits propostion by the & to add to list

								for (int i = 0; i < temp.Length; i++)
									tempList.Add(temp2[i]);

								Clause p = new Clause(tempList, "=>", temp[temp.Length - 1]);	// Currently hardcoded: not flexible, but it functions for now
								_kB.Add(p);
							}

							else // No Conjunction - 1 proposition
							{
								List<string> tempList = new List<string>();
								string[] temp = Regex.Split(k, @"(?>=[=>])");   // splits into 2

								tempList.Add(temp[0]);
								Clause p = new Clause(tempList, "=>", temp[1]);
								_kB.Add(p);
							}
						}
						else    // Lone value
						{
							Clause p = new Clause(k);
							_kB.Add(p);
						}
					}
				}

				if (line == "ASK")
                { 
					string query = sR.ReadLine(); 	
					Clause q = new Clause(query);
					_query = q;
				}
			}
			_kB.RemoveAt(_kB.Count-1);
		}

		public void Remove(int i)
        {
			_kB.RemoveAt(i);
		}

		public Clause Indexer(int i)
        {
			return _kB[i];
		}

		public Clause First 
		{
			get
            {
				Clause result = _kB[0];
				
				return result;
			}
		}
		public List<Clause> List
        { 
			get
            {
				return _kB;
            }
		}

		public Clause Query
        {
			get
            {
				return _query;
			}
			set
            {
				_query = value;
			}
		}

		public int Size
        {
			get
            {
				return _kB.Count;
			}
		}
	}
}