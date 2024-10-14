namespace KidsFashion.Models
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public MunicipioViewModel Municipio { get; set; }
    }
}
