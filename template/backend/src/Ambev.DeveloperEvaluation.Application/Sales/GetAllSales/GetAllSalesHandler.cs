using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, List<GetAllSalesResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllSalesResult>> Handle(GetAllSalesCommand command, CancellationToken ct)
    {
        try
        {
            var validator = new GetAllSalesCommandValidator();
            var validation = await validator.ValidateAsync(command, ct);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var sales = await _saleRepository.GetAllAsync(ct);

            var page = command.Page <= 0 ? 1 : command.Page;
            var size = command.Size <= 0 ? 10 : command.Size;

            var paged = sales
                .OrderByDescending(s => s.Date)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            return _mapper.Map<List<GetAllSalesResult>>(paged);
        }
        catch
        {
            throw new InvalidOperationException("Error retrieving sales list");
        }
    }
}
