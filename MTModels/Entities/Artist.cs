using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTModels.Entities
{
    public class Artist : Base
    {
        public int ArtistID { get; set; }
        public string Title { get; set; }
        public string Bography { get; set; }
        public string ImageURL { get; set; }
        public string HeroURL { get; set; }
    }
}
