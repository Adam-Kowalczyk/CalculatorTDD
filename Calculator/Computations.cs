using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Computations
    {
        public double Calculate(string a)
        {
            List<string> separator;
            string arguments;
            (separator, arguments) = GetSeparators(a);
            var splitted = arguments.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach(var arg in splitted)
            {
                var num = ParseNumber(arg);
                if(num < 0)
                    throw new ArgumentException("Negative argument");
                if (num > 1000)
                    continue;
                sum += num;
            }
            return sum;
        }

        public double ParseNumber(string a)
        {
            if (string.IsNullOrEmpty(a))
            {
                return 0;
            }
            var number1 = double.Parse(a);
            return number1;
        }

        public (List<string>, string) GetSeparators(string a)
        {
            if (!a.StartsWith("//"))
                return (new List<string>() { ",", "\n" }, a);
            
            var accepted = a.Substring(2);
            var split = accepted.Split('\n');
            var seps = GetSeparatorsList(split[0]);
            return (seps, split[1]);
        }

        public List<string> GetSeparatorsList(string a)
        {
            var separators = new List<string>();

            if(a.Length ==1)
            {
                separators.Add(a);
                return separators;
            }

            var splitted = a.Split(',');

            foreach(var sep in splitted)
            {
                if(sep.StartsWith('[') && sep.EndsWith(']'))
                {
                    int len = sep.Length - 2;
                    separators.Add(sep.Substring(1, len));
                }
            }
            return separators;
        }
    }
}
