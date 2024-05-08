using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IELCadastroEstudante.Core.Data.Entity
{
    [Table("Estudante", Schema = "dbo")]
    public class Estudante : BaseEntity
    {

        public Estudante()
        {
        }

        public Estudante(int idEstudante, string nome, string numeroCPF, string endereco, string nomeCurso, int idCidade,  int idInstituicaoEnsino, bool status, DateTime ? dataConclusao, DateTime  dataAtualizacao)
        {
            Id = idEstudante;
            NomeEstudante = nome;
            NumeroCPF = numeroCPF;
            Endereco = endereco;
            NomeCurso = nomeCurso;
            IdCidadade = idCidade;
            IdInstituicaoEnsino = idInstituicaoEnsino;
            Status = status;
            DataConclusao = dataConclusao;
            DataAtualizacao = dataAtualizacao;
        }

        [Key]
        public override int Id { get; set; }
        public string NomeEstudante { get; set; }
        public string NumeroCPF { get; set; }

        public string Endereco { get; set; }

        public string NomeCurso { get; set; }

        public int IdCidadade { get; set; }

        public int IdInstituicaoEnsino { get; set; }
        
        public DateTime? DataConclusao { get; set; }

        public bool Status { get; set; }
        
        public DateTime DataAtualizacao { get; set; }

    }
}

