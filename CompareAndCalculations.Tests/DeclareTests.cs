using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compare;

namespace Compare.Tests
{
    public class DeclareTests
    {
        [Theory]
        [InlineData("")]                                // Null Path
        [InlineData("Fake\\Path\\That\\Doesnt\\Exist")] // Nonexistant directory
        [InlineData("C:\\Ušėrs\\Ušęr\\Dęšktop")]        // Path with special characters
        [InlineData("C:")]                              // Existing directory without .cfg files
        public void Declare_IsValidFilePath_ReturnFalse(string invalidPath)
        {
            //Arrange
            var declare = new Declare();

            //Act
            var result = declare.IsValidFilePath(invalidPath);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Declare_IsValidFilePath_ReturnTrue()
        {
            //Arrange
            var declare = new Declare();

            //Act
            var result = declare.IsValidFilePath(@"C:\Users\iot2\Desktop\PraktikosUzdaviniai\2Uzduotis\CgfToolWIthApi\data");

            //Assert
            Assert.True(result);
        }
    }
}
