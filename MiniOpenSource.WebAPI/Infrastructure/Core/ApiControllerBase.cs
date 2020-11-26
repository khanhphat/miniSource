using MiniOpenSource.Model.Model;
using MiniOpenSource.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiniOpenSource.WebAPI.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
		{
            this._errorService = errorService;
		}

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
		{
            //tao repon tra ve
            HttpResponseMessage response = null;
			try
			{
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
			{
                //luu err lai
                LogError(dbEx);
                //dbEx.InnerException.Message : xu ly loi ben trong nen phai inner
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch(Exception ex)
			{
                //luu err lai
                LogError(ex);
                //BadRequest return 400
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
			}
            return response;
        }

        /// <summary>
        /// method ghi log
        /// </summary>
        /// <param name="ex"></param>
        private void LogError(Exception ex)
		{
            try
			{
                Error error = new Error();
                error.CreatedDate = DateTime.Now;
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                _errorService.Create(error);
                _errorService.Save();
			}
            catch 
            { 
            }
		}
    }
}
