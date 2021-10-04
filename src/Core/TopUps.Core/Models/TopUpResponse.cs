using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopUps.Core.Models
{
    public class TopUpResponse
    {
        [Key]
        public string MessageId { get; set; }


        [MaxLength(8), MinLength(8)]
        public string MessageDate { get; set; }


        [MaxLength(6), MinLength(6)]
        public string MessageTime { get; set; }


        [MaxLength(12), MinLength(12)]
        public string PhoneNo { get; set; }


        [MaxLength(10), MinLength(10)]
        public int Amount { get; set; }


        public int TransactionId { get; set; }

        public int TransactionNo { get; set; }


        [MaxLength(2), MinLength(2)]

        public string Result { get; set; }


    }
}
