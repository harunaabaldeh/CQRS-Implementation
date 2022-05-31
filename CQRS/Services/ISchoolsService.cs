using CQRS.Models;

namespace CQRS.Services
{
    public interface ISchoolsService
    {
        Task<IEnumerable<ListOfSchool>> GetSchoolsList();
        Task<ListOfSchool> GetSchoolById(int id);
        Task<ListOfSchool> CreateSchool(ListOfSchool school);
        Task<int> UpdateSchool(ListOfSchool school);
        Task<int> DeleteSchool(ListOfSchool school);
    }
}
