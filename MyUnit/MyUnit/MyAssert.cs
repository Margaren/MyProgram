using MyUnit.Exceptions;

namespace MyUnit
{
    public static class MyAssert
    {
        public static void Equal(object expected, object acual)
        {
            if (!expected.Equals(acual))
            {
                throw new TestFailureException($"Ожидалось значение {expected}, но получено {acual}");
            }
        }

        public static void Throws<TException>(Action action) where TException : Exception
        {
            try
            {
                action?.Invoke();
                throw new TestFailureException($"Ожидалось исключение {typeof(TException)}, но не было запущено");
            }

            catch (TException)
            { 
            }
            catch (Exception ex)
            {
                throw new TestFailureException($"Ожидалось исключение {typeof(TException)}, но запустилось {ex.GetType().Name}");
            }
        }

        public static void True(bool actual)
        {
            if (!actual)
            {
                throw new TestFailureException($"Ожидалось {true}, но ");
            }
        }

        public static void False(bool actual)
        {
            if (actual)
            {
                throw new TestFailureException($"Ожидалось {false}, но ");
            }
        }
    }
}
