namespace Uthyrning.DataAccessLayer.Interfaces
{
    using System.Threading.Tasks;
    using BilUthyrning.Enums;
    using BilUthyrning.ViewModels;

    /// <summary>
    /// Interface for the data access layer for car rentals.
    /// </summary>
    public class UthyrningsDal : IUthyrningsDal
    {
        // Todo implement real DAL, just temporary code to avoid errors
        public async Task<UthyrningsModel> RegistreraUthyrningAvBilAsync(UthyrningsModel uthyrning)
        {
            return await Task.FromResult(uthyrning);
        }
        public async Task<UthyrningsModel> HittaUthyrningMedBokningsNummerAsync(string bokningsNummer)
        {
            // Todo. Hämta data från databas, mappa via mapping layer från EntityFramework model till ViewModel
            var uthyrningsModel = new UthyrningsModel
            {
                Bokningsnummer = bokningsNummer,
                RegistreringsNummerBil = "ABC123",
                BilKategori = BilKategoriEnum.Kombi,
                KundPersonnummer = "19800101-1234",
                DatumTidpunktUtlamning = DateTime.Now.AddDays(-1),
                DatumTidpunktInlamning = DateTime.Now,
                AktuellMatarstallningUthyrning = 10000,
                AktuellMatarstallningInlamning = 10500,
                BeraknatPrisUthyrning = 500.00m
            };
            
            return await Task.FromResult(uthyrningsModel);
        }

        //Prisberäkningsformlerna har två parametrar som kan variera: basDygnsHyra och
        //basKmPris
        // Eftersom formlerna readan har multiplar 1.3, 1.5 gör jag här antagandet att dessa kan variera
        // beroende på effectiveDate. Så vi kan skapa en tabell med företagspriser som är baserade på datum.
        // Tabell: BasPris ; kolumner BasPrisId, basDygnsHyra, basKmPris, effectiveDateFrom, effectiveDateTo
        public async Task<BasPrisModel> HittaBasPrisAsync(DateTime effectiveDate, BilKategoriEnum bilKategori)
        {

            // Todo. Hämta data från databas, mappa via mapping layer från EntityFramework model till ViewModel
            var basPrisModel = new BasPrisModel
            {
                EffectiveDateFrom = effectiveDate,
                EffectiveDateTo = effectiveDate.AddDays(30), // Example: valid for 30 days
                BasKmPris = 2.50m, // Example price per km
                BasDygnsHyra = 300.00m, // Example daily rental price
                BilKategori = bilKategori
            };
            return await Task.FromResult(basPrisModel); 
        }
    }
}