using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebBid.Models.Validators;

namespace WebBid.Models.Entities
{
    [PlayerValidator]
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [DecimalRangeValidator(1.0, 10000000, 2)]
        [Display(Name = "Amount of chips")]
        public decimal Account { get; set; }

        public BiddingState BiddingState { get; set; }

        [NotMapped]
        public Guid PlayerGuid { get; set; }
    }
}