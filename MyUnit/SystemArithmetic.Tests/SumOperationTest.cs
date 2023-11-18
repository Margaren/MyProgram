using MyUnit;
using MyUnit.Attributes;

namespace SystemArithmetic.Tests
{
    public class SumOperationTest
    {
        [MyInlineData (1, 1, 2)]
        [MyInlineData (2, 2, 4)]
        public void OnePlus_EqualsTwo(int first, int second, int expected)
        {
            //Arrange + atc
            var result = first + second;

            //Assert
            MyAssert.Equal(expected, result);
        }

        [MyFact]
        public void TwoTimesTwo_EqualsFour()
        {
            //Arrange + atc
            var result = 2 * 2;

            //Assert
            MyAssert.Equal(4, result);
        }

        [MyFact]
        public void DevideByZero_Throws()
        {
            var a = 1;
            var b = 0;
            MyAssert.Throws<DivideByZeroException>(() => { var res = a / b; });
        }

        [MyFact]
        public void OneEqualsOne()
        {
            MyAssert.True(1 == 1);
        }


        [MyFact]
        public void TwoIsMoreTHanThree_False()
        {
            MyAssert.False(2 > 3);
        }
    }
}