using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories;
using IELCadastroEstudante.Core.Repositories.Interface;
using IELCadastroEstudante.Core.Services.Interface;
using IELCadastroEstudante.ViewModel;

namespace IELCadastroEstudante.Core.Services
{
    public class InstituicaoEnsinoService : IInstituicaoEnsinoService
    {
        private readonly IInstituicaoEnsinoRepository _InstituicaoEnsinoRepository;

        private const string _msgIdInstituicaoEnsinoInvalid = "informe um ID válido.";
        private const string _msgEstudanteNotFound = "InstituicaoEnsino não encontrado.";

        public InstituicaoEnsinoService(IInstituicaoEnsinoRepository InstituicaoEnsinoRepository)
        {
            _InstituicaoEnsinoRepository = InstituicaoEnsinoRepository;
        }

        public InstituicaoEnsino FindById(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdInstituicaoEnsinoInvalid);
            }

            return _InstituicaoEnsinoRepository.FindById(id);
        }

        public InstituicaoEnsinoViewModel GetById(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdInstituicaoEnsinoInvalid);
            }

            var objEstudante = _InstituicaoEnsinoRepository.FindById(id);

            var objViewModelo = new InstituicaoEnsinoViewModel
            {
                Id = objEstudante.Id,
                NomeInstituicao = objEstudante.NomeInstituicao
            };

            return objViewModelo;
        }

        public IEnumerable<InstituicaoEnsinoViewModel> ListInstituicoes()
        {
            var lista = _InstituicaoEnsinoRepository.Find(u => u.Id > 0).ToList();

            IEnumerable<InstituicaoEnsinoViewModel> listaInstituicaoEnsino = lista.ConvertAll(
                x => new InstituicaoEnsinoViewModel
                {
                    Id = x.Id,
                    NomeInstituicao = x.NomeInstituicao
                });

            return listaInstituicaoEnsino;
        }
      
    }
}
