
using BilUthyrning.Enums;
using BilUthyrning.ViewModels;
using Uthyrning.DataAccessLayer.Interfaces;

public class MockedUthyrningsDal : IUthyrningsDal
{
    // Dessa egenskaper används för att simulera databasen i testerna.
    public Task<BasPrisModel>? BasPrisModelInstance { get; set; }
    public Task<UthyrningsModel>? UthyrningsModelBookningsNummer { get; set; }
    public Task<UthyrningsModel>? UthyrningsModelRegistreraBil { get; set; }

    public Task<UthyrningsModel> RegistreraUthyrningAvBilAsync(UthyrningsModel uthyrning)
    {
        return UthyrningsModelRegistreraBil ?? Task.FromResult(new UthyrningsModel
        {
            Bokningsnummer = uthyrning.Bokningsnummer,
            RegistreringsNummerBil = uthyrning.RegistreringsNummerBil,
            BilKategori = uthyrning.BilKategori,
            KundPersonnummer = uthyrning.KundPersonnummer,
            DatumTidpunktUtlamning = uthyrning.DatumTidpunktUtlamning,
            DatumTidpunktInlamning = uthyrning.DatumTidpunktInlamning,
            AktuellMatarstallningUthyrning = uthyrning.AktuellMatarstallningUthyrning,
            AktuellMatarstallningInlamning = uthyrning.AktuellMatarstallningInlamning,
            BeraknatPrisUthyrning = uthyrning.BeraknatPrisUthyrning
        });
    }

    public Task<UthyrningsModel> HittaUthyrningMedBokningsNummerAsync(string bokningsNummer)
    {
        return UthyrningsModelBookningsNummer ?? Task.FromResult(new UthyrningsModel
        {
            Bokningsnummer = bokningsNummer,
            RegistreringsNummerBil = "ABC123",
            BilKategori = BilKategoriEnum.Kombi,
            KundPersonnummer = "19800101-1234",
            DatumTidpunktUtlamning = DateTime.Now,
            DatumTidpunktInlamning = DateTime.Now.AddDays(1),
            AktuellMatarstallningUthyrning = 10000,
            AktuellMatarstallningInlamning = 10500,
            BeraknatPrisUthyrning = 500m
        });
    }

    public Task<BasPrisModel> HittaBasPrisAsync(DateTime effectiveDate, BilKategoriEnum bilKategori)
    {
        return BasPrisModelInstance ?? Task.FromResult(new BasPrisModel
        {
            EffectiveDateFrom = effectiveDate,
            EffectiveDateTo = null,
            BasKmPris = 2.5m,
            BasDygnsHyra = 100m,
            BilKategori = bilKategori
        });
    }
}