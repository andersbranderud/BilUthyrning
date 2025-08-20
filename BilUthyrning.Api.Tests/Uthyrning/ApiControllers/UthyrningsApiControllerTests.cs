namespace Uthyrning.ApiControllerTests
{
    using BilUthyrning.Api.ApiControllers;
    using BilUthyrning.Api.Services.Interfaces;
    using BilUthyrning.Enums;
    using BilUthyrning.ViewModels;
    using System.Threading.Tasks;
    using Uthyrning.BusinessLayer;
    using Xunit;

    public class UthyrningsApiControllerTests
    {
        [Fact]
        public async Task RegistreraUtlamningAvBil_ValidModel_VerifieraReturneradModell()
        {
            var uthyrningsModel = new UthyrningsModel
            {
                Bokningsnummer = "12345",
                RegistreringsNummerBil = "ABC123",
                BilKategori = BilKategoriEnum.Kombi,
                KundPersonnummer = "19800101-1234",
                DatumTidpunktUtlamning = DateTime.Now,
                AktuellMatarstallningUthyrning = 10000,
                AktuellMatarstallningInlamning = 10500,
                BeraknatPrisUthyrning = 500m
            };
            // Arrange
            var mockedUthyrningsDal = new MockedUthyrningsDal
            {
                UthyrningsModelRegistreraBil = Task.FromResult(uthyrningsModel)
            };

            var uthyrningBL = new UthyrningBL(mockedUthyrningsDal);
            var uthyrningService = new UthyrningsService(uthyrningBL);
            var controller = new UthyrningsApiController(uthyrningService);

            // Act
            UthyrningsModel uthyrning = await controller.RegistreraUtlamningAvBil(uthyrningsModel);

            Assert.Equal(uthyrningsModel.Bokningsnummer, uthyrning.Bokningsnummer);
            Assert.Equal(uthyrningsModel.RegistreringsNummerBil, uthyrning.RegistreringsNummerBil);
            Assert.Equal(uthyrningsModel.BilKategori, uthyrning.BilKategori);
            Assert.Equal(uthyrningsModel.KundPersonnummer, uthyrning.KundPersonnummer);
            Assert.Equal(uthyrningsModel.DatumTidpunktUtlamning, uthyrning.DatumTidpunktUtlamning);
            Assert.Equal(uthyrningsModel.AktuellMatarstallningUthyrning, uthyrning.AktuellMatarstallningUthyrning);
            Assert.Null(uthyrning.DatumTidpunktInlamning); // Inlamningstidpunkt är inte satt vid uthyrning
            Assert.Null(uthyrning.BeraknatPrisUthyrning); // Beräknat pris är inte satt vid uthyrning
            Assert.Null(uthyrning.AktuellMatarstallningInlamning); // Inlamning mätarställning är inte satt vid uthyrning        
        }        
    }
}