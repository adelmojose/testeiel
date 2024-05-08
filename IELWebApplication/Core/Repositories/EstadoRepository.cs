using IELCadastroEstudante.Core.Data;
using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories.Interface;

namespace IELCadastroEstudante.Core.Repositories
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
            public EstadoRepository(DataBaseContext dbContext) : base(dbContext)
            {

            }
    }

}
