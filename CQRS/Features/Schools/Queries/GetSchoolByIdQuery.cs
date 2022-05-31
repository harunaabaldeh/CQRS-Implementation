using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Features.Schools.Queries
{
    public class GetSchoolByIdQuery : IRequest<ListOfSchool>
    {
        public int Id { get; set; }

        public class GetSchoolByIdQueryHandler : IRequestHandler<GetSchoolByIdQuery, ListOfSchool>
        {
            private readonly ISchoolsService _schoolsService;

            public GetSchoolByIdQueryHandler(ISchoolsService schoolsService)
            {
                _schoolsService = schoolsService;
            }
            public async Task<ListOfSchool> Handle(GetSchoolByIdQuery request, CancellationToken cancellationToken)
            {
                return await _schoolsService.GetSchoolById(request.Id);
                //throw new NotImplementedException();
            }
        }

    }
}
