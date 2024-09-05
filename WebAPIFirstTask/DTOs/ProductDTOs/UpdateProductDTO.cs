namespace WebAPIFirstTask.DTOs.ProductDTOs;

public class UpdateProductDTO // This is same with Creation DTO but it should be written for further changes that will take place.
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}
