using MTModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTModels.DTOs
{
    public class GetArtistDto
    {
        public GetArtistDto()
        {
            Artists = new List<Artist>();
        }
        public List<Artist> Artists { get; set; }
    }
}
