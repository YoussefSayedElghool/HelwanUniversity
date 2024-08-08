

using HelwanUniversity.Core.Contracts.Repositories;
using HelwanUniversity.Core.Models;
using HelwanUniversity.Infrastructure.Data.EFCore;
using HelwanUniversity.Infrastructure.Repositories;

namespace EmployeeUnitOfWorkVersion.Business.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}

