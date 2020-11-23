using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MiniOpenSource.Data.Repositories;
using MiniOpenSource.Data.Infrastructure;
using MiniOpenSource.Service;
using MiniOpenSource.Model.Model;

namespace MiniOpenSource.UnitTest.ServiceTest
{
	[TestClass]
	public class PostCategoryServiceTest
	{
		private Mock<IPostCategoryRepository> _mockPostRepository;
		private Mock<IUnitOfWork> _mockUnitOfWork;
		private IPostCategoryService _postCategoryService;
		private List<PostCategory> _listPostCategory;

		[TestInitialize]
		public void Initialize()
		{
			_mockPostRepository = new Mock<IPostCategoryRepository>();
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_postCategoryService = new PostCategoryService(_mockPostRepository.Object,_mockUnitOfWork.Object);
			_listPostCategory = new List<PostCategory>()
			{
				new PostCategory(){Name = "DM1", Status = true},
				new PostCategory(){Name = "DM2", Status = true},
				new PostCategory(){Name = "DM3", Status = true}
			};
		}
		[TestMethod]
		public void PostcategoryServiceGetAll()
		{
			//setup mothod
			_mockPostRepository.Setup(m => m.GetAll(null)).Returns(_listPostCategory);
			//call action
			var result = _postCategoryService.GetAll() as List<PostCategory>;
			//compare
			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count);
		}
		[TestMethod]
		public void PosCategory_Repository_Create() {
			PostCategory category = new PostCategory();
			category.Name = "Test category";
			category.Alias = "test-category";
			category.Status = true;
			_mockPostRepository.Setup(m => m.Add(category)).Returns((PostCategory p)=> {
				p.ID = 1;
				return p;
			});
			var res = _postCategoryService.Add(category);
			_mockUnitOfWork.Setup(m => m.Commit());
			Assert.IsNotNull(res);
			Assert.AreEqual(1, res.ID);
		}

	}
}
