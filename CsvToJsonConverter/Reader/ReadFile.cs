using Serilog;

namespace CsvToJsonConverter.Reader
{
    public class ReadFile : IFileReader
    {
        string fileName = "orders.csv";

        /// <summary>
        /// Fonction de lecture du fichier d'entrée
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string[] Read(string filePath)
        {
            try
            {
                var path = Path.Combine(filePath, fileName);
                var _contentFile = File.ReadAllLines(path);
                return _contentFile;
            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error($"Arrêt du programme. Chemin non trouvé {filePath}");
                throw new Exception(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Log.Error($"Arrêt du programme. Pas de fichier trouvé à cet emplacement : {filePath}");
                throw new Exception(e.Message);
            }
        }
    }
}
