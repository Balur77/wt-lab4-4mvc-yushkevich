
using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_yushkevich.Models;

public class Cargo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название груза")]
    [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите категорию")]
    [StringLength(60, ErrorMessage = "Категория не должна превышать 60 символов")]
    public string Category { get; set; } = string.Empty;

    [Range(1, 1000000, ErrorMessage = "Количество должно быть от 1 до 1000000")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Укажите место хранения")]
    [StringLength(100, ErrorMessage = "Место хранения не должно превышать 100 символов")]
    public string Location { get; set; } = string.Empty;

    [Range(0.01, 1000000000, ErrorMessage = "Вес должен быть положительным числом")]
    public decimal Weight { get; set; }

    [Required(ErrorMessage = "Укажите описание груза")]
    [StringLength(300, ErrorMessage = "Описание не должно превышать 300 символов")]
    public string Description { get; set; } = string.Empty;

    public bool IsAvailable { get; set; } = true;
}
