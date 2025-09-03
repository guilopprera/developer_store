using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetAllSalesHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand command, CancellationToken ct)
    {
        try
        {
            var validator = new GetSaleCommandValidator();
            var validation = await validator.ValidateAsync(command, ct);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var sale = await _saleRepository.GetByIdAsync(command.Id, ct);
            if (sale is null)
                throw new KeyNotFoundException($"Sale with Id {command.Id} not found.");

            return _mapper.Map<GetSaleResult>(sale);
        }
        catch
        {
            throw new InvalidOperationException("Error retrieving sale");
        }

    }
}
