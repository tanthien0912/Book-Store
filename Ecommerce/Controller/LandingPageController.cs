using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using Ecommerce.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Ecommerce.Controller
{
    public class LandingPageController
    {
        private ProductsRepository _productRepository;
        private CategoriesRepository _categoryRepository;

        private Categories category;
        private Products product;

        public List<Products> ReadAllCategoriesProducts()
        {
            List<Products> list = new List<Products>();
            using (DbContext context = new DbContext())
            {
                _productRepository = new ProductsRepository(context);
                list = _productRepository.ReadAllCategoriesProducts();
            }
            return list;
        }

        public int CountCategoriesHasProduct()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _productRepository = new ProductsRepository(context);
                result = _productRepository.CountCategoryHasProduct();
            }
            return result;
        }
    }
}
