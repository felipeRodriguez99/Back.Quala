using Application.DTOs;
using Application.Wrappers;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Commands.Branch
{
    public class UpdateBranchCommand : BranchDto , IRequest<Response<BranchDto>>
    {
        public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
        {
            private readonly BranchDtoValidator _branchDtoValidator;

            public UpdateBranchCommandValidator(BranchDtoValidator branchDtoValidator)
            {
                _branchDtoValidator = branchDtoValidator;
                Include(_branchDtoValidator);
            }
        }
    }
}
