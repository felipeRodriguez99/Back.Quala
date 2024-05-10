using Application.CQRS.Commands.Branch;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Enitities;
using MediatR;

namespace Application.CQRS.Handlers.CommandHandlers
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Response<BranchDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        public CreateBranchCommandHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<Response<BranchDto>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            Branch branch = _mapper.Map<Branch>(request);
            branch.CreatedDate = DateTime.UtcNow;
            await _branchRepository.AddAsync(branch);            
            var result = _mapper.Map<BranchDto>(branch);
            return new Response<BranchDto>(result, "Registro creada con exito");
        }
    }
}
