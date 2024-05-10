using Application.CQRS.Commands.Branch;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Enitities;
using MediatR;

namespace Application.CQRS.Handlers.CommandHandlers
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Response<BranchDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        public UpdateBranchCommandHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public  async Task<Response<BranchDto>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var existingBranch = await _branchRepository.GetByIdAsync(request.Code);

            if (existingBranch == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el codigo {request.Code}");
            }
            else
            {
                request.CreatedDate = existingBranch.CreatedDate;
                _mapper.Map(request, existingBranch);

                await _branchRepository.UpdateAsync(existingBranch);
            }
            

            return new Response<BranchDto>(request, "Registro actualizada con exito");
        }
    }
}
