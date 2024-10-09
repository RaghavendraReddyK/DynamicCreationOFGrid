using Microsoft.AspNetCore.Mvc;

namespace DynamicGridDemo.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public int Price { get; set; }
		public List<ProductAttribute>? Attributes { get; set; }
	}
}
