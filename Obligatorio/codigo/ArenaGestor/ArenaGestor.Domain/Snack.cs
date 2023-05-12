using ArenaGestor.BusinessHelpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArenaGestor.Domain
{
    public class Snack
    {
        public int SnackId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public float Price { get; set; }

        public void ValidSnack() 
        {
            if (!CommonValidations.ValidRequiredString(this.Name))
            {
                throw new ArgumentException("The snack name is required");
            }
            if (!CommonValidations.ValidRequiredString(this.Description))
            {
                throw new ArgumentException("The snack Description is required");
            }
            if (this.Price < 1) 
            {
                throw new ArgumentException("The snack price must be greater than 1");
            }
        }
    }
}
