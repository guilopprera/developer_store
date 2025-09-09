﻿using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartCommand : IRequest<DeleteCartResult>
{
    public Guid Id { get; }

    public DeleteCartCommand(Guid  id)
    {
        Id = id;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new DeleteCartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}