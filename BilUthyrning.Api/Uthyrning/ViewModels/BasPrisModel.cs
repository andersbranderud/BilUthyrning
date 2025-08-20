namespace BilUthyrning.ViewModels
{
    public class BasPrisModel
    {
        public required DateTime EffectiveDateFrom { get; set; }
        // Null betyder här att datumintervallet inte har något slutdatu.
        public DateTime? EffectiveDateTo { get; set; }
        public required decimal BasKmPris { get; set; }
        public required decimal basDygnsHyra { get; set; }
    }
}