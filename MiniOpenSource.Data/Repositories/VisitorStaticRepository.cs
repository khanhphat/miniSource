using MiniOpenSource.Data.Infrastructure;
using MiniOpenSource.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Data.Repositories
{
	public interface IVisitorStaticRepository : IRepository<VisitorStatic>
	{

	}
	public class VisitorStaticRepository :RepositoryBase<VisitorStatic>, IVisitorStaticRepository
	{
		public VisitorStaticRepository(IDBFactory dbFactory) : base(dbFactory)
		{

		}
	}
}
