using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{//genericrepositoriden miras al ve ayrıca ıcategorydaldan da miras al ki erişim sağlayayım
    public class EfCategoryRepository : GenericRepository<Category>,ICategoryDal
    {
    }
}
