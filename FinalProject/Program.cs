using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using FinalProject.Service;
using SQLParser;

namespace FinalProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            setConsoleBufferSize(1024);
            var service = new BaseService();
            while (true)
            {
                var confirm = true;
                var readLine = Console.ReadLine();

                if (string.IsNullOrEmpty(readLine))
                {
                    Log(Errors.InvalidSyntax);
                    continue;
                }

                //var actionName = readLine.Split(' ').First();
                //if (actionName.Equals(Actions.Delete) || actionName.Equals(Actions.Drop))
                //{
                //    Log($"Are you sure you want to {actionName} this item? (Y/N)");
                //    confirm = Console.Read().ToString().ToLower().Equals("y");
                //}
                if (confirm)
                {
                    var result  = service.ExecuteSqlCommand_Ado(readLine);
                    Log(result ?? Errors.InvalidSyntax);
                }
                CheckExitAndClear();
            }
        }

        public static void setConsoleBufferSize(int size)
        {
            int bufSize = size;
            Stream inStream = Console.OpenStandardInput(bufSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));

        }

        public static void CheckExitAndClear()
         {
            var readLine = Console.ReadLine();
            if (readLine != null && readLine.ToLower().Equals("clear"))
            {
                Console.Clear();
            }
            else if (readLine != null && readLine.ToLower().Equals("exit"))
                Environment.Exit(0);
        }

        public static void Log(string message)
        {
            const string breaker = "===========================================================================================================";
            Console.WriteLine($"{breaker}\n{message}\n{breaker}");
        }
    }
}
