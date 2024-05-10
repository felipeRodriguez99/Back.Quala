using Application.CQRS.Commands.Branch;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Handlers.CommandHandlers
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Response<int>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        public DeleteBranchCommandHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var existingBranch = await _branchRepository.GetByIdAsync(request.Code);

            if (existingBranch == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el codigo {request.Code}");
            }
            else
            {
                await _branchRepository.DeleteAsync(existingBranch.Code);
                return new Response<int>(existingBranch.Code, "Registro eliminado");
            }
        }
    }
}
