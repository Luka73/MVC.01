using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.DAL.Entities;
using Projeto.DAL.Repositories;

namespace Projeto.Presentation.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        //POST: Funcionario/Cadastro
        [HttpPost] //Receber o submit do formulario
        public ActionResult Cadastro(FuncionarioCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Nome = model.Nome;
                    funcionario.Salario = model.Salario;
                    funcionario.DataAdmissao = model.DataAdmissao;

                    FuncionarioRepository repository = new FuncionarioRepository();
                    repository.Insert(funcionario);

                    TempData["Mensagem"] = "Funcionário cadastrado com sucesso!";
                    ModelState.Clear();
                }
                catch(Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            return View();
        }
    }
}