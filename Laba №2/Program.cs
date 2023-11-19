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
            Console.WriteLine("Введите выражение для преобразования в ОПЗ \nОбязательно каждый символ вводите через пробел!!!\n Например: 1 + 2 / 3 * ( 4 + 5 )");
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
            Console.WriteLine(Calculate(ToRPN(elements)));
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
           public static float Calculate(List<string> RPN)
           {
                List<float> memory = new List<float>();
                for (int i = 0; i < RPN.Count; i++)
                {
                    if (RPN[i] == "*")
                    {
                        memory[memory.Count - 2] = memory[memory.Count - 2] * memory[memory.Count - 1];
                        memory.RemoveAt(memory.Count - 1);
                    }
                    else if (RPN[i] == "/")
                    {   
                        memory[memory.Count - 2] = memory[memory.Count - 2] / memory[memory.Count - 1];
                        memory.RemoveAt(memory.Count - 1);
                    }
                    else if (RPN[i] == "+")
                    {   
                        memory[memory.Count - 2] = memory[memory.Count - 2] + memory[memory.Count - 1];
                        memory.RemoveAt(memory.Count - 1);
                    }
                    else if (RPN[i] == "-")
                    {   
                        memory[memory.Count - 2] = memory[memory.Count - 2] - memory[memory.Count - 1];
                        memory.RemoveAt(memory.Count - 1);
                    }
                    else
                    {
                        memory.Add(int.Parse(RPN[i])); 
                    }
                }
                float output = memory[0];
                return output;
           }
          
    }
}