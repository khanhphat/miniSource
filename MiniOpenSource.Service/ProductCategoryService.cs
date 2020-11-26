using MiniOpenSource.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Service
{
	public interface IProductCategoryService
	{
		
	}
	public class ProductCategoryService : IProductCategoryService
	{
		private IProductCategoryService _productCategoryService;
		private IUnitOfWork _unitOfWork;
	}
}
