using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationMedicineProject.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationMedicineController : ControllerBase
{
    private readonly DataContext _context;

    public RegistrationMedicineController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<RegistrationMedicine>>> GetRegistrationMedicines()
    {
        var medicines = await _context.RegistrationMedicines.Include(sh => sh.Retention).ToListAsync();
        return Ok(medicines);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RegistrationMedicine>> GetSingleMedicine(int id)
    {
        var medicine = await _context.RegistrationMedicines
        .Include(h => h.Retention)
        .FirstOrDefaultAsync(h => h.Id == id);
        if (medicine == null)
        {
            return NotFound("Medicamento não encontrado. :/");
        }
        return Ok(medicine);
    }

    [HttpGet("retentions")]
    public async Task<ActionResult<Retention>> GetRetentions()
    {
        var retentions = await _context.Retentions.ToListAsync();
        return Ok(retentions);
    }

    [HttpPost]
    public async Task<ActionResult<RegistrationMedicine>> CreateRegistrationMedicine(RegistrationMedicine medicine)
    {
        medicine.Retention = null;
        _context.RegistrationMedicines.Add(medicine);
        await _context.SaveChangesAsync();
        return Ok(await GetDbMedicines());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RegistrationMedicine>> UpdateRegistrationMedicine(RegistrationMedicine medicine, int id)
    {
        var dbMedicine = await _context.RegistrationMedicines
          .Include(sh => sh.Retention)
          .FirstOrDefaultAsync(sh => sh.Id == id);
        if (dbMedicine == null)
            return NotFound("Desculpe, medicamento não encontrado. :/");

        dbMedicine.Name = medicine.Name;
        dbMedicine.Administration = medicine.Administration;
        dbMedicine.Class = medicine.Class;
        dbMedicine.Classification = medicine.Classification;
        dbMedicine.RetentionId = medicine.RetentionId;

        await _context.SaveChangesAsync();
        return Ok(await GetDbMedicines());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<RegistrationMedicine>> DeleteRegistrationMedicine(int id)
    {
        var dbMedicine = await _context.RegistrationMedicines
          .Include(sh => sh.Retention)
          .FirstOrDefaultAsync(sh => sh.Id == id);
        if (dbMedicine == null)
            return NotFound("Desculpe, medicamento não encontrado. :/");

        _context.RegistrationMedicines.Remove(dbMedicine);
        await _context.SaveChangesAsync();
        return Ok(await GetDbMedicines());
    }

    private async Task<List<RegistrationMedicine>> GetDbMedicines()
    {
        return await _context.RegistrationMedicines.Include(sh => sh.Retention).ToListAsync();
    }
} 
    
