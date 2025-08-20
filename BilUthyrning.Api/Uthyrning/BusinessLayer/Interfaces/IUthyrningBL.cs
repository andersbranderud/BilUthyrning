using BilUthyrning.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Uthyrning.BusinessLayer
{
    public interface IUthyrningBL
    {
        /// <summary>
        /// Registers the rental of a car.
        /// </summary>
        /// <param name="uthyrning">The rental details.</param>
        /// <returns>A task that represents the asynchronous operation, containing the registered rental.</returns>
        Task<UthyrningsModel> RegistreraUtlamningAvBilAsync(UthyrningsModel uthyrning);

        Task<UthyrningsModel> RegistreraAterlamningAvBilAsync(AterlamningModel aterlamning);

        Task<UthyrningsModel> HittaUthyrningMedBokningsnummerAsync(string bokningsnummer);
    }
}