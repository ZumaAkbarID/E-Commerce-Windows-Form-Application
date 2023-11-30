using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model.Entity
{
    public class Categories
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string Name { get; set; }
    }
}
