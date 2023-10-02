namespace Northwind_DBFirst.ResponseModels
{
    public class ProductResponseModel
    {
        public int ID { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
