using System.ComponentModel.DataAnnotations;
using BilUthyrning.Enums;
namespace BilUthyrning.ViewModels
{
    public class UthyrningsModel
    {
        [Required]
        public required string Bokningsnummer { get; set; }

        // Egenskaper för bil
        [Required]
        public required string RegistreringsNummerBil { get; set; }

        [Required]
        public BilKategoriEnum BilKategori { get; set; }

        [Required]
        public required string KundPersonnummer { get; set; }

        public DateTime DatumTidpunktUtlamning { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Mätarställningen måste vara ett icke-negativt tal.")]
        public int AktuellMatarstallningUthyrning { get; set; }

        // Inlämning, följande tre egenskaper sätts endast vid inlämning av bil.
        public DateTime? DatumTidpunktInlamning { get; set; }

        public int? AktuellMatarstallningInlamning { get; set; }
        
        public decimal? BeraknatPrisUthyrning { get; set; }
    }
}