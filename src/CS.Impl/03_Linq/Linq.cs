﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CS.Impl._03_Linq
{
    public class Linq
    {
        public IEnumerable<string> FindStringsWhichStartsAndEndsWithSpecificCharacter(string startCharacter, string endCharacter, IEnumerable<string> strings)
        {
            List<string> res = new List<string>();
            foreach (string s in strings)
            {
                if (s.Length > 2 && s[0].ToString().Equals(startCharacter) && s[s.Length - 1].ToString().Equals(endCharacter)) res.Add(s);
            }
            return res;
        }

        public IEnumerable<int> GetGreaterNumbers(int limit, IEnumerable<int> numbers)
        {
            List<int> res = new List<int>();
            foreach (int i in numbers)
            {
                if (i > limit) res.Add(i);
            }
            return res;
        }

        public IEnumerable<int> GetTopNRecords(int limit, IEnumerable<int> numbers)
        {
            List<int> res = new List<int>();
            List<int> cpy = numbers.ToList();
            int currentMax;
            for (int i = 0; i < limit; i++)
            {
                currentMax = cpy.Max();
                res.Add(currentMax);
                cpy.Remove(currentMax);
            }
            return res;
        }

        public IDictionary<string, int> GetFileCountByExtension(IEnumerable<string> files)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            string currentExtension;
            int currentValue;
            foreach (string s in files)
            {
                currentExtension = s.Split(".")[1].ToLower(); // certaines extensions sont en majs
                if (res.ContainsKey(currentExtension))
                {
                    currentValue = res[currentExtension];
                    res[currentExtension] = currentValue + 1;
                }
                else
                {
                    res.Add(currentExtension, 1);
                }
            }
            return res;
        }

        public IEnumerable<Tuple<string, string, int, double>> GetFinalReceipe(List<Item> items, List<Client> clients, List<Purchase> purchases)
        {
            List<Tuple<string, string, int, double>> res = new List<Tuple<string, string, int, double>>();
            Tuple<string, string, int, double> current;
            string name = "";
            string product = "";
            int qte;
            double prix = 0.0;
            foreach (Purchase p in purchases)
            {
                // get client infos
                foreach (Client c in clients)
                {
                    if (c.Id == p.ClientId)
                    {
                        name = c.Name;
                    }
                }

                // get product infos
                foreach (Item i in items) 
                {
                    if (i.Id == p.ItemId)
                    {
                        product = i.Label;
                        prix = i.Price;
                    }
                }

                qte = p.Quantity;
                
                current = Tuple.Create(name,product,qte,prix);

                res.Add(current);
            }
            return res;
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public double Price { get; set; }
    }

    public class Purchase
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int ClientId { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
