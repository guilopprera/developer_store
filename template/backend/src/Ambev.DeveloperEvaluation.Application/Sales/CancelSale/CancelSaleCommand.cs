﻿using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleCommand : IRequest<CancelSaleResult>
{
    public Guid Id { get; set; }
    public CancelSaleCommand() { }
    public CancelSaleCommand(Guid id) { Id = id; }

    public ValidationResultDetail Validate()
    {
        var validator = new CancelSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
