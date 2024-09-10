using System.ComponentModel.DataAnnotations;
using System.Net;

namespace mvcprojekts.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
       
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
       
        //public ICollection<Club>? Clubs { get; set; }
        //public ICollection<Race>? Races { get; set; }

    }
}
