using MyUnit.Exceptions;

namespace MyUnit
{
    public static class MyAssert
    {
        public static void Equal(object expected, object acual)
        {
            if (!expected.Equals(acual))
            {
                throw new TestFailureException($"Ожидалось значение {expected}, но получили хуй{acual}");
            }
        }

        public static void Throws<TException>(Action action) where TException : Exception
        {
            try
            {
                action?.Invoke();
                throw new TestFailureException($"Ожидалось исключение {typeof(TException)}, но не было запущено ровным счётом НИ-ХУ-Я!");
            }

            catch (TException)
            { 
            }
            catch (Exception ex)
            {
                throw new TestFailureException($"Ожидалось исключение {typeof(TException)}, но запустилось какое-то уёбище по имени {ex.GetType().Name}");
            }
        }

        public static void True(bool actual)
        {
            if (!actual)
            {
                throw new TestFailureException($"Ожидалось {true}, но КОНЬ В ПАЛЬТО!");
            }
        }

        public static void False(bool actual)
        {
            if (actual)
            {
                throw new TestFailureException($"Ожидалось {false}, но... не нокай! Ты не конь!");
            }
        }
    }
}
