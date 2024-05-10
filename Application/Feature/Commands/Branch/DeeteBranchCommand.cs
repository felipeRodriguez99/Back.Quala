using Application.Wrappers;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Commands.Branch
{
    public class DeeteBranchCommand : IRequest<Response<int>>
    {
        public int Code { get; set; }
        public class DeeteBranchCommandValidator : AbstractValidator<DeeteBranchCommand>
        {            
            public DeeteBranchCommandValidator()
            {
                RuleFor(x => x.Code).GreaterThanOrEqualTo(1);
            }
        }
    }

}
