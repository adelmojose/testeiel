using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.ViewModel;
namespace IELCadastroEstudante.Core.Services.Interface
{
    public interface IInstituicaoEnsinoService : IBaseService<InstituicaoEnsino>
    {
        InstituicaoEnsinoViewModel GetById(int id);

        IEnumerable<InstituicaoEnsinoViewModel> ListInstituicoes();

    }
}
