using Shooping.Data;
using Vereyon.Web;

namespace Shooping.Controllers
{
    public class ReservacionController
    {
        private readonly DataContext _context;
        private readonly IFlashMessage _flashMessage;

        public ReservacionController(DataContext context, IFlashMessage flashMessage)
        {
            _context = context;
            _flashMessage = flashMessage;
        }


    }
}
