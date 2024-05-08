using IELCadastroEstudante.Core.Data;
using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories.Interface;

namespace IELCadastroEstudante.Core.Repositories
{
    public class EstudanteRepository : BaseRepository<Estudante>, IEstudanteRepository
    {
            public EstudanteRepository(DataBaseContext dbContext) : base(dbContext)
            {

            }
    }

}
