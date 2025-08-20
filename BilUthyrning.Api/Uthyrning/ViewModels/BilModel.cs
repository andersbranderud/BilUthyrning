using System.ComponentModel.DataAnnotations;
using BilUthyrning.Enums;

namespace BilUthyrning.ViewModels
{
    public class Bil
    {
        [Required]
        public required string RegistreringsNummer { get; set; }

        [Required]
        public BilKategoriEnum BilKategori { get; set; }
    }
}