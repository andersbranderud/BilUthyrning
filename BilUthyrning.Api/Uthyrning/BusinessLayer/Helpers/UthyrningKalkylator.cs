namespace BusinessLayer.Helpers
{
    using System;
    using BilUthyrning.Enums;

    public class UthyrningKalkylator
    {
        public const decimal KombiMultiplikator = 1.3m;
        public const decimal LastbilMultiplikator = 1.5m;
        public static decimal BeraknaKostnadAsync(int antalDygn, decimal basDygnsHyra, decimal basKmPris, int antalKm, BilKategoriEnum bilKategory)
        {
            if (antalDygn <= 0 || basDygnsHyra < 0 || basKmPris < 0 || antalKm < 0)
            {
                throw new ArgumentException("Antal dygn, basdygnshyra, baskmpris och antal km måste vara positiva värden.");
            }

            decimal totalKostnad = bilKategory switch
            {
                BilKategoriEnum.Smabil => basDygnsHyra * antalDygn,
                BilKategoriEnum.Kombi => (basDygnsHyra * antalDygn * KombiMultiplikator) + (basKmPris * antalKm),
                BilKategoriEnum.Lastbil => (basDygnsHyra * antalDygn * LastbilMultiplikator) + (basKmPris * antalKm * LastbilMultiplikator),
                _ => throw new ArgumentException("Ogiltig biltyp angiven.")
            };

            return totalKostnad;
        }
    }
}