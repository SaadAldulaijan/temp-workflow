namespace WebApplication3.Dtos;

public class OfferRequestInput
{
    public string? Description { get; set; }
}


public class  OfferRequestUpdateInput
{
    public int Id { get; set; }
    public string? Description { get; set; }

}