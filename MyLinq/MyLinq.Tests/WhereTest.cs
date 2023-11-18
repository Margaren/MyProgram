namespace MyLinq.Tests
{
    public class WhereTest
    {
        [Fact]
        public void NotEmptyCollection_GetElementsMoreThanFive_Success()
        {
            //Arrange
            var array = new[] { 1, 2, 3, 4, 5, 10, 20 };
            var expected = new[] {10, 20};

            //Act
            var result = array.Where(o => o > 5);

            //Assert
            Assert.Equal(expected,result);

        }

        [Fact]
        public void NullSource_Throws()
        {
            //Arrange
            int[] array = null;
            
            //Act + Assert
            Assert.Throws<InvalidOperationException>(() => array.Where(o => o > 0)); //выложить тестовый двидок на гитхаб
        }

        [Fact]
        public void NotEmptyCollection_GetNonFitElements_EmptyResult()
        {
            var array = new[] { 1, 2, 3, 4, 5, 10, 20 };
            var result = array.Where(o => o > 5);
            Assert.Empty(result);
        }

        [Fact]
        public void CollectionWithtupels_GetSpecificOne_Success()
        {
            //Arange
            var array = new (int Garde, double Salary)[]
            {
                (Grade: 5, Salary: 10),
                (Grade: 10, Salary: 2400),
            };

            //Act
            var result = array.Where(o => o.Garde == 10);

            //Assert
            Assert.Single(result);
        }
    }
}