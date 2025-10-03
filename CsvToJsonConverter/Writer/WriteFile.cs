using CsvToJsonConverter.Converter;
using Serilog;

namespace CsvToJsonConverter.Writer
{
    public class WriteFile
    {
		string fileName = "output.json";
		
		/// <summary>
		/// Fonction d'écriture du fichier de sortie
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="file"></param>
		/// <exception cref="Exception"></exception>
		public void Write(string filePath, IFile file)
        {
			if (string.IsNullOrEmpty(file.Output))
			{
				Log.Error("Arrêt du programme: Pas de donnée trouvée.");
				return;
			}

			try
			{
				var path = Path.Combine(filePath, fileName);
				File.WriteAllText(path, file.Output);
			}
            catch (DirectoryNotFoundException e)
            {
                Log.Error("Arrêt du programme: Répertoire du fichier de sortie non trouvé.");
                throw new Exception(e.Message);
            }
            catch (Exception e)
			{
                Log.Error($"Arrêt du programme: Erreur lors de l'écriture du fichier {fileName}");
                throw new Exception(e.Message);
			}
        }
    }
}
