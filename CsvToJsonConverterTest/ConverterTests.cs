namespace CsvToJsonConverterTest
{
    using CsvToJsonConverter;
    using CsvToJsonConverter.Converter.Format;

    public class ConverterTests
    {
        /// <summary>
        /// Test de la fonction Convert()
        /// </summary>
        [Fact]
        public void Convert_ShouldConvertCsvToJson()
        {
            string[] content = new string[] 
            {
                "OrderId,CustomerName,ProductName,Quantity,Price",
                "1001,Jane Doe,Laptop,1,1200",
                "1002,John Smith,Mouse,2,25",
                "1001,Jane Doe,Mouse,1,25",
                "1002,John Smith,Keyboard,1,80"
            };
            var file = new JSONFile(content);
            file.Convert();
            var result = file.Output;
            var expected = "[\r\n  {\r\n    \"OrderId\": \"1001\",\r\n    \"CustomerName\": \"Jane Doe\",\r\n    \"Products\": [\r\n      {\r\n        \"ProductName\": \"Laptop\",\r\n        \"Quantity\": 1,\r\n        \"Price\": 1200\r\n      },\r\n      {\r\n        \"ProductName\": \"Mouse\",\r\n        \"Quantity\": 1,\r\n        \"Price\": 25\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"OrderId\": \"1002\",\r\n    \"CustomerName\": \"John Smith\",\r\n    \"Products\": [\r\n      {\r\n        \"ProductName\": \"Mouse\",\r\n        \"Quantity\": 2,\r\n        \"Price\": 25\r\n      },\r\n      {\r\n        \"ProductName\": \"Keyboard\",\r\n        \"Quantity\": 1,\r\n        \"Price\": 80\r\n      }\r\n    ]\r\n  }\r\n]";
            Assert.Equal(expected, result);
        }
    }
}