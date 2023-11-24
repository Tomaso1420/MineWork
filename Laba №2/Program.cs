using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите выражение для преобразования в ОПЗ\nНапример: 1+2/3*(4+5)");
            string input = Console.ReadLine();
            List<object> parsedExpression = Parse(input);
            foreach (object e in ToRPN(parsedExpression)) 
            { 
                Console.WriteLine(e);
            }
            Console.WriteLine(Calculate(ToRPN(parsedExpression)));
        }
        static List<object> Parse(string expression) 
        {
            List<object> result = new List<object>();
            string num = "";

            foreach (char c in expression)
            {
                if (c != ' ')
                {
                    if (!char.IsDigit(c))
                    {
                        if (num != "") result.Add(num);
                        result.Add(c);
                        num = "";
                    }
                    else
                    {
                        num += c;
                    }
                }
            }

            if (num != "") result.Add(num);

            return result;
        }


        static List<object> ToRPN(List<object> elements)
            {
                List<object> stack = new List<object>();
                List<object> rpn = new List<object>();
                bool isHighPriorety = false;
                for (int i = 0; i < elements.Count; i++)
                {
                    object c = elements[i];
                    if (c is string)
                    {
                        rpn.Add(c);
                    }
                    if (c.Equals('*') | c.Equals('/'))
                    {
                        stack.Add(c);
                        isHighPriorety = true;
                    }
                    if ((c.Equals('+') | c.Equals('-')) & (isHighPriorety == false))
                    {
                        stack.Add(c);
                        isHighPriorety = false;
                    }
                    if ((c.Equals('+') | c.Equals('-')) & (isHighPriorety == true))
                    {
                        if (stack.Contains('('))
                        {
                            int bracket = stack.IndexOf('(');
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
                    
                    if (c.Equals('('))
                    {
                        stack.Add(c);
                        isHighPriorety = false;
                    }
                    if (c.Equals(')'))
                    {
                        int bracket = stack.IndexOf('(');
                        for (int j = stack.Count - 1; j >= bracket; j--)
                        {
                            rpn.Add(stack[j]);
                            stack.RemoveAt(j);
                        }
                        rpn.Remove(')');
                        rpn.Remove('(');
                    }
                }
               
                for (int j = stack.Count - 1; j >= 0; j--)
                {
                    rpn.Add(stack[j]);
                    stack.RemoveAt(j);
                   
                }
                return rpn;
             }
           public static float Calculate(List<object> RPN)
           {
                List<float> memory = new List<float>();
                for (int i = 0; i < RPN.Count; i++)
                {
                    if (RPN[i].Equals('*'))
                    {
                        memory[memory.Count - 2] = memory[memory.Count - 2] * memory[memory.Count - 1];
                        memory.RemoveAt(memory.Count - 1);
                    }
                    else if (RPN[i].Equals('/'))
                {   
                        memory[memory.Count - 2] = memory[memory.Count - 2] / memory[memory.Count - 1];
                        memory.RemoveAt(memory.Count - 1);
                    }
                    else if (RPN[i].Equals('+'))
                {   
                        memory[memory.Count - 2] = memory[memory.Count - 2] + memory[memory.Count - 1];
                        memory.RemoveAt(memory.Count - 1);
                    }
                    else if (RPN[i].Equals('-'))
                {   
                        memory[memory.Count - 2] = memory[memory.Count - 2] - memory[memory.Count - 1];
                        memory.RemoveAt(memory.Count - 1);
                    }
                    else
                    {
                        string number = (string)RPN[i];
                        memory.Add(int.Parse(number)); 
                    }
                }
                float output = memory[0];
                return output;
           }
          
    }
}