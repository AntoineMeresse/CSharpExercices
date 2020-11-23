using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CS.Impl._04_Advanced
{
    public class PermutationPrime
    {
        public IEnumerable<string> GetPermutations(string set)
        {
            var output = new List<String>();
            if (set.Length == 1)
            {
                output.Add(set);
            }
            else
            {
                foreach (var c in set)
                {
                    var tail = set.Remove(set.IndexOf(c), 1);
                    foreach (var tailPerms in GetPermutations(tail))
                    {
                        output.Add(c + tailPerms);
                    }
                }
            }
            return output;
        }

        private bool isPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(n));

            for (int i = 2; i<=limit; ++i)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private bool isPermutationPrime(int n)
        {
            int current;
            foreach (string c in GetPermutations(n.ToString()))
            {
                current = int.Parse(c);
                if (!isPrime(current)) return false;
            }
            return true;
        }

        public int[] GetPermutationPrimes(int upperBound)
        {
            List<int> res = new List<int>();
            for (int i = 0; i <= upperBound; i++)
            {
                if (isPermutationPrime(i)) res.Add(i);
            }
            
            return res.ToArray();
        }
    }
}
