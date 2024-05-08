using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.ViewModel;
namespace IELCadastroEstudante.Core.Services.Interface
{
    public interface IEstadoService : IBaseService<Estado>
    {
        EstadoViewModel GetById(int id);

        IEnumerable<EstadoViewModel> ListEstados();

    }
}
