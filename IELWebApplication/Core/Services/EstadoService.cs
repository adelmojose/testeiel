using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories;
using IELCadastroEstudante.Core.Repositories.Interface;
using IELCadastroEstudante.Core.Services.Interface;
using IELCadastroEstudante.ViewModel;

namespace IELCadastroEstudante.Core.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _EstadoRepository;
        private const string _msgIdEstadoInvalid = "informe um ID válido.";
        private const string _msgEstudanteNotFound = "Estado não encontrado.";

        public EstadoService(IEstadoRepository estadoRepository)
        {
            _EstadoRepository = estadoRepository;
        }

        public Estado FindById(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdEstadoInvalid);
            }

            return _EstadoRepository.FindById(id);
        }

        public EstadoViewModel GetById(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdEstadoInvalid);
            }

            var objEstudante = _EstadoRepository.FindById(id);

            var objViewModelo = new EstadoViewModel
            {
                Id = objEstudante.Id,
                NomeEstado = objEstudante.NomeEstado
            };

            return objViewModelo;
        }

        public IEnumerable<EstadoViewModel> ListEstados()
        {
            var lista = _EstadoRepository.Find(u => u.Id > 0).ToList();

            IEnumerable<EstadoViewModel> listaEstado = lista.ConvertAll(
                x => new EstadoViewModel
                {
                    Id = x.Id,
                    NomeEstado = x.NomeEstado
                }); 

            return listaEstado;
        }
   
    }
}
