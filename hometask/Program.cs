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
            string number = Console.ReadLine();
            int[] array = new int[number.Length];
           
            for (int i = 0; i < number.Length; i++)
            {
              if (number[i] == '1' | number[i] == '2' | number[i] == '3' | number[i] == '4' | number[i] == '5' | number[i] == '6' | number[i] == '7' | number[i] == '8' | number[i] == '9' | number[i] == '0' | number[i] == '-')
                {
                    if (number[i] == '1')
                    {
                        array[i] = 1;
                    }
                    if (number[i] == '2')
                    {
                        array[i] = 2;
                    }
                    if (number[i] == '3')
                    {
                        array[i] = 3;
                    }
                    if (number[i] == '4')
                    {
                        array[i] = 4;
                    }
                    if (number[i] == '5')
                    {
                        array[i] = 5;
                    }
                    if (number[i] == '6')
                    {
                        array[i] = 6;
                    }
                    if (number[i] == '7')
                    {
                        array[i] = 7;
                    }
                    if (number[i] == '8')
                    {
                        array[i] = 8;
                    }
                    if (number[i] == '9')
                    {
                        array[i] = 9;
                    }
                }
              else { Console.WriteLine("Not correct format"); break; }
                
            }
            Console.WriteLine(array.Sum());
        }
    }
}