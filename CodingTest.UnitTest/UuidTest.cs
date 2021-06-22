using System.Collections.Generic;
using Xunit;

namespace CodingTest.UnitTest
{
    public class UuidTest
    {
        /// <summary>
        /// Test Function for get LIS
        /// </summary>
        /// <param name="input">Input value</param>
        /// <param name="expectedLis">Expected Output</param>
        [Theory, MemberData(nameof(LisInput))]
        public void LisTest(string input, string expectedLis)
        {
            // Arrange 
            var uuid = new Uuid();

            // Act
            var resultLis = uuid.GetLis(input);
            
            // Assert
            // result should be equal to expected  
            Assert.Equal(resultLis, expectedLis);
        }
        
        public static IEnumerable<object[]> LisInput
        {
            get
            {
                return new[]
                {
                    // Test case
                    new object[]
                    {
                    },
                };
            }
        }
    }
}
