using System.ComponentModel.DataAnnotations;

namespace IELCadastroEstudante.ViewModel
{
    public class EstudanteViewModel
    {
        public  int Id { get; set; }
        public string NomeEstudante { get; set; }
        public string NumeroCPF { get; set; }
        public string Endereco { get; set; }
        public string NomeCurso { get; set; }
        public int IdCidade { get; set; }
        public int IdInstituicaoEnsino { get; set; }
        public bool Status { get; set; }
        public DateTime? DataConclusao { get; set; }

        public DateTime DataAtualizacao { get; set; }

    }
}
