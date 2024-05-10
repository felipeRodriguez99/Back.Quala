using FluentValidation;

namespace Application.DTOs
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
    }

    public class CurrencyDtoValidator : AbstractValidator<CurrencyDto>
    {
        public CurrencyDtoValidator()
        {            
            RuleFor(x => x.Description).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Abbreviation).NotEmpty().MaximumLength(10);            
        }
    }
}
