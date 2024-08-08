
using HelwanUniversity.Core.Consts;
using HelwanUniversity.Core.Contracts.Repositories;
using HelwanUniversity.Core.Contracts.UnitOfWork;
using HelwanUniversity.Core.Helpers;
using HelwanUniversity.Core.Models;
using HelwanUniversity.Infrastructure.Data.EFCore;

namespace HelwanUniversity.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        public UnitOfWork(AppDbContext context, IStudentRepository studentRepository)
        {
            _context = context;
            Student = studentRepository;

        }

        public IStudentRepository Student { get; private set; }

        public Response<bool> Save()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return new Response<bool>()
                    {
                        IsSuccess = true,
                        Data = true
                    };
                }
                catch (Exception)
                {
                    returnValue = false;
                    dbContextTransaction.Rollback();
                    return new Response<bool>()
                    {
                        IsSuccess = false,
                        Data = false,
                        Message = ErrorMessageUserConst.Unexpected
                    };
                }
            }

           
        }
    }
}
