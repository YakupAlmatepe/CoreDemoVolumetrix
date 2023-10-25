﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        public void AddCategory(Category category)
        {
            c.Add(category);
            c.SaveChanges();
        }

        public void Delete(Category t)
        {
            throw new NotImplementedException();
        }

        public void DeleteCateory(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }

        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public Category GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Category t)
        {
            throw new NotImplementedException();
        }

        public List<Category> ListAllCategory()
        {
            return c.Categories.ToList();
        }

        public void Update(Category t)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            c.Update(category);
            c.SaveChanges();
        }
    }
}
