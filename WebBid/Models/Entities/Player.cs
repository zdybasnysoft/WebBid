using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBid.Models.Entities
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Display(Name = "Amount of chips")]
        public decimal Account { get; set; }

        public BiddingState BiddingState { get; set; }

        [NotMapped]
        public Guid PlayerGuid { get; set; }
    }
}