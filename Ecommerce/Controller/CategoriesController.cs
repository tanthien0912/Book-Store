using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Model.Entity;
using Ecommerce.Helper;
using Ecommerce.Model.Repository;
using Ecommerce.Model.Context;
using System.Windows;

namespace Ecommerce.Controller
{
    public class CategoriesController
    {
        private CategoriesRepository _categoryRepository;
        private Categories category;

        public int Create(string CategoryName)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _categoryRepository = new CategoriesRepository(context);
                result = _categoryRepository.Create(CategoryName);
            }

            return result;
        }

        public int Update(Categories cat)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _categoryRepository = new CategoriesRepository(context);
                result = _categoryRepository.Update(cat);
            }

            return result;
        }

        public List<Categories> ReadAll()
        {
            List<Categories> list = new List<Categories>();
            using (DbContext context = new DbContext())
            {
                _categoryRepository = new CategoriesRepository(context);
                list = _categoryRepository.ReadAll();
            }
            return list;
        }

        internal int Delete(int Id)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _categoryRepository = new CategoriesRepository(context);
                result = _categoryRepository.Delete(Id);
            }

            return result;
        }
    }
}
