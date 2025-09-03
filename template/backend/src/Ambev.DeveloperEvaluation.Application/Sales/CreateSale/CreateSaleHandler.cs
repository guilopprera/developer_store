using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreateSaleHandler> _logger;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IUserRepository userRepository, ILogger<CreateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var customer = await _userRepository.GetByIdAsync(command.CustomerId, cancellationToken);

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            var sale = new Sale(command.CustomerId, customer.Username, command.Branch);

            foreach (var item in command.Items)
                sale.AddItem(item.ProductId, command.CustomerName, item.UnitPrice, item.Quantity);

            await _saleRepository.CreateAsync(sale, cancellationToken);

            _logger.LogInformation(
              "SaleCreated | SaleNumber={SaleNumber} | SaleId={SaleId} | CustomerId={CustomerId} | CustomerName={CustomerName} | Items={ItemCount} | Total={Total}",
              sale.SaleNumber, sale.Id, sale.CustomerId, sale.CustomerName, sale.Items.Count, sale.TotalAmount);

            return _mapper.Map<CreateSaleResult>(sale);

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error creating sale", ex);
        }

    }
}
