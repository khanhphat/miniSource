using MiniOpenSource.Data.Infrastructure;
using MiniOpenSource.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Data.Repositories
{
	//de dinh nghia cac phuong thuc khi them
	public interface IProductCategoryRepository : IRepository<ProductCategory>
	{
		IEnumerable<ProductCategory> GetByAlias(string alias);
	}
	public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
	{
		public ProductCategoryRepository(IDBFactory dbFactory)
			: base(dbFactory)
		{
		}
		public IEnumerable<ProductCategory> GetByAlias(string alias)
		{
			return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
		}
	}
}
