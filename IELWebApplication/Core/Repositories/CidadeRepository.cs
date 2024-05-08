using IELCadastroEstudante.Core.Data;
using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories.Interface;

namespace IELCadastroEstudante.Core.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
            public CidadeRepository(DataBaseContext dbContext) : base(dbContext)
            {

            }
    }

}
