using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Model.Entity;
using Ecommerce.Helper;
using Ecommerce.Model.Repository;
using Ecommerce.Model.Context;

namespace Ecommerce.Controller
{
    public class CategoriesController
    {
        private CategoriesRepository _categoryRepository;

        public int Create(string CategoryName)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _categoryRepository = new CategoriesRepository(context);
                result = _categoryRepository.Create(CategoryName);
            }

            return result;
        }
    }
}
