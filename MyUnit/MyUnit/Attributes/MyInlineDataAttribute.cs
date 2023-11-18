namespace MyUnit.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MyInlineDataAttribute : Attribute
    {
        public object[] Arguments { get;  }
        public MyInlineDataAttribute(params object[] arguments) => Arguments = arguments;
    }
}
