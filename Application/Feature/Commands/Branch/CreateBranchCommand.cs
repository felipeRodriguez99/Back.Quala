using Application.DTOs;
using Application.Wrappers;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Commands.Branch
{
    public class CreateBranchCommand : BranchDto , IRequest<Response<BranchDto>>
    {
        public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
        {
            private readonly BranchDtoValidator _branchDtoValidator;

            public CreateBranchCommandValidator(BranchDtoValidator branchDtoValidator)
            {
                _branchDtoValidator = branchDtoValidator;
                Include(_branchDtoValidator);
            }
        }
    }
}
