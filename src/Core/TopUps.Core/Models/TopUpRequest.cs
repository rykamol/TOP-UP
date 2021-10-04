using System;
using System.ComponentModel.DataAnnotations;

public class TopUpRequest
{
    [Key]
    public string MessageId { get; set; }


    [MaxLength(3),MinLength(3)]
    public string Identifier { get; set; }


    [MaxLength(8),MinLength(8)]
    public string MessageDate { get; set; }


    [MaxLength(6),MinLength(6)]
    public string MessageTime { get; set; }


    [MaxLength(12), MinLength(12)]
    public string PhoneNo { get; set; }


    [MaxLength(10), MinLength(10)]
    public int Amount { get; set; }
}
