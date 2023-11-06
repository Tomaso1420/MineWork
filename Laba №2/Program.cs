using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите выражение для преобразования в ОПЗ \nОбязательно каждый символ вводите через пробел!!!");
            string input = Console.ReadLine();

            List<string> elements = new List<string>();
            string[] split = input.Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                elements.Add((string)split[i]);

            }
            foreach (string c in ToRPN(elements))
            {
                Console.WriteLine(c);
            }
        }
            
            
             static List<string> ToRPN(List<string> elements)
            {
                List<string> stack = new List<string>();
                List<string> rpn = new List<string>();
                bool isHighPriorety = false;
                for (int i = 0; i < elements.Count; i++)
                {
                    string c = elements[i];
                    if (int.TryParse(elements[i], out int result))
                    {
                        rpn.Add(c);
                    }
                    if (c == "*" | c == "/")
                    {
                        stack.Add(c);
                        isHighPriorety = true;
                    }
                    if ((c == "+" | c == "-") & (isHighPriorety == false))
                    {
                        stack.Add(c);
                        isHighPriorety = false;
                    }
                    if ((c == "+" | c == "-") & (isHighPriorety == true))
                    {
                        if (stack.Contains("("))
                        {
                            int bracket = stack.IndexOf("(");
                            for (int j = stack.Count - 1; j > bracket; j--)
                            {
                                rpn.Add(stack[j]);
                                stack.RemoveAt(j);
                            }
                            stack.Add(c);
                        }
                        else
                        {
                            for (int j = stack.Count - 1; j >= 0; j--)
                            {
                                rpn.Add(stack[j]);
                                stack.RemoveAt(j);

                            }
                            stack.Add(c);
                        }
                    }
                    
                    if (c=="(")
                    {
                        stack.Add(c);
                        isHighPriorety = false;
                    }
                    if (c == ")")
                    {
                        int bracket = stack.IndexOf("(");
                        for (int j = stack.Count - 1; j >= bracket; j--)
                        {
                            rpn.Add(stack[j]);
                            stack.RemoveAt(j);
                        }
                        rpn.Remove(")");
                        rpn.Remove("(");
                    }
                }
               
                for (int j = stack.Count - 1; j >= 0; j--)
                {
                    rpn.Add(stack[j]);
                    stack.RemoveAt(j);
                   
                }
                return rpn;
             }

           
          
    }
}