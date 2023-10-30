using System;
using System.Threading.Tasks.Dataflow;

namespace Programm;

class Program
{
    static string SaveBuffer(List<int> numbers, string buffer)
    {
        if (!string.IsNullOrEmpty(buffer))
        {
            numbers.Add(int.Parse(buffer));
        }

        return string.Empty;
    }

    static int CalculateExpression(List<int> numbers, List<char> operators)
    {
        while (operators.Count > 0)
        {
            if (operators.Contains('*') || operators.Contains('/'))
            {
                int multiplyIndex = operators.IndexOf('*');
                int devideIndex = operators.IndexOf('/');

                int operatorIndex = -1;
                if (multiplyIndex > 0 && devideIndex > 0
                    || multiplyIndex > 0 || devideIndex > 0)
                {
                    operatorIndex = multiplyIndex > devideIndex
                        ? devideIndex
                        : multiplyIndex;
                }

                char op = operatorIndex > 0
                    ? operators[operatorIndex]
                    : operators[0];

                int num1 = numbers[operatorIndex];
                int num2 = numbers[operatorIndex + 1];

                int result = Calculate(op, num1, num2);

                numbers.RemoveAt(operatorIndex + 1);
                numbers.RemoveAt(operatorIndex);
                operators.RemoveAt(operatorIndex);

                numbers.Insert(operatorIndex, result);
            }
        }

        return numbers[0];
    }

    static int Calculate(char op, int num1, int num2)
    {
        switch (op)
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/': return num1 / num2;
        }

        throw new Exception("Unknown operation");
        //Console.WriteLine("ERROR");
        //return 0;
    }

    static void Main(string[] args)
    {
        // 1 +12 *     32 / 2
        // int
        // + - * /

        // 1 12 32 2
        // + * /

        string input = "12 +    5 *11 / 4";
        input = input.Replace(" ", string.Empty);

        char[] availableOps = new[] { '+', '-', '*', '/' };

        List<int> numbers = new List<int>();
        List<char> operators = new List<char>();
        string buffer = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            if (!char.IsDigit(input[i]))
            {
                operators.Add(input[i]);
                buffer = SaveBuffer(numbers, buffer);
            }
            else
            {
                buffer += input[i];
            }
        }

        SaveBuffer(numbers, buffer);

        // output
        foreach (int number in numbers)
        {
            Console.Write($"{number},");
        }
        Console.WriteLine();

        foreach (char op in operators)
        {
            Console.Write($"{op},");
        }
        Console.WriteLine();

        int result = CalculateExpression(numbers, operators);
        Console.WriteLine(result);
    }
}