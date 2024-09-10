namespace mvcprojekts.ViewModels;

public class UserViewModel
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public int? Pace { get; set; }
    public int? Mileage { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string Location => (City, State) switch
    {
        (string city, string region) => $"{city}, {region}",
        (string city, null) => city,
        (null, string region) => region,
        (null, null) => "",
    };
}