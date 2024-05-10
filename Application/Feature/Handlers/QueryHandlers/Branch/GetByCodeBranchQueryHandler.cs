using Application.CQRS.Queries.Branch;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Handlers.QueryHandlers.Branch
{
    public class GetByCodeBranchQueryHandler : IRequestHandler<GetByCodeBranchQuery, Response<BranchDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetByCodeBranchQueryHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<Response<BranchDto>> Handle(GetByCodeBranchQuery request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdAsync(request.Code);
            var branchDto = _mapper.Map<BranchDto>(branch);
            return new Response<BranchDto>(branchDto);
        }
    }
}
