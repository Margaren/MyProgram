using System.Reflection;
using System.Text;
using MyUnit.Attributes;
using MyUnit.Exceptions;

namespace MyUnit.Console
{
    public class MyTestRunner
    {
        public static event Action<string,string> TestFailed;
        public static event Action<string, string> TestPassed;
        public static void Run(Type type)
        {
            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                RunTestMethod(method);
            }
        }

        private static void RunTestMethod(MethodInfo method)
        {
            var factAttribute = method.GetCustomAttribute<MyFactAttribute>(); 
            var inlineDataAttributes = method.GetCustomAttributes<MyInlineDataAttribute>();
            var instance = Activator.CreateInstance(method.DeclaringType);
            string testName = null;

            try
            {
                if (factAttribute != null)
                {
                    RunTestMethodAsFact(method, instance, out testName);
                    TestPassed?.Invoke(testName, string.Empty);
                }

                if(inlineDataAttributes.Any())
                {
                    foreach(var attribute in inlineDataAttributes)
                    {
                        RunTestMethodAsInlineData(method, instance, attribute, out testName);
                        TestPassed?.Invoke(testName, string.Empty);
                    }
                }
            }
            catch (TargetInvocationException ex)
                when (ex.InnerException is TestFailureException)
            {
                TestFailed?.Invoke(testName, ex.InnerException.Message);
            }
        }

        private static void RunTestMethodAsInlineData(MethodInfo method, object? instance, MyInlineDataAttribute attribute, out string testName)
        {
            var arglist = attribute.Arguments;
            var commaSeparatedArgs = new StringBuilder();

            var argumentsAsString = string.Join(", ", arglist.Select(o => o.ToString()));
            testName = $"{method.DeclaringType.Name}.{method.Name} ({argumentsAsString})";
            method.Invoke(instance, arglist);
        }

        private static void RunTestMethodAsFact(MethodInfo method, object? instance, out string testName)
        {
            testName = $"{method.DeclaringType.Name}.{method.Name}";

            method.Invoke(instance, null);
        }
    }
}