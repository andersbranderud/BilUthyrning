namespace Uthyrning.BusinessLayer.TestHelpers
{
    using UthyrningKalkylator = Uthyrning.BusinessLayer.Helpers.UthyrningKalkylator;
    using BilUthyrning.Enums;
    public class UthyrningKalkylatorTest
    {
        [Fact]
        public void BeraknaKostnadAsync_ValidInputsForKombi_ReturnsCorrectCost()
        {
            // Arrange
            int antalDygn = 5;
            decimal basDygnsHyra = 100m;
            decimal basKmPris = 2m;
            int antalKm = 300;
            BilKategoriEnum bilKategory = BilKategoriEnum.Kombi;

            // Act
            decimal result = UthyrningKalkylator.BeraknaKostnadAsync(antalDygn, basDygnsHyra, basKmPris, antalKm, bilKategory);

            // Assert
            decimal forvantadKostnad = (basDygnsHyra * antalDygn * UthyrningKalkylator.KombiMultiplikator) + (basKmPris * antalKm);
            Assert.Equal(forvantadKostnad, result);
        }
        
        [Fact]
        public void BeraknaKostnadAsync_ValidInputsForLastbil_ReturnsCorrectCost()
        {
            // Arrange
            int antalDygn = 3;
            decimal basDygnsHyra = 150m;
            decimal basKmPris = 3m;
            int antalKm = 200;
            BilKategoriEnum bilKategory = BilKategoriEnum.Lastbil;

            // Act
            decimal result = UthyrningKalkylator.BeraknaKostnadAsync(antalDygn, basDygnsHyra, basKmPris, antalKm, bilKategory);

            // Assert
            decimal forvantadKostnad = (basDygnsHyra * antalDygn * UthyrningKalkylator.LastbilMultiplikator) + (basKmPris * antalKm * UthyrningKalkylator.LastbilMultiplikator);
            Assert.Equal(forvantadKostnad, result);
        }

        [Fact]
        public void BeraknaKostnadAsync_ValidInputsForSmabil_ReturnsCorrectCost()
        {
            // Arrange
            int antalDygn = 2;
            decimal basDygnsHyra = 80m;
            decimal basKmPris = 1.5m;
            int antalKm = 100;
            BilKategoriEnum bilKategory = BilKategoriEnum.Smabil;

            // Act
            decimal result = UthyrningKalkylator.BeraknaKostnadAsync(antalDygn, basDygnsHyra, basKmPris, antalKm, bilKategory);

            // Assert
            decimal forvantadKostnad = basDygnsHyra * antalDygn; // No km cost for Smabil
            Assert.Equal(forvantadKostnad, result);
        }


        [Fact]
        public void BeraknaKostnadAsync_InvalidInputs_ThrowsArgumentException()
        {
            // Arrange
            int antalDygn = -1; // Invalid input
            decimal basDygnsHyra = 100m;
            decimal basKmPris = 2m;
            int antalKm = 300;
            BilKategoriEnum bilKategory = BilKategoriEnum.Kombi;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => UthyrningKalkylator.BeraknaKostnadAsync(antalDygn, basDygnsHyra, basKmPris, antalKm, bilKategory));
        }
    }
}