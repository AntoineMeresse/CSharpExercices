using System;
using System.Collections.Generic;

namespace CS.Impl._02_Intermediate
{
    public class Recursion
    {
        public IEnumerable<int> GetNaturalNumbers(int n)
        {
            List<int> res = new List<int>();
            return GetNaturalNumbers(res, 1, n);
        }

        private IEnumerable<int> GetNaturalNumbers(List<int> naturalNumbers, int current, int max)
        {
            if (current > max) return naturalNumbers;
            else
            {
                naturalNumbers.Add(current);
                return GetNaturalNumbers(naturalNumbers, current + 1, max);
            }
        }

        public int SumNaturalNumbers(int n)
        {
            if (n == 0) return 0;
            else return n + SumNaturalNumbers(n - 1);
        }

        private int ComputeSum(int min, int current)
        {
            throw new NotImplementedException();
        }

        public bool IsPrime(int n)
        {
            return IsPrime(n, n - 1);
        }

        private bool IsPrime(int n, int current)
        {
            if (current == 1) return true;
            else
            {
                if (n % current == 0) return false;
                else return IsPrime(n, current - 1);
            }
        }

        public bool IsPalindrome(string text)
        {
            if (text.Length <= 1) return true;
            else
            {
                if (text[0] == text[text.Length - 1]) return IsPalindrome(text.Substring(1, text.Length - 2));
                else return false;
            }
        }
    }
}
