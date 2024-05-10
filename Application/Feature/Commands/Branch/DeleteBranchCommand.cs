using Application.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.CQRS.Commands.Branch
{
    public class DeleteBranchCommand : IRequest<Response<int>>
    {
        public int Code { get; set; }
    }
}
