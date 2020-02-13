using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BestPhoneNumber.Models
{
    public class TelecomHost
    {
        public TelecomHost()
        {

        }
        public TelecomHost(string name, int id)
        {
            Name = name;
            Id = id;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

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
