using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories;
using IELCadastroEstudante.Core.Repositories.Interface;
using IELCadastroEstudante.Core.Services.Interface;
using IELCadastroEstudante.ViewModel;
using Microsoft.IdentityModel.Tokens;

namespace IELCadastroEstudante.Core.Services
{
    public class EstudanteService : IEstudanteService
    {
        private readonly IEstudanteRepository _EstudanteRepository;

        private const string _msgIdEstudanteInvalid = "informe um ID válido.";
        private const string _msgCpfEstudanteInvalid = "informe um CPF válido.";
        private const string _msgNomeEstudanteInvalid = "informe um Nome válido.";
        private const string _msgEstudanteNotFound = "Estudante não encontrado."; 


        public EstudanteService(IEstudanteRepository estudanteRepository)
        {
            _EstudanteRepository = estudanteRepository;
        }

        public Estudante AddEstudante(EstudanteViewModel estudante)
        {
            if (string.IsNullOrEmpty(estudante.NomeEstudante))
            {
                throw new ApplicationException(_msgNomeEstudanteInvalid);
            }
       
            if (!Util.Util.IsCpf(estudante.NumeroCPF))
            {
                throw new ApplicationException(_msgCpfEstudanteInvalid);
            }

            return _EstudanteRepository.Add(new Estudante()
            {
                Id = 0,
                NomeEstudante = estudante.NomeEstudante,
                NumeroCPF = estudante.NumeroCPF.Replace(".", "").Replace("-", "").Trim().ToString(),
                Endereco = estudante.Endereco,
                NomeCurso = estudante.NomeCurso,
                IdCidadade = estudante.IdCidade,
                IdInstituicaoEnsino = estudante.IdInstituicaoEnsino,
                DataConclusao = estudante.DataConclusao, 
                Status = true ,
                DataAtualizacao = DateTime.Now
            });


        }

        public void DeleteEstudante(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdEstudanteInvalid);
            }

            var objEstudante = this.FindById(id);

            if (objEstudante is null)
            {
                throw new ApplicationException(_msgEstudanteNotFound);
            }

            _EstudanteRepository.Delete(objEstudante);
        }

        public Estudante FindById(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdEstudanteInvalid);
            }

            return _EstudanteRepository.FindById(id); 

        }
        public EstudanteViewModel GetById(int id)
        {
            if (id < 0)
            {
                throw new ApplicationException(_msgIdEstudanteInvalid); 
            }

            var objEstudante = _EstudanteRepository.FindById(id);

            var objViewModelo = new EstudanteViewModel
               {
                   Id = objEstudante.Id,
                   NomeEstudante = objEstudante.NomeEstudante,
                   NumeroCPF = objEstudante.NumeroCPF,
                   Endereco = objEstudante.Endereco,
                   NomeCurso = objEstudante.NomeCurso,
                   IdCidade = objEstudante.IdCidadade,
                   IdInstituicaoEnsino = objEstudante.IdInstituicaoEnsino,
                   Status = objEstudante.Status,
                   DataConclusao = objEstudante.DataConclusao,
                   DataAtualizacao = objEstudante.DataAtualizacao

               };

            return objViewModelo;

        }

        public IEnumerable<EstudanteViewModel> ListAllEstudantes()
        {

            var lista = _EstudanteRepository.Find(u => u.Id > 0).ToList();

            IEnumerable<EstudanteViewModel> listaEstudante = lista.ConvertAll(
                x => new EstudanteViewModel
                {
                    Id = x.Id,
                    NomeEstudante = x.NomeEstudante,
                    NumeroCPF = x.NumeroCPF, 
                    Endereco = x.Endereco, 
                    NomeCurso = x.NomeCurso, 
                    IdCidade = x.IdCidadade, 
                    IdInstituicaoEnsino = x.IdInstituicaoEnsino, 
                    Status = x.Status, 
                    DataConclusao = x.DataConclusao, 
                    DataAtualizacao = x.DataAtualizacao

                });

            return listaEstudante;
        }
        public IEnumerable<EstudanteViewModel> ListFilterEstudantes(string nome, string numeroCPF, string endereco, string nomeCurso, int idCidade, int idInstituicaoEnsino, DateTime? dataConclusao)
        {

            var lista = _EstudanteRepository.Find(u => (!string.IsNullOrEmpty(nome) ? u.NomeEstudante.Contains(nome) : !string.IsNullOrEmpty(u.NomeEstudante))
                                                && (!string.IsNullOrEmpty(numeroCPF) ? u.NumeroCPF.Contains(numeroCPF): !string.IsNullOrEmpty(u.NumeroCPF))
                                                && (!string.IsNullOrEmpty(endereco) ? u.Endereco.Contains(endereco) : !string.IsNullOrEmpty(u.Endereco))
                                                && (!string.IsNullOrEmpty(nomeCurso) ? u.NomeCurso.Contains(nomeCurso) : !string.IsNullOrEmpty(u.Endereco)) 
                                                && (idCidade > 0 ? u.IdCidadade == idCidade : u.IdCidadade > 0)
                                                && (idInstituicaoEnsino > 0 ? u.IdInstituicaoEnsino == idInstituicaoEnsino : u.IdInstituicaoEnsino > 0)
                                                    ).ToList();

            IEnumerable<EstudanteViewModel> listaEstudante = lista.ConvertAll(
                x => new EstudanteViewModel
                {
                    Id = x.Id,
                    NomeEstudante = x.NomeEstudante,
                    NumeroCPF = x.NumeroCPF,
                    Endereco = x.Endereco,
                    NomeCurso = x.NomeCurso,
                    IdCidade = x.IdCidadade,
                    IdInstituicaoEnsino = x.IdInstituicaoEnsino,
                    Status = x.Status,
                    DataConclusao = x.DataConclusao,
                    DataAtualizacao = x.DataAtualizacao

                });

            return listaEstudante;
        }

        public Estudante UpdateEstudante(EstudanteViewModel estudante)
        {
            if (string.IsNullOrEmpty(estudante.NomeEstudante))
            {
                throw new ApplicationException(_msgNomeEstudanteInvalid);
            }
            if (estudante.NumeroCPF.ToString().Length > 11)
            {
                if (!Util.Util.IsCpf(estudante.NumeroCPF))
                    throw new ApplicationException(_msgCpfEstudanteInvalid);
            }

            return _EstudanteRepository.Update(new Estudante()
            {
                Id = 0,
                NomeEstudante = estudante.NomeEstudante,
                NumeroCPF = estudante.NumeroCPF,
                Endereco = estudante.Endereco,
                NomeCurso = estudante.NomeCurso,
                IdCidadade = estudante.IdCidade,
                IdInstituicaoEnsino = estudante.IdInstituicaoEnsino,
                DataConclusao = estudante.DataConclusao,
                Status = estudante.Status,
                DataAtualizacao = DateTime.Now
            });

        }
    }
}
