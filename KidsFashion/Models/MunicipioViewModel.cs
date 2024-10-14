using System.ComponentModel.DataAnnotations;

namespace KidsFashion.Models
{
    public class MunicipioViewModel
    {
        public int Id { get; set; }
        [Display(Name="Municipio")]
        public string Nome { get; set; }
        public string UF { get; set; }
    }
}
