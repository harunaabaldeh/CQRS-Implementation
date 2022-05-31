using CQRS.Data;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services
{
    public class SchoolsService : ISchoolsService
    {
        private readonly SchoolDbContext _context;

        public SchoolsService(SchoolDbContext context)
        {
                _context = context;
        }

        public async Task<ListOfSchool> CreateSchool(ListOfSchool school)
        {
            _context.ListOfSchools.Add(school);
            _ = await _context.SaveChangesAsync();
            return school;
            // throw new NotImplementedException();
        }

        public async Task<int> DeleteSchool(ListOfSchool school)
        {
            _context.ListOfSchools.Remove(school);
            return await _context.SaveChangesAsync();
            // throw new NotImplementedException();
        }

        public async Task<ListOfSchool> GetSchoolById(int id)
        {
            return await _context.ListOfSchools
           .FirstOrDefaultAsync(x => x.Id == id);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<ListOfSchool>> GetSchoolsList()
        {
            return await _context.ListOfSchools
            .ToListAsync();
            // throw new NotImplementedException();
        }

        public async Task<int> UpdateSchool(ListOfSchool school)
        {
            _context.ListOfSchools.Update(school);
            return await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
