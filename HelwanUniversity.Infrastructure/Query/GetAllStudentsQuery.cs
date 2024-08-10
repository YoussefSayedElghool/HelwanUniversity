using HelwanUniversity.Core.Contracts.UnitOfWork;
using HelwanUniversity.Core.Helpers;
using HelwanUniversity.Core.Models;
using HelwanUniversity.Infrastructure.UnitOfWork;
using MediatR;

namespace HelwanUniversity.Infrastructure.Query
{


    public class GetAllStudentsQuery : IRequest<Response<List<Student>>> { }

    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, Response<List<Student>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllStudentsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<Response<List<Student>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(unitOfWork.Student.GetAll());
        }
    }


}
