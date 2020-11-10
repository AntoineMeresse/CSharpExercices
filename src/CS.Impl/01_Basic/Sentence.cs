using System;

namespace CS.Impl._01_Basic
{
    public class Sentence
    {
        public string Reverse(string sentence)
        {
            string res = "";
            string[] splitTable = sentence.Split(" ");
            for (int i = splitTable.Length-1; i >= 0; i--)
            {
                res += splitTable[i];
                if (i != 0) res += " ";
            }
            return res;
        }
    }
}
