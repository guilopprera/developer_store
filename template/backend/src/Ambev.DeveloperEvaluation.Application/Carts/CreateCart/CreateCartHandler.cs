using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _repo;
    private readonly IMapper _mapper;
    public CreateCartHandler(ICartRepository repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

    public async Task<CreateCartResult> Handle(CreateCartCommand request, CancellationToken ct)
    {
        try
        {
            var validator = new CreateCartValidator();
            var validationResult = await validator.ValidateAsync(request, ct);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var entity = _mapper.Map<Cart>(request);
            entity = await _repo.CreateAsync(entity, ct);
            return _mapper.Map<CreateCartResult>(entity);
        }
        catch (ValidationException ex)
        {
            throw new InvalidOperationException("Error creating cart", ex);
        }
    }
}