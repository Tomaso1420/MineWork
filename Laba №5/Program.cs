using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static FirstProject.Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstProject
{
    internal class Program
    {
        class Token
        {

        }

        class Number : Token
        {
            public double number;
        }

        class Operator : Token
        {
            public char operation;
        }

        class Parenthesis : Token
        {
            public bool IsOpenBracket;
        }

        public static void Main()
        {
            Console.WriteLine("Введите выражение для преобразования в ОПЗ\nНапример: 1+2/3*(4+5)");
            string input = Console.ReadLine();
            List<Token> parsedinput = Parse(input);
            List<Token> rpn = ToRPN(parsedinput);
            Print(rpn);
            Console.WriteLine();
            Console.WriteLine((Calculate(ToRPN(parsedinput))));

        }
        static List<Token> Parse(string input) // Преобразование введенной строки в лист токенов
        {
            List<Token> result = new List<Token>();
            string number = "";

            foreach (char s in input)
            {
                if (s != ' ')
                {
                    if (!char.IsDigit(s))
                    {
                        if (number != "")
                        {
                            Number num = new Number();
                            num.number = Convert.ToDouble(number);
                            result.Add(num);
                        }
                        if (s.Equals('-') || s.Equals('+') || s.Equals('*') || s.Equals('/'))
                        {
                            Operator op = new Operator();
                            op.operation = s;
                            result.Add(op);
                        }
                        else if (s.Equals('('))
                        {
                            Parenthesis par = new Parenthesis();
                            par.IsOpenBracket = true;
                            result.Add(par);
                        }
                        else
                        {
                            Parenthesis par = new Parenthesis();
                            par.IsOpenBracket = false;
                            result.Add(par);
                        }
                        number = "";
                    }
                    else
                    {
                        number += s;
                    }
                }
            }
            if (number != "")
            {
                Number num = new Number();
                num.number = Convert.ToDouble(number);
                result.Add(num);
            }

            return result;
        }
        static int GivePriority(Token op) // Приоритет операций(для метода ToRPN)
        {
            if (op is Operator)
            {
                Operator operat = (Operator)op;
                
                int priority = 0;
                if ((operat.operation).Equals('+'))
                {
                    priority = 1;
                }
                else if ((operat.operation).Equals('-'))
                {
                    priority = 1;
                }
                else if ((operat.operation).Equals('*'))
                {
                    priority = 2;
                }
                else if ((operat.operation).Equals('/'))
                {
                    priority = 2;
                }
                else { priority = 0; }
                return priority;
            }
            else { return 0; }

        }

        static List<Token> ToRPN(List<Token> elements) 
        {
            Stack<Token> stack = new Stack<Token>();
            List<Token> rpn = new List<Token>();
            foreach (Token c in elements)
            {

                if (c is Number)
                {
                    rpn.Add((Number)c);
                }
                else if (c is Operator)
                {
                    while (stack.Count > 0 && GivePriority(stack.Peek()) >= GivePriority(c))
                    {
                        rpn.Add(stack.Pop());
                    }
                    stack.Push((Operator)c);
                }
                else if (c is Parenthesis)
                {
                    if (((Parenthesis)c).IsOpenBracket)
                    {
                        stack.Push((Parenthesis)c);
                    }
                    else
                    {
                        while (stack.Count > 0 && !(stack.Peek() is Parenthesis))
                        {
                            rpn.Add(stack.Pop());
                        }
                        stack.Pop();

                    }
                }
            }
            while (stack.Count > 0)
            {
                rpn.Add(stack.Pop());
            }
            return rpn;
        }
            static double Calculate(List<Token> RPN)
            {
                Stack<double> numbers = new();

                foreach (Token token in RPN)
                {
                    if (token is Number number)
                    {
                        numbers.Push(number.number);
                    }
                    else if (token is Operator operation)
                    {
                        double second = numbers.Pop();
                        double first = numbers.Pop();
                        Number firstNum = new();
                        firstNum.number = first;
                        Number secondNum = new();
                        secondNum.number = second;

                        double resultedNum = (Count((Number)firstNum, (Number)secondNum, (Operator)token)).number;
                        numbers.Push(resultedNum);
                    }
                }

                return numbers.Pop();
            }
            static Number Count(Number firstNum, Number secondNum, Operator token)
            {
                Number result = new();
               
                if (token.operation == '-')
                {
                    result.number = firstNum.number - secondNum.number;
                }
                if (token.operation == '+')
                {
                    result.number = firstNum.number + secondNum.number;
                }
                if (token.operation == '*')
                {
                    result.number = firstNum.number * secondNum.number;
                }
                if (token.operation == '/')
                {
                    result.number = firstNum.number / secondNum.number;
                }
                return result;
            }
        static void Print(List<Token> list) // вывод листа токенов
        {
            foreach (Token e in list)
            {
                if (e is Number)
                {
                    Number num = new();
                    num = (Number)e;
                    Console.Write(num.number);
                    Console.Write(" ");
                }
                else if (e is Operator)
                {
                    Operator op = new();
                    op = (Operator)e;
                    Console.Write(op.operation);
                    Console.Write(" ");
                }
                else
                {
                    Parenthesis bracket = new();
                    bracket = (Parenthesis)e;
                    if (bracket.IsOpenBracket) Console.Write("( ");
                    else Console.Write(") ");
                }
            }
           
        }


    }
}