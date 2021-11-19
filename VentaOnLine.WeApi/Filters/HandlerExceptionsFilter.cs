using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using VentaOnLine.Application.Common.Exceptions;

namespace VentaOnLine.WeApi.Filters
{
    public class HandlerExceptionsFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception as ValidationException != null)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);

                if (!string.IsNullOrWhiteSpace(context.Exception.Message))
                {
                    context.Response.Content = new StringContent(context.Exception.Message);
                }
            }
            else
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

           

            
        }
    }
}