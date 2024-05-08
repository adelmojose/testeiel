using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.ViewModel;
namespace IELCadastroEstudante.Core.Services.Interface
{
    public interface ICidadeService : IBaseService<Cidade>
    {
        CidadeViewModel GetById(int id);

        IEnumerable<CidadeViewModel> ListCidades();

    }
}
