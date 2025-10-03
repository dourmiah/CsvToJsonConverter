
using Serilog;
using System.Text.Json;

namespace CsvToJsonConverter.Converter.Format
{
    public class JSONFile : IFile
    {
        private string[] _input;
        public string[] Input => _input;

        public string Output
        {
            get;
            set;
        }

        public JSONFile(string[] input)
        {
            _input = input;
        }

        /// <summary>
        /// Fonction de conversion d'un format CSV en format JSON 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Convert()
        {
            if (_input is null)
                return;

            try
            {
                // On regroupe les lignes par OrderId
                var rows = _input.Skip(1).Select(line => line.Split(',')).ToList();
                var groups = rows.GroupBy(row => row[0]).Select(group => new Order
                {
                    OrderId = group.Key,
                    CustomerName = group.First()[1],
                    Products = group.Select(row => new Product
                    {
                        ProductName = row[2],
                        Quantity = int.Parse(row[3]),
                        Price = decimal.Parse(row[4])
                    }).ToList()
                });

                // Génération du json
                Output = JsonSerializer.Serialize(groups, new JsonSerializerOptions { WriteIndented = true });

                // Vérification du json
                using var doc = JsonDocument.Parse(Output);
            }
            catch (Exception e)
            {
                Log.Error("Arrêt du programme : Erreur lors de la conversion du fichier.");
                throw new Exception(e.Message);
            }
        }
    }

    class Product
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set;}
    }
}
