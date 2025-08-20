namespace Uthyrning.DataAccessLayer.Interfaces
{
    using BilUthyrning.ViewModels;
    using System.Threading.Tasks;

    public interface IUthyrningsDal
    {
        // Registrera utlamning av bil. Används för att skriva till DB både vit uthyrning och återlämning.
        Task<UthyrningsModel> RegistreraUthyrningAvBilAsync(UthyrningsModel uthyrning);

        // Hitta bokningen baserat på bokningsnummer.
        Task<UthyrningsModel> HittaUthyrningMedBokningsNummerAsync(string bokningsNummer);

        /// Hitta baspriset baserat på datum
        Task<BasPrisModel> HittaBasPrisAsync(DateTime effectiveDate); 
        
    }
}