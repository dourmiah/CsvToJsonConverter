# Application CsvToJsonConverter

Application console permettant de convertir un fichier au format CSV en un fichier au format JSON.

## Fonctionnalités

- Conversion de format CSV en format JSON

  <i>Hypothèse : La conversion en JSON est basée sur le format du fichier CSV en entrée (OrderId, CustomerName, ProductName, Quantity, Price).</i>

- Contrôle de validité du json
- Logs
- Conversion extensible à d'autres formats de fichiers :

  <i>Pour ajouter un nouveau format cible : Sur le modèle de la conversion en JSON, ajouter la logique de conversion dans un fichier <format_fichier>Creator.cs et un fichier <format_fichier>File.cs dans CsvToJsonConverter\Converter\Format.
  Exemple : XLSCreator.cs + XLSFile.cs</i>

## Technologies utilisées

- C# (.NET 8.0)
- Tests unitaires : `xUnit`.
  <i>Librairie moderne et préconisée par Microsoft pour faire des tests unitaires en .NET.</i>
- Logs : `Serilog`.
  <i>Librairie de logs moderne, éprouvée dans l'écosystème .NET et notamment dans les contextes de production.</i>

## Installation

1. Cloner le dépôt : https://github.com/dourmiah/CsvToJsonConverter.git
2. Ouvrir le projet dans l'IDE (Visual Studio ou Visual Studio Code)
3. Créer un répertoire pour stocker les fichiers de données (CSV, JSON). Exemple D:\Test
4. Copier le fichier orders.csv dans ce répertoire.
5. Ouvrir une console dans le répertoire du projet \CsvToJsonConverter
6. Pour lancer le programme, taper par exemple: `dotnet run D:\Test D:\Test`

## Utilisation (exécutable)

1. Ouvrir une console et aller dans le répertoire de l'application.
2. Lancer l’application en tapant le nom du programme, suivi du chemin vers le fichier d'entrée (CSV), suivi du chemin vers le fichier de sortie (JSON)

Exemple : `CsvToJsonConverter.exe D:\Test D:\Test`

<b>Le programme attend la saisie de deux paramètres obligatoires (chemin entrée + chemin sortie).
Le programme s'arrête si un seul ou les deux paramètres sont manquants ou invalides.</b>

## Tests unitaires

Les tests unitaires s'effectuent via le projet CsvToJsonConverterTest.

1. Ouvrir une console dans le répertoire du projet de test \CsvToJsonConverterTest
2. Taper : `dotnet test`

## Structure du projet

```plaintext
.
├── CsvToJsonConverter
│    │
│    ├── \Converter
│    │    ├── \Format
│    │    │     ├── JSONCreator.cs
│    │    │     └── JSONFile.cs
│    │    ├── Creator.cs
│    │    └── IFile.cs
│    ├── \Data
│    │    ├── orders.csv
│    │    └── output.json
│    ├── \Reader
│    │    ├── IReadFile.cs
│    │    └── ReadFile.cs
│    ├── \Writer
│    │    └── WriteFile.cs
│	 │
│    ├── \Logs
│	 │
│	 └── Program.cs
│
│
└── CsvToJsonConverterTest
	 │
	 ├── \Data
	 │	   ├── expected.json
	 │	   └── test_orders.csv
	 └── ConverterTests.cs   

```
