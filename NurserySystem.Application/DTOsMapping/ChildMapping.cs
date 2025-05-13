using NurserySystem.Application.DTOs;
using NurserySystem.Domain.Entities;
using NurserySystem.Domain.Enums;

namespace NurserySystem.Application.DTOsMapping
{
    public static class ChildMapping
    {
        public static Child ToEntity(this ChildDto dto)
        {
            return new Child
            {
                ID = dto.ID ?? 0,
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Gender = Enum.Parse<Gender>(dto.Gender),
                BloodType = Enum.Parse<BloodType>(dto.BloodType),
                Status = Enum.Parse<ChildStatus>(dto.Status),
                Address = dto.Address,
                Allergies = dto.Allergies,
                Notes = dto.Notes
            };
        }

        public static Child ToEntity(this ChildDto dto, ref Child child)
        {
            child.FullName = dto.FullName;
            child.DateOfBirth = dto.DateOfBirth;
            child.Gender = Enum.Parse<Gender>(dto.Gender);
            child.BloodType = Enum.Parse<BloodType>(dto.BloodType);
            child.Status = Enum.Parse<ChildStatus>(dto.Status);
            child.Address = dto.Address;
            child.Allergies = dto.Allergies;
            child.Notes = dto.Notes;

            return child;
        }

        public static ChildDto ToDto(this Child entity)
        {
            return new ChildDto
            {
                ID = entity.ID,
                FullName = entity.FullName,
                DateOfBirth = entity.DateOfBirth,
                Gender = entity.Gender.ToString(),
                BloodType = entity.BloodType.ToString(),
                Status = entity.Status.ToString(),
                Address = entity.Address,
                Allergies = entity.Allergies,
                Notes = entity.Notes
            };
        }
    }

}