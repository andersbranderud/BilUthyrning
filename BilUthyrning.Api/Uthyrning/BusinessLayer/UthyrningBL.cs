using BilUthyrning.ViewModels;
using Uthyrning.BusinessLayer.Helpers;
using Uthyrning.DataAccessLayer.Interfaces;

namespace Uthyrning.BusinessLayer
{
    public class UthyrningBL : IUthyrningBL
    {
        private readonly IUthyrningsDal _uthyrningDal;
        public UthyrningBL(IUthyrningsDal uthyrningDal)
        {
            _uthyrningDal = uthyrningDal ?? throw new ArgumentNullException(nameof(uthyrningDal));
        }
        public async Task<UthyrningsModel> HittaUthyrningMedBokningsnummerAsync(string bokningsnummer)
        {
            return await _uthyrningDal.HittaUthyrningMedBokningsNummerAsync(bokningsnummer);
        }

        /// <summary>
        /// Registers the rental of a car.
        /// </summary>
        /// <param name="uthyrning">The rental details.</param>
        /// <returns>A task that represents the asynchronous operation, containing the registered rental.</returns>
        public async Task<UthyrningsModel> RegistreraUtlamningAvBilAsync(UthyrningsModel uthyrning)
        {
            if (uthyrning == null)
            {
                throw new ArgumentNullException(nameof(uthyrning));
            }

            return await _uthyrningDal.RegistreraUthyrningAvBilAsync(uthyrning);
        }

        public async Task<UthyrningsModel> RegistreraAterlamningAvBilAsync(AterlamningModel aterlamningModel)
        {
            var matchandeUthyrning = await _uthyrningDal.HittaUthyrningMedBokningsNummerAsync(aterlamningModel.Bokningsnummer);

            if (matchandeUthyrning == null)
            {
                throw new ArgumentException("Ingen uthyrning hittades med det angivna bokningsnumret.");
            }

            if (aterlamningModel == null)
            {
                throw new ArgumentNullException(nameof(aterlamningModel));
            }

            BilUthyrning.Enums.BilKategoriEnum bilKategori = matchandeUthyrning.BilKategori;
            DateTime hyrDatum = matchandeUthyrning.DatumTidpunktUtlamning;
            DateTime inlamningDatum = aterlamningModel.DatumTidpunktAterlamning;
            var antalDygnHyra = (inlamningDatum - hyrDatum).Days;

            if (antalDygnHyra < 0)
            {
                throw new ArgumentException("Återlämningsdatum kan inte vara tidigare än uthyrningsdatum.");
            }
            // Använder baspris som godkänts vid uthyrning, i fall priset har ökat sedan dess.
            BasPrisModel basPrisModel = await _uthyrningDal.HittaBasPrisAsync(hyrDatum, bilKategori);

            if (basPrisModel == null)
            {
                throw new InvalidOperationException("Baspris kunde inte hittas för det angivna datumet.");
            }

            var antalKm = aterlamningModel.AktuellMatarstallningAterlamning - matchandeUthyrning.AktuellMatarstallningUthyrning;

            var beraknadKostnad = UthyrningKalkylator.BeraknaKostnadAsync(
                antalDygnHyra,
                basPrisModel.BasDygnsHyra,
                basPrisModel.BasKmPris,
                antalKm,
                bilKategori);

            matchandeUthyrning.BeraknatPrisUthyrning = beraknadKostnad;
            matchandeUthyrning.AktuellMatarstallningInlamning = aterlamningModel.AktuellMatarstallningAterlamning;
            matchandeUthyrning.DatumTidpunktInlamning = aterlamningModel.DatumTidpunktAterlamning;

            return await _uthyrningDal.RegistreraUthyrningAvBilAsync(matchandeUthyrning);
        }
    }
}