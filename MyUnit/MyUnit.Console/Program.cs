using SystemArithmetic.Tests;

namespace MyUnit.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyTestRunner.TestFailed += (testName, message) => PrintResult(testName, message, false);
            MyTestRunner.TestPassed += (testName, message) => PrintResult(testName, message, true);
            MyTestRunner.Run(typeof(SumOperationTest));
        }

        private static void PrintResult(string testName, string message, bool success)
        {
            System.Console.BackgroundColor = !success 
                ? ConsoleColor.Red
                : ConsoleColor.Green;
            System.Console.Write( success? "ПРОЙДЕН" : "ПРОВАЛЕН");
            System.Console.ResetColor();
            System.Console.WriteLine($" {testName} {(string.IsNullOrWhiteSpace(message) ? "" : ": ")}");
        }
    }

}


