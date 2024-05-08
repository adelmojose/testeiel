using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.ViewModel;
namespace IELCadastroEstudante.Core.Services.Interface
{
    public interface IEstudanteService : IBaseService<Estudante>
    {
        EstudanteViewModel GetById(int id);

        IEnumerable<EstudanteViewModel> ListAllEstudantes();

        IEnumerable<EstudanteViewModel> ListFilterEstudantes(string nome, string numeroCPF, string endereco, string nomeCurso, int idCidade, int idInstituicaoEnsino, DateTime? dataConclusao);

        Estudante AddEstudante(EstudanteViewModel estudante);

        Estudante UpdateEstudante(EstudanteViewModel estudante);

        void DeleteEstudante(int id);

    }
}
