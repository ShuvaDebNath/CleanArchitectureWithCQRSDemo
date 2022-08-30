using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Common.MVC
{
    internal class ExceptionFilter  : ExceptionFilterAttribute
    {
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        public ExceptionFilter(ProblemDetailsFactory problemDetailsFactory)
        {
            _problemDetailsFactory = problemDetailsFactory;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            if (!context.ExceptionHandled)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var message = context.Exception.Message;
                ProblemDetails problem = null!;

                if (context.Exception is ValidationException vex)
                {
                    statusCode = (int) HttpStatusCode.BadRequest;

                    problem = _problemDetailsFactory.CreateValidationProblemDetails(
                        context.HttpContext,
                        context.ModelState,
                        statusCode,
                        message,
                        detail: context.Exception.StackTrace);
                }
                else
                {
                    problem = _problemDetailsFactory.CreateProblemDetails(
                        context.HttpContext,
                        statusCode,
                        message,
                        detail: context.Exception.StackTrace);
                }

                context.Result = new ObjectResult(problem);
                context.ExceptionHandled = true;
            }
        }
    }
}
