using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Features.Schools.Queries
{
    public class GetAllSchoolsQuery : IRequest<IEnumerable<ListOfSchool>>
    {
        public class GetAllSchoolsQueryHandler : IRequestHandler<GetAllSchoolsQuery, IEnumerable<ListOfSchool>>
        {
            private readonly ISchoolsService _schoolService;

            public GetAllSchoolsQueryHandler(ISchoolsService schoolsService)
            {
                _schoolService = schoolsService;
            }

            public async Task<IEnumerable<ListOfSchool>> Handle(GetAllSchoolsQuery request, CancellationToken cancellationToken)
            {
                return await _schoolService.GetSchoolsList();
               // throw new NotImplementedException();
            }
        }
    }
}
