using Application.CQRS.Queries.Branch;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Handlers.QueryHandlers.Branch
{
    public class GetAllBranchQueryHandler : IRequestHandler<GetAllBranchQuery, Response<List<BranchDto>>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetAllBranchQueryHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<BranchDto>>> Handle(GetAllBranchQuery request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllAsync();
            var branchesDtos = _mapper.Map<List<BranchDto>>(branches);
            return new Response<List<BranchDto>>(branchesDtos);
        }
    }
}
