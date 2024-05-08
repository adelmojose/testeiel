using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IELCadastroEstudante.Core.Data.Entity
{
    [Table("Estado", Schema = "dbo")]
    public class Estado : BaseEntity
    {
        public Estado()
        {
        }

        public Estado(int idEstado, string nomeEstado)
        {
            Id = idEstado;
            NomeEstado = nomeEstado;
            
        }

        [Key]
        public override int Id { get; set; }
        public string NomeEstado { get; set; }

    }
}
