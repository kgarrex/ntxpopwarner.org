using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IDivisionService {
  public Task<List<Division>> GetAllAsync();
}

public class DivisionService : IDivisionService {
  private readonly AppDbContext _db;
  public DivisionService(AppDbContext db) => _db = db;

  public async Task<List<Division>> GetAllAsync() {
    var divisions = _db.Divisions;
    return await divisions.ToListAsync();
  }
}
