using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Services;
using IELCadastroEstudante.Core.Services.Interface;
using IELCadastroEstudante.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IELCadastroEstudante.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly IEstudanteService _estudanteService;
        private readonly ICidadeService _cidadeService;
        private readonly IEstadoService _estadoService;
        private readonly IInstituicaoEnsinoService _instituicaoEnsinoService;

        private string _msgCadastroSucesso = "Registro de Estudante salvo com sucesso!";
        private string _msgIdInvalido = "Id inválido!";
        private string _msgExclusaoSucesso = "Registro de Estudante excluído com sucesso!";
        private string _msgRelatorioSucesso = "Relatório gerado com com sucesso!";


        public EstudanteController(IEstudanteService estudanteService, ICidadeService cidadeService, IEstadoService estadoService, IInstituicaoEnsinoService instituicaoEnsinoService)
        {
            _estudanteService = estudanteService;
            _cidadeService = cidadeService;
            _estadoService = estadoService;
            _instituicaoEnsinoService = instituicaoEnsinoService;
        }
        
        public ActionResult Index()
        {
            var teste = ViewBag.Erro;

            if (TempData["Erro"] != null)
            {
                ViewBag.Erro = TempData["Erro"];
            }

            if (TempData["Sucesso"] != null)
            {
                ViewBag.Sucesso = TempData["Sucesso"];
            }
            return View();
        }

        
        public ActionResult List()
        {
            if (TempData["Erro"] != null)
            {
                ViewBag.Erro = TempData["Erro"];
            }

            if (TempData["Sucesso"] != null)
            {
                ViewBag.Sucesso = TempData["Sucesso"];
            }

            try
            {
                ViewBag.Cidade = _cidadeService.ListCidades().ToList();
                ViewBag.Instituicao = _instituicaoEnsinoService.ListInstituicoes().ToList();

                var ret = _estudanteService.ListAllEstudantes();

                return View(ret);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult List(string numeroCPF, string nome, string endereco, int idCidade, int idInstituicaoEnsino, string nomeCurso, DateTime? dataConclusao)
        {
            if (TempData["Erro"] != null)
            {
                ViewBag.Erro = TempData["Erro"];
            }

            if (TempData["Sucesso"] != null)
            {
                ViewBag.Sucesso = TempData["Sucesso"];
            }

            try
            {
                ViewBag.Cidade = _cidadeService.ListCidades().ToList();
                ViewBag.Instituicao = _instituicaoEnsinoService.ListInstituicoes().ToList();

                var ret = _estudanteService.ListFilterEstudantes(nome, numeroCPF, endereco, nomeCurso, idCidade, idInstituicaoEnsino, dataConclusao);

                return View(ret);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View();
            }

        }
        
        public ActionResult Register()
        {
            ViewBag.Cidade = _cidadeService.ListCidades().ToList();
            ViewBag.Instituicao = _instituicaoEnsinoService.ListInstituicoes().ToList();

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(EstudanteViewModel estudante)
        {
            try
            {

               var estudanteRegistrado =  _estudanteService.AddEstudante(estudante);

                TempData["Sucesso"] = _msgCadastroSucesso;

                return RedirectToAction("List", "Estudante");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View();
            }
        }

        // GET: EstudanteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstudanteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    TempData["Erro"] = _msgIdInvalido;
                    return View();
                }

                _estudanteService.DeleteEstudante(id);

                TempData["Sucesso"] = _msgExclusaoSucesso;

                return RedirectToAction("List", "Estudante");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View();
            }

        }




        public ActionResult Report()
        {

            if (TempData["Erro"] != null)
            {
                ViewBag.Erro = TempData["Erro"];
            }

            if (TempData["Sucesso"] != null)
            {
                ViewBag.Sucesso = TempData["Sucesso"];
            }

            try
            {
                ViewBag.Instituicao = _instituicaoEnsinoService.ListInstituicoes().ToList();

                return View(new List<EstudanteViewModel>());
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Report(int IdInstituicaoEnsino, string nomeCurso)
        {
            try
            {
                var dados = _estudanteService.ListFilterEstudantes(string.Empty, string.Empty, string.Empty, nomeCurso, 0, IdInstituicaoEnsino, null).ToList();
                
                ViewBag.Instituicao = _instituicaoEnsinoService.ListInstituicoes().ToList();

                var fileName = "REPORT_ESTUDANTES_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                var fileContent = GerarPlanilhaEmMemoria(dados);

                TempData["Sucesso"] = _msgRelatorioSucesso; 

                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View();
            }
        }


        private byte[] GerarPlanilhaEmMemoria(List<EstudanteViewModel> dados)
        {
            using (var workbook = new XLWorkbook())
            {

                var worksheet = workbook.Worksheets.Add("Relatorio");
                worksheet.Cell(1, "A").Value = "RELATÓRIO DE ESTUDANTES";
                worksheet.Cell(1, "A").Style.Font.Bold = true;
                worksheet.Range("A1:D1").Row(1).Merge();
                //worksheet.Range("A1:D1").Column(4).Merge();

                worksheet.Cell(2, "A").Value = "Nome";
                worksheet.Cell(2, "B").Value = "CPF";
                worksheet.Cell(2, "C").Value = "Curso";
                worksheet.Cell(2, "D").Value = "Conclusão";


                for (int i = 0; i < dados.Count; i++)
                {
                    var item = dados[i];
                    worksheet.Cell("A" + (i + 3)).Value = item.NomeEstudante;
                    worksheet.Cell("B" + (i + 3)).Value = item.NumeroCPF;
                    worksheet.Cell("C" + (i + 3)).Value = item.NomeCurso;
                    worksheet.Cell("D" + (i + 3)).Value = item.DataConclusao;
                }

    
                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
