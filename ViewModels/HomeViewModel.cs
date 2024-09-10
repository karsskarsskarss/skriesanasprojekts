using mvcprojekts.Models;

namespace mvcprojekts.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Club> Clubs { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
