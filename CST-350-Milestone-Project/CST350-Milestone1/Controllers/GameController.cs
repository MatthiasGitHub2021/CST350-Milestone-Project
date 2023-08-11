using CST350_Milestone1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CST350_Milestone1.Controllers
{
    public class GameController : Controller
    {
        //List of cells
        static List<CellModel> cells = new List<CellModel>();

        const int GRID_SIZE = 300;
        public IActionResult Index()
        {
            //create a new list (new game) of cells
            cells = new List<CellModel>();

            //fill grid with cells
            for (int i = 0; i < GRID_SIZE; i++)
            {
                cells.Add(new CellModel());
            }

            return View("Index", cells);
        }
    }
}
