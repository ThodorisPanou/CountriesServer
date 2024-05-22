using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CountriesServer.DbContextClasses;
using CountriesServer.DTO;

public class CsvService
{
    private readonly ApplicationDbContext _context;

    public CsvService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task ImportCsvAsync(string filePath)
    {
        var tableName = "Countries"; 

        // if table exists
        if (_context.Countries.Count()>0)
        {
            var deleteTableQuery = $"DELETE FROM {tableName}";
            await _context.Database.ExecuteSqlRawAsync(deleteTableQuery);
            await _context.SaveChangesAsync();
            Console.WriteLine($"All data from table: {tableName} were succesfully updated.");
        }

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);

        csvConfiguration.TypeConverterCache.AddConverter<double>(new CustomDoubleConverter());

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, csvConfiguration))
        {
            var records = csv.GetRecords<Country>().ToList();
            _context.Countries.AddRange(records);
            await _context.SaveChangesAsync();
        }
    }
}


public class CustomDoubleConverter : DoubleConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            // Handle empty strings by returning a default value, 
            // you can return 0 or null or any other value based on your requirement.
            return 0.0;
        }

        // If the string is not empty, delegate to the base converter
        return base.ConvertFromString(text, row, memberMapData);
    }
}



