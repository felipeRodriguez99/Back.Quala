using FluentValidation;

namespace Application.DTOs
{
    public class BranchDto
    {
        public int Code { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Identifications { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int CurrencyId { get; set; }        
    }

    public class BranchDtoValidator : AbstractValidator<BranchDto>
    {
        public BranchDtoValidator() 
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Identifications).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CurrencyId).GreaterThanOrEqualTo(1);
        }
    }
}
