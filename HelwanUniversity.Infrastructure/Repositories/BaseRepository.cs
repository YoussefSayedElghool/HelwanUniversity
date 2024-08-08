
using HelwanUniversity.Core.Consts;
using HelwanUniversity.Core.Contracts.Repositories;
using HelwanUniversity.Core.Helpers;
using HelwanUniversity.Infrastructure.Data.EFCore;

namespace HelwanUniversity.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        AppDbContext context;
        public BaseRepository(AppDbContext _context)
        {
            context = _context;
        }


        public Response<T> GetById(int id)
        {
            if (id <= 0)
                return new Response<T>() { 
                    IsSuccess = false,
                    Message = ErrorMessageUserConst.IncorrectInput
                };

            var result = context.Set<T>().Find(id);

            return new Response<T>()
            {
                IsSuccess = true,
                Data = result
            };
        }
        public Response<List<T>> GetAll()
        {
            var result = context.Set<T>().ToList();

            if (result == null)
                return new Response<List<T>>()
                {
                    IsSuccess = false,
                    Message = ErrorMessageUserConst.IncorrectInput
                };

            return new Response<List<T>>()
            {
                IsSuccess = true,
                Data = result
            };
        }
        public Response<T> Delete(int id)
        {
            if (id <= 0)
                return new Response<T>()
                {
                    IsSuccess = false,
                    Message = ErrorMessageUserConst.IncorrectInput
                };

            Response<T> old = GetById(id);


            if (!old.IsSuccess)
                return old;

            if (old.Data == null)
                return new Response<T>()
                {
                    IsSuccess = false,
                    Message = ErrorMessageUserConst.NotFound
                };


            context.Set<T>().Remove(old.Data);


            return new Response<T>()
            {
                IsSuccess = true,
                Data = old.Data
            };
        }

        public Response<T> Edit(T item)
        {
            if (item == null)
                return new Response<T>()
                {
                    IsSuccess = false,
                    Message = ErrorMessageUserConst.IncorrectInput
                };

            context.Set<T>().Update(item);

            return new Response<T>()
            {
                IsSuccess = true,
                Data = item
            };
        }

        public Response<T> Insert(T item)
        {
            if (item == null)
                return new Response<T>()
                {
                    IsSuccess = false,
                    Message = ErrorMessageUserConst.IncorrectInput
                };

            context.Set<T>().Add(item);

            return new Response<T>()
            {
                IsSuccess = true,
                Data = item
            };
        }

    }
}
