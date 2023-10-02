namespace Northwind_DBFirst.RequestModels
{
    public class ProductUpdateRequestModel
    {
        public int ID { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
