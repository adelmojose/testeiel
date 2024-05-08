using IELCadastroEstudante.Core.Data;
using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories.Interface;

namespace IELCadastroEstudante.Core.Repositories
{
    public class InstituicaoEnsinoRepository : BaseRepository<InstituicaoEnsino>, IInstituicaoEnsinoRepository
    {
            public InstituicaoEnsinoRepository(DataBaseContext dbContext) : base(dbContext)
            {

            }
    }

}
