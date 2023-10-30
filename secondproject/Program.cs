using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int result = 0;
            string input = Console.ReadLine();
            input = input + ' ';
            List<char> listchar = new List<char>();
            List<int> listint = new List<int>();
            int length = input.Length;
            string[] split = input.Split(' ');
            for (int i = 0; i < length; i++)
            {

                if (input[i] == '*' | input[i] == '/' | input[i] == '+' | input[i] == '-')
                {
                    listchar.Add(input[i]);
                }
            }
            for (int i = 0; i < split.Length; i++)
            {
                if (int.TryParse(split[i], out int number))
                {
                    listint.Add(number);
                }
            }
             for (int b =  0; b < listchar.Count; b++)
            {
                for (int c = 0; c<listint.Count; c+=2)
                {
                    for (int d = 1; d < listint.Count; d+=2)
                    {


                        char expression = listchar[b];
                        int fNumber = listint[c];
                        int sNumber = listint[d];
                        if (expression == '*')
                        {
                            result = fNumber * sNumber;
                        }
                        if (expression == '/')
                        {
                            result = fNumber / sNumber;
                        }
                        if (expression == '+')
                        {
                            result = fNumber + sNumber;
                        }

                        if (expression == '-')
                        {
                            result = fNumber - sNumber;
                        }

                        
                    }
                }
                Console.WriteLine(result);


            }












            // foreach (char c in listchar)
            // {
            //     Console.WriteLine(c);
            // }
            // foreach (char z in listint)
            //{
            //     Console.WriteLine(z);
            // }

        }
    }
}