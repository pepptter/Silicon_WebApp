namespace Infrastructure.Entities;

public class AddressEntity
{
    public int Id { get; set; }
    public string Addressline_1 { get; set; } = null!;
    public string Addressline_2 { get; set; } = null!;
    public string Postalcode { get; set; } = null!;
    public string City { get; set; } = null!;
    
}