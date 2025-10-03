
namespace CsvToJsonConverter.Converter.Format
{
    public class JSONCreator : Creator
    {
        public override IFile Create(string[] content)
        {
            return new JSONFile(content);
        }
    }
}
