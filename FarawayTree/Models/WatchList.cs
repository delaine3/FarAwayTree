using System.ComponentModel.DataAnnotations;

namespace FarawayTree.Models
{
    public class WatchList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type{ get; set; }
        public bool OnAir { get; set; }
        [DataType(DataType.Date)]
        public DateTime SeasonStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime SeasonEnd { get; set; }
        public bool Watched { get; set; }
    }
}
