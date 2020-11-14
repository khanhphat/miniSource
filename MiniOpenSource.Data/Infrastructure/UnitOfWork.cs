using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Data.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly IDBFactory dbFactory;
        private MiniOSDbContext dbContext;

        public UnitOfWork(IDBFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public MiniOSDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
