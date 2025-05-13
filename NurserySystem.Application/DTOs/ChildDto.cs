using System.ComponentModel.DataAnnotations;
using NurserySystem.Application.Validators;
using NurserySystem.Domain.Enums;

namespace NurserySystem.Application.DTOs
{
    public record ChildDto
    {
        [Required]
        public int? ID { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string? FullName { get; set; }

        [Required]
        [FutureDateValidation]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(250)]
        public string? Allergies { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public string? Gender { get; set; }

        [EnumDataType(typeof(ChildStatus))]
        public string? Status { get; set; }

        [EnumDataType(typeof(BloodType))]
        public string? BloodType { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(300)]
        public string? Notes { get; set; }
    }

}