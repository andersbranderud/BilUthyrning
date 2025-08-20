using BilUthyrning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Uthyrning.BusinessLayer;

namespace BilUthyrning.Api.Services.Interfaces
{
    public class UthyrningsService : IUthyrningService
    {
        private readonly IUthyrningBL _uthyrningBL;
        public UthyrningsService(IUthyrningBL uthyrningBL)
        {
            _uthyrningBL = uthyrningBL ?? throw new ArgumentNullException(nameof(uthyrningBL));
        }
        /// <summary>
        /// Registrerar uthyrningen av en bil.
        /// </summary>
        /// <param name="uthyrning">Uthyrningsdetaljerna</param>
        public async Task<UthyrningsModel> RegistreraUtlamningAvBilAsync(UthyrningsModel uthyrning)
        {
            if (uthyrning == null)
            {
                throw new ArgumentNullException(nameof(uthyrning));
            }

            try
            {
                return await _uthyrningBL.RegistreraUtlamningAvBilAsync(uthyrning);
            }
            catch (Exception ex)
            {
                // Todo logga felet.
                throw new Exception("Det gick inte att registrera uthyrningen av bilen.", ex);
            }        
        }

        public async Task<UthyrningsModel> RegistreraAterlamningAvBilAsync(AterlamningModel aterlamning)
        {
            if (aterlamning == null)
            {
                throw new ArgumentNullException(nameof(aterlamning));
            }

            // Först behöver vi hitta matchande uthyrning baserat på bokningsnumret.
            var matchandeUthyrning = await _uthyrningBL.HittaUthyrningMedBokningsnummerAsync(aterlamning.Bokningsnummer);

            try
            {
                return await _uthyrningBL.RegistreraAterlamningAvBilAsync(aterlamning);
            }
            catch (Exception ex)
            {
                // Todo logga felet.
                throw new Exception("Det gick inte att registrera återlämningen av bilen.", ex);
            }
        }
    }
}