using Application.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.CQRS.Queries.Branch
{
    public class GetAllBranchQuery : IRequest<Response<List<BranchDto>>>
    {
    }
}
