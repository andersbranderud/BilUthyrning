using BilUthyrning.Enums;

namespace BilUthyrning.ViewModels
{
    public class BasPrisModel
    {
        public required DateTime EffectiveDateFrom { get; set; }
        // Null betyder här att datumintervallet inte har något slutdatu.
        public DateTime? EffectiveDateTo { get; set; }
        public required decimal BasKmPris { get; set; }
        public required decimal BasDygnsHyra { get; set; }
        public required BilKategoriEnum BilKategori { get; set; }
    }
}