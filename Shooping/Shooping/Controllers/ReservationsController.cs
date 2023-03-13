using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shooping.Data;
using Shooping.Data.Entities;
using Shooping.Helpers;
using Shooping.Models;
using Vereyon.Web;
using static Shooping.Helpers.ModalHelper;

namespace Shooping.Controllers;

public class ReservationsController : Controller
{
    private readonly DataContext _context;
    private readonly ICombosHelper _combosHelper;
    private readonly IBlobHelper _blobHelper;
    private readonly IFlashMessage _flashMessage;

    public ReservationsController(DataContext context, ICombosHelper combosHelper, IBlobHelper blobHelper, IFlashMessage flashMessage)
    {
        _context = context;
        _combosHelper = combosHelper;
        _blobHelper = blobHelper;
        _flashMessage = flashMessage;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Reservations
            .Include(p => p.Table)
            .ToListAsync());
    }

    [NoDirectAccess]
    public async Task<IActionResult> Create()
    {
        CreateReservationViewModel model = new()
        {
            Tables = await _combosHelper.GetComboTablesAsync(),
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateReservationViewModel model)
    {
        if (ModelState.IsValid)
        {
            Reservation reservation = new()
            {
                Document = model.Document,
                Date = model.Date,
                FullName = model.FullName,
                Remarks = model.Remarks,
                Table = await _context.Tables.FindAsync(model.TableId),
            };

            try
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();

                _flashMessage.Confirmation("Registro creado.");

                return Json(new
                {
                    isValid = true,
                    html = RenderRazorViewToString(this, "_ViewAllReservations", _context.Reservations
                    .Include(p => p.Table)
                    .ToList())
                });
            }
            catch (DbUpdateException dbUpdateException)
            {
                ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }
        }

        model.Tables = await _combosHelper.GetComboTablesAsync();

        return Json(new
        {
            isValid = false,
            html = RenderRazorViewToString(this, "Create", model)
        });
    }

    [NoDirectAccess]
    public async Task<IActionResult> Edit(int id)
    {
        Reservation reservation = await _context.Reservations
            .Include(x => x.Table)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (reservation == null)
        {
            return NotFound();
        }

        EditReservationViewModel model = new()
        {
            Document = reservation.Document,
            Date = reservation.Date,
            FullName = reservation.FullName,
            Remarks = reservation.Remarks,
            TableId = reservation.Table.Id,
            Tables = await _combosHelper.GetComboTablesAsync(),
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CreateReservationViewModel model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        try
        {
            Reservation reservation = await _context.Reservations.FindAsync(model.Id);
            reservation.Document = model.Document;
            reservation.Date = model.Date;
            reservation.FullName = model.FullName;
            reservation.Remarks = model.Remarks;
            reservation.Table  = await _context.Tables.FindAsync(model.TableId);

            _context.Update(reservation);
            await _context.SaveChangesAsync();

            _flashMessage.Confirmation("Registro actualizado.");

            return Json(new
            {
                isValid = true,
                html = ModalHelper.RenderRazorViewToString(this, "_ViewAllReservations", _context.Reservations
                .Include(p => p.Table)
                .ToList())
            });
        }
        catch (DbUpdateException dbUpdateException)
        {
            ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
        }
        catch (Exception exception)
        {
            ModelState.AddModelError(string.Empty, exception.Message);
        }

        return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "Edit", model) });
    }
    /*
    public async Task<IActionResult> DeleteCategory(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        ReservationCategory productCategory = await _context.ReservationCategories
            .Include(pc => pc.Reservation)
            .FirstOrDefaultAsync(pc => pc.Id == id);
        if (productCategory == null)
        {
            return NotFound();
        }

        _context.ReservationCategories.Remove(productCategory);

        await _context.SaveChangesAsync();
        _flashMessage.Info("Registro borrado.");

        return RedirectToAction(nameof(Details), new { Id = productCategory.Reservation.Id });
    }
    */

    [NoDirectAccess]
    public async Task<IActionResult> Delete(int id)
    {
        Reservation reservation = await _context.Reservations.FirstOrDefaultAsync(p => p.Id == id);

        if (reservation == null)
        {
            return NotFound();
        }

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();

        _flashMessage.Info("Registro borrado.");

        return RedirectToAction(nameof(Index));
    }
}
