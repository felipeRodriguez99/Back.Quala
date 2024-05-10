using Application.DTOs;
using Application.Wrappers;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Queries.Currency
{
    public class GetAllCurrencyQuery : IRequest<Response<List<CurrencyDto>>>
    {
    }
}
