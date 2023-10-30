using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Program
    {
        public static void Main()
        {
            string[] commands = new string[6];
            commands[0] = "push Привет! Это снова я! Пока!";
            commands[1] = "pop 5";
            commands[2] = "push Как твои успехи? Плохо?";
            commands[3] = "push qwertyuiop";
            commands[4] = "push 1234567890";
            commands[5] = "pop 26";
            Console.WriteLine(ApplyCommands(commands));
        }
        private static string ApplyCommands(string[] commands)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < commands.Length; i++)
            {
                int index = commands[i].IndexOf(' ');
                string command = commands[i].Substring(0, index);
                if (command == "push")
                {
                    builder.Append(commands[i].Remove(0, index + 1));
                }
                if (command == "pop")
                {
                    string withoutCommand = commands[i].Remove(0, index + 1);
                    int numbersToRemove = int.Parse(withoutCommand);
                    builder.Remove(builder.Length - numbersToRemove, numbersToRemove);
                }
            }
           return builder.ToString();
        }
    }
}