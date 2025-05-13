using NurserySystem.Domain.Enums;

namespace NurserySystem.Domain.Entities
{
    public class Child
    {
        public int ID { get; set; }
        public required string  FullName { get; set;}
        public DateTime DateOfBirth { get; set;}
        public string? Allergies { get; set; }

        public Gender Gender { get; set; }
        public ChildStatus Status { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
        public BloodType BloodType { get; set; }
    }
}