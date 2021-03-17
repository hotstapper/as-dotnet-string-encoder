using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Encoder
{
    public class EncoderProcessor
    {
        public string Encode(string message)
        {
            //Implement your code here!
            string _message = message.ToLower();
            MatchCollection numbers = Regex.Matches(_message, @"\d+");
            StringBuilder withNumbers = new StringBuilder(_message);
            foreach (Match item in numbers)
            {
                char[] cArray = item.Value.ToCharArray();
                Array.Reverse(cArray);
                withNumbers.Replace(item.Value, new string(cArray));
            }
            StringBuilder _Output = new StringBuilder();
            // reverse string with numbers 
            _Output.Append(withNumbers);


            // use of genric 
            IDictionary<char, int> m = new Dictionary<char, int>();
            m.Add('a', 1);
            m.Add('e', 2);
            m.Add('i', 3);
            m.Add('o', 4);
            m.Add('u', 5);

            _message = _Output.ToString();
            string OutPut = "";
            char[] charArray = { };
            for (int i = 0; i <= _message.Length - 1; i++)
            {
                char c = _message[i];
                if (m.ContainsKey(c))
                {
                    OutPut += m[c];
                }
                else if (c == 'y')
                {
                    OutPut += ' ';
                }
                else if (c >= 'a' && c <= 'z')
                {
                    OutPut += (char)(c - 1);
                }
                else if (c == ' ')
                {
                    OutPut += 'y';
                }
                else if (!m.ContainsKey(c))
                {
                    OutPut += c;
                }

            }
            return OutPut;
            throw new NotImplementedException();
        }
    }
}