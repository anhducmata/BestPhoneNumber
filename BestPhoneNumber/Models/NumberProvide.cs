using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestPhoneNumber.Models
{
    public class NumberProvide
    {
        public NumberProvide()
        {
        }

        public NumberProvide(int telecomHostId, int id, string prefixNumber)
        {
            TelecomHostId = telecomHostId;
            Id = id;
            PrefixNumber = prefixNumber;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int TelecomHostId { get; set; }
        public string PrefixNumber { get; set; }
    }
}