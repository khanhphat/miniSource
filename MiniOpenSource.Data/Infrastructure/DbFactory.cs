using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Data.Infrastructure
{
	public class DbFactory : Disposable, IDBFactory
	{
		MiniOSDbContext dbContext;

		public MiniOSDbContext Init()
		{
			//neu dbContext null thi khoi tao
			return dbContext ?? (dbContext = new MiniOSDbContext());
		}
		//neukhac null thi Dispose
		protected override void DisposeCore()
		{
			if (dbContext != null)
				dbContext.Dispose();
		}
	}
}
