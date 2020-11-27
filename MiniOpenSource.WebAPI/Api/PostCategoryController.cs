using MiniOpenSource.Model.Model;
using MiniOpenSource.Service;
using MiniOpenSource.WebAPI.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiniOpenSource.WebAPI.Api
{
	[RoutePrefix("api/postcategory")]
	public class PostCategoryController : ApiControllerBase
	{
		IPostCategoryService _postCategoryService;

		/// <summary>
		/// PostCategoryController truyen bien tu con sang cha. 
		/// </summary>
		/// <param name="errorService"></param>
		public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService)
			: base(errorService)
		{
			this._postCategoryService = postCategoryService;
		}

		[Route("getall")]
		public HttpResponseMessage Get(HttpRequestMessage request)
		{
			return CreateHttpResponse(request, () =>
			{
				var listCategory = _postCategoryService.GetAll();
				HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
				return response;
			});
		}

		//post = create
		[Route("add")]
		public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				if (ModelState.IsValid)
				{//neu valid fials
					request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
				}
				else
				{/*neu thanh cong*/
					var category = _postCategoryService.Add(postCategory);
					_postCategoryService.Save();
					response = request.CreateResponse(HttpStatusCode.Created, category);
				}
				return response;
			});
		}

		//put = update
		[Route("update")]
		public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				if (ModelState.IsValid)
				{//neu valid fials
					request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
				}
				else
				{/*neu thanh cong*/
					_postCategoryService.Update(postCategory);
					_postCategoryService.Save();
					response = request.CreateResponse(HttpStatusCode.OK);
				}
				return response;
			});
		}

		public HttpResponseMessage Delete(HttpRequestMessage request, int id)
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				if (ModelState.IsValid)
				{//neu valid fials
					request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
				}
				else
				{/*neu thanh cong*/
					_postCategoryService.Delete(id);
					_postCategoryService.Save();
					response = request.CreateResponse(HttpStatusCode.OK);
				}
				return response;
			});
		}
	}
}
