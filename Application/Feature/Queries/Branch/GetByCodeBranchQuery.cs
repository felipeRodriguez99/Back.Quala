using Application.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.CQRS.Queries.Branch
{
    public class GetByCodeBranchQuery : IRequest<Response<BranchDto>>
    {
        public int Code { get; set; }
    }
}
