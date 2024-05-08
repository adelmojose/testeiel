using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories;
using IELCadastroEstudante.Core.Repositories.Interface;
using IELCadastroEstudante.Core.Services.Interface;
using IELCadastroEstudante.ViewModel;

namespace IELCadastroEstudante.Core.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _CidadeRepository;
        private const string _msgIdCidadeInvalid = "informe um ID válido.";
        private const string _msgEstudanteNotFound = "Cidade não encontrado.";

        public CidadeService(ICidadeRepository CidadeRepository)
        {
            _CidadeRepository = CidadeRepository;
        }
         
        public Cidade FindById(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdCidadeInvalid);
            }

            return _CidadeRepository.FindById(id);
        }

        public CidadeViewModel GetById(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdCidadeInvalid);
            }

            var objEstudante = _CidadeRepository.FindById(id);

            var objViewModelo = new CidadeViewModel
            {
                Id = objEstudante.Id,
                NomeCidade = objEstudante.NomeCidade
            };

            return objViewModelo;
        }

        public IEnumerable<CidadeViewModel> ListCidades()
        {
            var lista = _CidadeRepository.Find(u => u.Id > 0).ToList();

            IEnumerable<CidadeViewModel> listaCidade = lista.ConvertAll(
                x => new CidadeViewModel
                {
                    Id = x.Id,
                    NomeCidade = x.NomeCidade, 
                    IdEstado = x.IdEstado

                }); 

            return listaCidade;
        }
  
    }
}
