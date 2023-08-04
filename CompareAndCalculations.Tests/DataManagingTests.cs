using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare.Tests
{
    public class DataManagingTests
    {
        [Fact]
        public void DataManaging_GetData_ReturnTrue()
        {
            //Arrange
            var dataManaging = new DataManaging();

            //Act
            var result = dataManaging.GetData(new string[]{"1","Dummy_Value","2","Dumber_Value","Gen","Random","Version","Random"}, "FMB001");
            var dummy = new Model("FMB001", new List<string>{"1", "2"}, new List<string>{ "Dummy_Value", "Dumber_Value" }, new List<string> { "Gen", "Version" }, new List<string> { "Random", "Random" });

            //Assert
            Assert.True(result.name == dummy.name && dummy.displayID.SequenceEqual(result.displayID) && dummy.displayValue.SequenceEqual(result.displayValue) && dummy.comparableID.SequenceEqual(result.comparableID) && dummy.comparableValue.SequenceEqual(result.comparableValue));
        }

        [Fact]
        public void DataManaging_getData_ReturnFalse()
        {
            //Arrange
            var dataManaging = new DataManaging();

            //Act
            var result = dataManaging.GetData(new string[] { "1", "Dummy_Value", "2", "Dumber_Value", "Gen", "4", "Version", "2" }, "FMB002");
            var dummy = new Model("FMB001", new List<string> { "1", "2" }, new List<string> { "Dummy_Value", "Dumber_Value" }, new List<string> { "Gen", "Version" }, new List<string> { "3", "1" });

            //Assert
            Assert.False(result.name == dummy.name && dummy.displayID.SequenceEqual(result.displayID) && dummy.displayValue.SequenceEqual(result.displayValue) && dummy.comparableID.SequenceEqual(result.comparableID) && dummy.comparableValue.SequenceEqual(result.comparableValue));
        }
    }
}
