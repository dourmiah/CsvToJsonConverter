
namespace CsvToJsonConverter.Converter
{
    public interface IFile
    {
        public string[] Input { get; }
        public string Output { get; set; }

        void Convert();
    }
}
