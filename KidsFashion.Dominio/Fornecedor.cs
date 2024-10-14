using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Dominio
{
    public class Fornecedor : EntidadeComId
    {
        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Contato { get; set; }
        public int Endereco_Id { get; set; } // FK para Endereco
        public Endereco Endereco { get; set; }
    }

}
