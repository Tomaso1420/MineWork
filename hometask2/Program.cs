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
            
            Console.WriteLine("Enter array lenth:");
            string lenth = Console.ReadLine();
            double[] array = new double[int.Parse(lenth)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = double.Parse(Console.ReadLine());
            }
            for (int i = 0;i < array.Length; i++) 
            { 
                if (array[i]>=0) 
                {
                    if (array[i] % 1 != 0)
                    {
                        array[i] = (Math.Round(array[i], 2) % 1) * 100;
                    }
                    else
                    {
                        for (double j = array[i] - 1; j > 0; j--)
                        {
                            array[i] = array[i] * j;
                        }
                    }
                }
                if (array[i] <0 & array[i] % 1 != 0)
                {
                    array[i] = -1 * (Math.Round(array[i], 2) % 1) * 100;
                }
            
            }
            for (int i =0;i<array.Length;i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}