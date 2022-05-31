using CQRS.Services;
using MediatR;

namespace CQRS.Features.Schools.Commands
{
    public class DeleteSchoolCommand : IRequest<int>
    {
     public int Id { get; set; }

        public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand, int>
        {
            private readonly ISchoolsService _schoolsService;

            public DeleteSchoolCommandHandler(ISchoolsService schoolsService)
            {
                _schoolsService = schoolsService;
            }
            public async Task<int> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
            {
                var school = await _schoolsService.GetSchoolById(request.Id);
                if (school == null)
                    return default;

                return await _schoolsService.DeleteSchool(school);
                // throw new NotImplementedException();
            }
        }

    }
}
