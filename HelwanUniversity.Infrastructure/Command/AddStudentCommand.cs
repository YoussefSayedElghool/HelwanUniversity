using HelwanUniversity.Core.Contracts.UnitOfWork;
using HelwanUniversity.Core.Helpers;
using HelwanUniversity.Core.Models;
using HelwanUniversity.Infrastructure.UnitOfWork;
using MediatR;

namespace HelwanUniversity.Infrastructure.Query
{


    public class AddStudentCommand : IRequest<Response<Student>> {
        public Student Student{ get; private set; }
        public AddStudentCommand(Student student)
        {
            Student = student;
        }
    }

    public class AddStudentHandler : IRequestHandler<AddStudentCommand, Response<Student>>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddStudentHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<Response<Student>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var result = unitOfWork.Student.Insert(request.Student);
            unitOfWork.Save();
            return Task.FromResult(result);
        }

    }


}
