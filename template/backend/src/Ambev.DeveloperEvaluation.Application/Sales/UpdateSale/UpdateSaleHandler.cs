using MediatR;
using FluentValidation;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _repo;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken ct)
    {
        try
        {
            var validation = await new UpdateSaleValidator().ValidateAsync(command, ct);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var sale = await _repo.GetByIdWithItemsAsync(command.Id, ct)
                       ?? throw new KeyNotFoundException("Sale not found");

            if (sale.Cancelled)
                throw new InvalidOperationException("Cannot update a cancelled sale.");

            sale.UpdateHeader(command.CustomerName, command.Branch);

            var newItems = command.Items.Select(i => (i.ProductId, i.ProductName, i.UnitPrice, i.Quantity));
            sale.ReplaceItems(newItems);

            await _repo.UpdateAsync(sale, ct);

            return _mapper.Map<UpdateSaleResult>(sale);
        }
        catch
        {
            throw new InvalidOperationException("Error updating sale");
        }

    }
}
