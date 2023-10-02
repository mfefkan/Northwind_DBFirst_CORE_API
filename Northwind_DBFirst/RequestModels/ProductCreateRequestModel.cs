namespace Northwind_DBFirst.RequestModels
{
    public class ProductCreateRequestModel
    {
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

    }
}
