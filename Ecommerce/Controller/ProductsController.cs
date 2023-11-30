using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using Ecommerce.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _productRepository = new ProductsRepository(context);
                result = _productRepository.Create(p);
            }

            return result;
        }

        public int Update(Categories cat)
        {
            int result = 0;


            return result;
        }

        public List<Categories> ReadAllCategory()
        {
            // membuat objek collection
            List<Categories> list = new List<Categories>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _categoryRepository = new CategoriesRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _categoryRepository.ReadAll();
            }
            return list;
        }

        internal int Delete(int Id)
        {
            int result = 0;

            return result;
        }

        internal List<Products> ReadAll()
        {
            // membuat objek collection
            List<Products> list = new List<Products>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _productRepository = new ProductsRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _productRepository.ReadAll();
            }
            return list;
        }
    }
}
