﻿using System;
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

            // membuat objek context menggunakan blok using
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

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _categoryRepository = new CategoriesRepository(context);
                result = _categoryRepository.Update(cat);
            }

            return result;
        }

        public List<Categories> ReadAll()
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

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _categoryRepository = new CategoriesRepository(context);
                result = _categoryRepository.Delete(Id);
            }

            return result;
        }
    }
}
