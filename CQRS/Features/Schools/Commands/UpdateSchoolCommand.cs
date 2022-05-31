using CQRS.Services;
using MediatR;

namespace CQRS.Features.Schools.Commands
{
    public class UpdateSchoolCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Region { get; set; }
        public string SchoolNumber { get; set; }
        public string SchoolType { get; set; }


        public class UpdateSchoolCommadHandler : IRequestHandler<UpdateSchoolCommand, int>
        {
            private readonly ISchoolsService _schoolsSerive;

            public UpdateSchoolCommadHandler(ISchoolsService schoolsService)
            {
                _schoolsSerive = schoolsService;
            }
            public async Task<int> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
            {
                var school = await _schoolsSerive.GetSchoolById(request.Id);
                if (school == null)
                    return default;

                school.SchooName = request.SchoolName;
                school.Region = request.Region;
                school.SchooNumber = request.SchoolNumber;
                school.SchoolType = request.SchoolType;
                //throw new NotImplementedException();

                return await _schoolsSerive.UpdateSchool(school);
            }
        }

    }
}
