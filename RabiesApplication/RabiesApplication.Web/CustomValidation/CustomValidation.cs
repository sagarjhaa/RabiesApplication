using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RabiesApplication.Models;
using RabiesApplication.Web.ViewModels;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace RabiesApplication.Models.CustomValidation
{
    public class IfVacinatedCheckDates : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var pet = Mapper.Map<AnimalFormViewModel,Animal>((AnimalFormViewModel)validationContext.ObjectInstance);

            if (!pet.IsVacinated)
            {
                if (!pet.VaccineDate.HasValue && !pet.VaccineExpirationDate.HasValue)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Remove Vaccination dates when pet not vaccinated");
            }

            if (!(pet.VaccineDate.HasValue && pet.VaccineExpirationDate.HasValue))
            {
                return new ValidationResult("Please enter Vaccination Date and  Expiration Date");
            }

            return ValidationResult.Success;
        }
    }
}
