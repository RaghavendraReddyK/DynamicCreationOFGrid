namespace DynamicGridDemo.Model
{
	public class ProductAttribute
	{
        public int Id { get; set; }
        public int ProductId { get; set; }
		public string Key { get; set; }
		public string Value { get; set; } = string.Empty;
	}
}
