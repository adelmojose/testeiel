using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace IELCadastroEstudante.Core.Data.Entity
{
    [Table("InstituicaoEnsino", Schema = "dbo")]
    public class InstituicaoEnsino : BaseEntity
    {
        public InstituicaoEnsino() 
        { 
        }

        public InstituicaoEnsino(int idInstituicao, string nomeInstituicao)
        {
            Id = idInstituicao;
            NomeInstituicao = nomeInstituicao;
        }

        [Key]
        public override int Id { get; set; }
        public string NomeInstituicao { get; set; }

    }
}
