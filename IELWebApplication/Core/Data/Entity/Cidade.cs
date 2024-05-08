using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IELCadastroEstudante.Core.Data.Entity
{
    [Table("Cidade", Schema = "dbo")]
    public class Cidade : BaseEntity
    {
        public Cidade()
        {
        }

        public Cidade(int idCidade, string nomeCidade, int idEstado)
        {
            Id = idCidade;
            NomeCidade = nomeCidade;
            IdEstado = idEstado;
        }

        [Key]
        public override int Id { get; set; }
        public string NomeCidade { get; set; }
        public int IdEstado { get; set; }


    }
}
