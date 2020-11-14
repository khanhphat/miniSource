using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Data.Infrastructure
{
	public interface IDBFactory : IDisposable
	{
		MiniOSDbContext Init();//khoitao dbcontext
	}
}
