using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public void BlogAdd(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogDelete(Blog blog)
		{
			_blogDal.Delete(blog);
		}

		public void BlogUpdate(Blog blog)
		{
			throw new NotImplementedException();
		}

        public List<Blog> GetBlogListWithCategory()
        {
			return _blogDal.GetListWithCategory();
        }

        public Blog GetById(int id)
		{
            return _blogDal.GetByID(id);
        }
		public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x=>x.BlogId == id);
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}
		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetListAll().TakeLast(3).ToList();
		}

        public void TAdd(Blog t)
        {
			_blogDal.Insert(t);
        }


        public void TDelete(Blog t)
        {
			_blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAllTs()
        {
            throw new NotImplementedException();
        }

        public Blog GetTById(int id)
        { return _blogDal.GetByID(id);
        }
    }
}
