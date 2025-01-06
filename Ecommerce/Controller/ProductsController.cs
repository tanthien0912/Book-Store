using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using Ecommerce.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Ecommerce.Controller
{
    public class ProductsController
    {
        private ProductsRepository _productRepository;
        private CategoriesRepository _categoryRepository;

        private Categories category;
        private Products product;

        public int Create(Products p)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _productRepository = new ProductsRepository(context);
                result = _productRepository.Create(p);
            }

            return result;
        }

        public int Update(Products p)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _productRepository = new ProductsRepository(context);
                result = _productRepository.Update(p);
            }

            return result;
        }

        public List<Categories> ReadAllCategory()
        {
            List<Categories> list = new List<Categories>();
            using (DbContext context = new DbContext())
            {
                _categoryRepository = new CategoriesRepository(context);
                list = _categoryRepository.ReadAll();
            }
            return list;
        }

        public int Delete(int Id)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _productRepository = new ProductsRepository(context);
                result = _productRepository.Delete(Id);
            }
            return result;
        }

        public List<Products> ReadAll()
        {
            List<Products> list = new List<Products>();
            using (DbContext context = new DbContext())
            {
                _productRepository = new ProductsRepository(context);
                list = _productRepository.ReadAll();
            }
            return list;
        }

        public Products ReadDetailProduct(int Id)
        {
            Products list = new Products();
            using (DbContext context = new DbContext())
            {
                _productRepository = new ProductsRepository(context);
                list = _productRepository.ReadDetailProduct(Id);
            }
            return list;
        }
    }
}
