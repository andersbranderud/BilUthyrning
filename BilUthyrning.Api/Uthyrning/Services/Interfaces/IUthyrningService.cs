using BilUthyrning.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BilUthyrning.Api.Services.Interfaces
{
    public interface IUthyrningService
    {
        // Registrera utlamning av bil.
        Task<UthyrningsModel> RegistreraUtlamningAvBilAsync(UthyrningsModel uthyrning);
        // Registrera återlämning av bil.
        Task<UthyrningsModel> RegistreraAterlamningAvBilAsync(AterlamningModel aterlamning);
    }
}