using MiniOpenSource.Data.Infrastructure;
using MiniOpenSource.Data.Repositories;
using MiniOpenSource.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Service
{
	public interface IPostCategoryService
	{
		PostCategory Add(PostCategory postCategory);
		void Update(PostCategory postCategory);
		PostCategory Delete(int id);
		IEnumerable<PostCategory> GetAll();
		IEnumerable<PostCategory> GetAllByParentId(int parentId);
		void Save();
	}
	public class PostCategoryService : IPostCategoryService
	{
		IPostCategoryRepository _postCategoryRepository;
		IUnitOfWork _unitOfWork;

		public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
		{
			this._postCategoryRepository = postCategoryRepository;
			this._unitOfWork = unitOfWork;
		}

		public PostCategory Add(PostCategory postCategory)
		{
			return _postCategoryRepository.Add(postCategory);
		}

		public void Update(PostCategory postCategory)
		{
			_postCategoryRepository.Update(postCategory);
		}

		public PostCategory Delete(int id)
		{
			return _postCategoryRepository.Delete(id);
		}

		public IEnumerable<PostCategory> GetAll()
		{
			return _postCategoryRepository.GetAll();
		}

		public IEnumerable<PostCategory> GetAllByParentId(int parentId)
		{
			return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}
	}
}
