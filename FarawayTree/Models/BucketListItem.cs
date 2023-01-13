using System.ComponentModel.DataAnnotations;

namespace FarawayTree.Models
{

    public class BucketListItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PeopleInvolved { get; set; }
        public string? Notes { get; set; }
        public string? Requirements { get; set; }
        public bool? IsCompleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime TargetCompletionDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ActualCompletionDate { get; set; }
        public string? Location { get; set; }
        public decimal Cost { get; set; }
    }
}