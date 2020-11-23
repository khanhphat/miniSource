using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniOpenSource.Data.Infrastructure;
using MiniOpenSource.Data.Repositories;
using MiniOpenSource.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.UnitTest.RepositoryTest
{
	[TestClass]
	public class PostCategoryRepositoryTest
	{
		IDBFactory dbFactory;
		IPostCategoryRepository objRepository;
		IUnitOfWork unitOfWork;

		[TestInitialize]
		public void Initialize()
		{
			dbFactory = new DbFactory();
			objRepository = new PostCategoryRepository(dbFactory);
			unitOfWork = new UnitOfWork(dbFactory);
		}

		//[TestMethod]
		//public void PostCategory_Repository_Create()
		//{
		//	PostCategory category = new PostCategory();
		//	category.Name = "Test category";
		//	category.Alias = "Test-category";
		//	category.Status = true;

		//	var result = objRepository.Add(category);
		//	unitOfWork.Commit();

		//	Assert.IsNotNull(result);
		//	Assert.AreEqual(1, result.ID);
		//}
	}
}
