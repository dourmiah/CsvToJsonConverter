using CsvToJsonConverter;
using CsvToJsonConverter.Converter.Format;

namespace CsvToJsonConverterTest
{
    public class ConverterTests
    {
        /// <summary>
        /// Test de la fonction Convert()
        /// </summary>
        [Fact]
        public void Convert_ShouldConvertCsvToJson()
        {
            var csvPath = Path.Combine("Data", "test_orders.csv");
            var jsonPath = Path.Combine("Data", "expected.json");

            var csv = File.ReadAllLines(csvPath);
            var expected = File.ReadAllText(jsonPath);

            var file = new JSONFile(csv);
            file.Convert();
            var result = file.Output;
            Assert.Equal(expected, result);
        }
    }
}