using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Gestion_Del_Presupuesto.Data;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class UFViewModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UFViewModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? selectedYear, int? selectedDay, string selectedMonth)
        {
            UF2023 uf2023 = new UF2023();
            UF2024 uf2024 = new UF2024();

            if (selectedYear == 2023)
            {
                uf2023 = _context.UF2023.FirstOrDefault(u => u.Dia == selectedDay) ?? new UF2023();
            }
            else if (selectedYear == 2024)
            {
                uf2024 = _context.UF2024.FirstOrDefault(u => u.Dia == selectedDay) ?? new UF2024();
            }

            var viewModel = new UFCombinedViewModel
            {
                UF2023 = uf2023,
                UF2024 = uf2024
            };

            return View(viewModel);
        }
    }
}
