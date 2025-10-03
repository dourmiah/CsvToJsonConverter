using CsvToJsonConverter.Reader;
using CsvToJsonConverter.Writer;
using CsvToJsonConverter.Converter;
using CsvToJsonConverter.Converter.Format;
using Serilog;
using Serilog.Core;

namespace CsvToJsonConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mise en place des logs
            SetLogs();

            Log.Information("Démarrage du programme.");

            // Paths entrée/sortie obligatoires
            if (args.Length != 2)
            {
                Log.Error("Arrêt du programme: Erreur dans les paramètres de l'application.");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Lecture du fichier CSV
            Log.Information("Lecture du fichier CSV...");
            var content = new ReadFile().Read(inputPath);

            // Conversion CSV => JSON
            Log.Information("Conversion du fichier CSV...");
            var file = CallConverter(new JSONCreator(), content);

            // Ecriture du fichier de sortie
            Log.Information("Ecriture du fichier de sortie...");
            new WriteFile().Write(outputPath, file);

            Log.Information("Fin du programme.");
            Log.CloseAndFlush();
        }

        private static IFile CallConverter(Creator creator, string[] content)
        {
            return creator.ProcessFile(content);
        }

        private static void SetLogs()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
