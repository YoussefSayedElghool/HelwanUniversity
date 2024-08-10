using EmployeeUnitOfWorkVersion.Business.Repository;
using HelwanUniversity.Core.Contracts.Repositories;
using HelwanUniversity.Core.Helpers;
using HelwanUniversity.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HelwanUniversity.Infrastructure.Caching
{
    public class StudentRepositoryCachingDecorator : IStudentRepository
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMemoryCache memoryCache;

        public StudentRepositoryCachingDecorator(IStudentRepository studentRepository, IMemoryCache memoryCache)
        {
            this.studentRepository = studentRepository;
            this.memoryCache = memoryCache;
        }
        public Response<Student> Delete(int id)
        {
            return studentRepository.Delete(id);
        }

        public Response<Student> Edit(Student item)
        {
            return studentRepository.Edit(item);
        }

        public Response<List<Student>> GetAll()
        {
            return memoryCache.GetOrCreate("GetAll_Students", entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromMinutes(1));
                return studentRepository.GetAll();
            });

        }

        public Response<Student> GetById(int id)
        {
            return memoryCache.GetOrCreate($"GetById_Students_{id}", entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromMinutes(1));
                return studentRepository.GetById(id);
            });
        }

        public Response<Student> Insert(Student item)
        {
            return studentRepository.Insert(item);
        }
    }
}
