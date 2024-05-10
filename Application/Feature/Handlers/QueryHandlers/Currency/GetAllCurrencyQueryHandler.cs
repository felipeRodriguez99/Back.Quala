using Application.CQRS.Queries.Currency;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Handlers.QueryHandlers.Currency
{
    public class GetAllCurrencyQueryHandler : IRequestHandler<GetAllCurrencyQuery, Response<List<CurrencyDto>>>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public GetAllCurrencyQueryHandler(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }
        public async Task<Response<List<CurrencyDto>>> Handle(GetAllCurrencyQuery request, CancellationToken cancellationToken)
        {
            var currencies = await _currencyRepository.GetAllAsync();
            var currenciesDtos = _mapper.Map<List<CurrencyDto>>(currencies);
            return new Response<List<CurrencyDto>>(currenciesDtos);
        }
    }
}
