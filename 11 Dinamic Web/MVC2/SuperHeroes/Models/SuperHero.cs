using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroes.Models
{
    public class SuperHero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Te devi meter el Nome! Sempio!")]
        [Display(Name = "El nome de figon")]
        public string Name { get; set; }

        [Display(Name = "El nome sconto")]
        // this attribute is queried when the View has "<label asp-for="SecretName">
        // if this attribute is found, its 'Name' property is displayed
        // otherwise the actual name of the property is used ('SecretName')

        // in a multi-language app, I would not put a hardcoded value
        // but a reference to a resource file with a specific language.
        public string SecretName { get; set; }

        [EmailAddress]
        [Display(Name = "Come te lo ciami")]
        public string Email { get; set; }

        [Display(Name = "Quando che el xè nato")]
        public DateTime Birth { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Quanto che el pesta")]
        public int Strength { get; set; }

        [Display(Name = "Quanti bori che el ga")]
        public double Wealth { get; set; }

        [Display(Name = "El svola o no")]
        public bool CanFly { get; set; }
    }
}
