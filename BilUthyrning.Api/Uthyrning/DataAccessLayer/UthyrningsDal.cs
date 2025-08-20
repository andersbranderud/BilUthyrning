namespace Uthyrning.DataAccessLayer.Interfaces
{
    using System.Threading.Tasks;
    using BilUthyrning.ViewModels;

    /// <summary>
    /// Interface for the data access layer for car rentals.
    /// </summary>
    public class UthyrningsDal
    {
        public async Task<UthyrningsModel> RegistreraUthyrningAvBilAsync(UthyrningsModel uthyrning)
        {

        }
        public async Task<UthyrningsModel> HittaUthyrningMedBokningsnummerAsync(string bokningsNummer)
        {

        }

        //Prisberäkningsformlerna har två parametrar som kan variera: basDygnsHyra och
        //basKmPris
        // Eftersom formlerna readan har multiplar 1.3, 1.5 gör jag här antagandet att dessa kan variera
        // beroende på effectiveDate. Så vi kan skapa en tabell med företagspriser som är baserade på datum.
        // Tabell: BasPris ; kolumner BasPrisId, basDygnsHyra, basKmPris, effectiveDateFrom, effectiveDateTo
        public async Task<BasPrisModel> HittaBasPrisAsync(DateTime effectiveDate)
        {
            // Todo. Hämta data från databas, mappa via mapping layer från EntityFramework model till ViewModel
        }

    }
}