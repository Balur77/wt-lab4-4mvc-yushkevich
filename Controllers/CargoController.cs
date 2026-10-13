
using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_yushkevich.Models;

namespace wt_lab4_4mvc_yushkevich.Controllers;

public class CargoController : Controller
{
    private static readonly List<Cargo> Cargos = new()
    {
        new Cargo
        {
            Id = 1,
            Name = "Ноутбуки",
            Category = "Электроника",
            Quantity = 20,
            Location = "Сектор A-1",
            Weight = 45.5m,
            Description = "Партия офисных ноутбуков",
            IsAvailable = true
        },
        new Cargo
        {
            Id = 2,
            Name = "Офисные столы",
            Category = "Мебель",
            Quantity = 15,
            Location = "Сектор B-2",
            Weight = 225.0m,
            Description = "Столы для офисных помещений",
            IsAvailable = true
        },
        new Cargo
        {
            Id = 3,
            Name = "Цемент",
            Category = "Стройматериалы",
            Quantity = 100,
            Location = "Сектор C-1",
            Weight = 2500.0m,
            Description = "Мешки цемента для строительных работ",
            IsAvailable = true
        },
        new Cargo
        {
            Id = 4,
            Name = "Мониторы",
            Category = "Электроника",
            Quantity = 12,
            Location = "Сектор A-2",
            Weight = 60.0m,
            Description = "Мониторы для рабочих мест",
            IsAvailable = true
        },
        new Cargo
        {
            Id = 5,
            Name = "Строительные инструменты",
            Category = "Инструменты",
            Quantity = 35,
            Location = "Сектор C-2",
            Weight = 175.0m,
            Description = "Набор инструментов для строительных бригад",
            IsAvailable = false
        }
    };

    public IActionResult Index()
    {
        return View(Cargos);
    }

    public IActionResult Details(int id)
    {
        var cargo = Cargos.FirstOrDefault(c => c.Id == id);

        if (cargo == null)
        {
            return NotFound();
        }

        return View(cargo);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Cargo cargo)
    {
        if (!ModelState.IsValid)
        {
            return View(cargo);
        }

        cargo.Id = Cargos.Count == 0
            ? 1
            : Cargos.Max(c => c.Id) + 1;

        Cargos.Add(cargo);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var cargo = Cargos.FirstOrDefault(c => c.Id == id);

        if (cargo == null)
        {
            return NotFound();
        }

        return View(cargo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Cargo updatedCargo)
    {
        var cargo = Cargos.FirstOrDefault(c => c.Id == id);

        if (cargo == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            updatedCargo.Id = id;
            return View(updatedCargo);
        }

        cargo.Name = updatedCargo.Name;
        cargo.Category = updatedCargo.Category;
        cargo.Quantity = updatedCargo.Quantity;
        cargo.Location = updatedCargo.Location;
        cargo.Weight = updatedCargo.Weight;
        cargo.Description = updatedCargo.Description;
        cargo.IsAvailable = updatedCargo.IsAvailable;

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var cargo = Cargos.FirstOrDefault(c => c.Id == id);

        if (cargo == null)
        {
            return NotFound();
        }

        Cargos.Remove(cargo);

        return RedirectToAction(nameof(Index));
    }
}
