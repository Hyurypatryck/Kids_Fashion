using System.ComponentModel.DataAnnotations;

namespace KidsFashion.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Descricao:")]
        public string Descricao { get; set; }
    }
}
