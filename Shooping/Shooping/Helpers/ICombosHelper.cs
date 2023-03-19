using Microsoft.AspNetCore.Mvc.Rendering;
using Shooping.Data.Entities;

namespace Shooping.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetComboTablesAsync();
        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync(IEnumerable<Category> filter);
        Task<IEnumerable<SelectListItem>> GetComboMesasAsync(IEnumerable<Table> filter);
    }
}
