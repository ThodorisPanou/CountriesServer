using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;

[Route("api/[controller]")]
[ApiController]
public class CsvController : ControllerBase
{
    private readonly CsvService _csvService;

    public CsvController(CsvService csvService)
    {
        _csvService = csvService;
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "data.csv");
        if (!System.IO.File.Exists(filePath))
            return NotFound("CSV file not found.");

        await _csvService.ImportCsvAsync(filePath);
        return Ok("Data imported successfully.");
    }

}

