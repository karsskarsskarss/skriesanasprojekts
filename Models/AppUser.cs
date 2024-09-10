using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcprojekts.Models
{
    public class AppUser : IdentityUser
    {
        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        [ForeignKey ("Address")]
        public int? AddressId {  get; set; } 
        public Address? Address { get; set; }
        [Required]
        public ICollection<Club> Clubs { get; set; }
        [Required]
        public ICollection<Race> Races { get; set; }
       
    }
}
  