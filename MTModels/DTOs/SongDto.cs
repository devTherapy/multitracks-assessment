using MTModels.Entities;

namespace MTModels.DTOs
{
    public class SongDto
    {
        public SongDto()
        {
            SongsList = new List<Song>();
        }
        public List<Song> SongsList { get; set; }
        public Metadata MetaData { get; set; }
    }
}
