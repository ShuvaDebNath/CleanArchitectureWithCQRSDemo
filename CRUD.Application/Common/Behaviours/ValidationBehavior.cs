using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace CRUD.Application.Common.Behaviours
{
    internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, new()
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle
            (TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            if (_validator is not null)
            {
                var result = await _validator.ValidateAsync(request, cancellationToken);
                if (!result.IsValid)
                {
                    var error = result.Errors.FirstOrDefault();
                    var errorMessage = error?.ErrorMessage;
                    var errorCode = error?.ErrorCode;
                    throw new ValidationException($"({errorCode}) {errorMessage}");
                }
            }

            return await next();
        }
    }
}
