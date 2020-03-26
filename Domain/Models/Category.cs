using System.Collections.Generic;

namespace Shop.Api.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Good> Goods = new List<Good>();
    }
}