using System.ComponentModel.DataAnnotations;
namespace BilUthyrning.ViewModels
{
    public class AterlamningModel
    {
        [Required]
        public required string Bokningsnummer { get; set; }

        [Required]
        public required DateTime DatumTidpunktAterlamning { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Mätarställningen måste vara ett icke-negativt tal.")]
        public int AktuellMatarstallningAterlamning { get; set; }
    }
}
        