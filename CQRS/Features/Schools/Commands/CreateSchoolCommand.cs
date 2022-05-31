using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Features.Schools.Commands
{
    public class CreateSchoolCommand : IRequest<ListOfSchool>
    {
        public string SchoolName { get; set; }
        public string Region { get; set; }
        public string SchoolNumber { get; set; }
        public string SchoolType { get; set; }

        public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, ListOfSchool>
        {
            private readonly ISchoolsService _schoolsService;
            public CreateSchoolCommandHandler(ISchoolsService schoolsService)
            {
                _schoolsService = schoolsService;
            }

            public async Task<ListOfSchool> Handle(CreateSchoolCommand command, CancellationToken cancellationToken)
            {
                var school = new ListOfSchool()
                {
                    SchooName = command.SchoolName,
                    Region = command.Region,
                    SchooNumber = command.SchoolNumber,
                    SchoolType = command.SchoolType
                };
                //throw new NotImplementedException();

                return await _schoolsService.CreateSchool(school);
            }
        }
        
    }
}
