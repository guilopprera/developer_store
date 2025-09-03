using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, GetAllSalesPageResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<GetAllSalesPageResult> Handle(GetAllSalesCommand request, CancellationToken ct)
    {
        try
        {
            var validator = new GetAllSalesCommandValidator();
            var validation = await validator.ValidateAsync(request, ct);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var (items, total) = await _saleRepository.GetAllAsync(request.Page, request.Size, request.Order, ct);
            var data = _mapper.Map<List<GetAllSalesResult>>(items);

            var totalPages = (int)Math.Ceiling(total / (double)request.Size);

            return new GetAllSalesPageResult(data, total, request.Page, totalPages);
        }
        catch
        {
            throw new InvalidOperationException("Error retrieving sales list");
        }
    }
}
