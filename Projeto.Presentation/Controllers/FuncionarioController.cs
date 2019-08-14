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

        //GET: Funcionario/Consulta
        public ActionResult Consulta()
        {
            List<FuncionarioConsultaModel> model = new List<FuncionarioConsultaModel>();

            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                foreach(var item in repository.SelectAll())
                {
                    FuncionarioConsultaModel consulta = new FuncionarioConsultaModel();
                    consulta.IdFuncionario = item.IdFuncionario;
                    consulta.Nome = item.Nome;
                    consulta.Salario = item.Salario;
                    consulta.DataAdmissao = item.DataAdmissao;

                    model.Add(consulta);
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Consulta(string Nome)
        {
            List<FuncionarioConsultaModel> model = new List<FuncionarioConsultaModel>();

            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                foreach( var item in repository.SelectAll(Nome))
                {
                    FuncionarioConsultaModel consulta = new FuncionarioConsultaModel();
                    consulta.IdFuncionario = item.IdFuncionario;
                    consulta.Nome = item.Nome;
                    consulta.Salario = item.Salario;
                    consulta.DataAdmissao = item.DataAdmissao;

                    model.Add(consulta);
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        public ActionResult Edicao(int id)
        {
            FuncionarioEdicaoModel model = new FuncionarioEdicaoModel();

            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                Funcionario funcionario = repository.SelectById(id);

                model.IdFuncionario = funcionario.IdFuncionario;
                model.Nome = funcionario.Nome;
                model.Salario = funcionario.Salario;
                model.DataAdmissao = funcionario.DataAdmissao;
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(FuncionarioEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.IdFuncionario = model.IdFuncionario;
                    funcionario.Nome = model.Nome;
                    funcionario.Salario = model.Salario;
                    funcionario.DataAdmissao = model.DataAdmissao;

                    FuncionarioRepository repository = new FuncionarioRepository();
                    repository.Update(funcionario);

                    TempData["Mensagem"] = "Funcionário atualizado com sucesso!";
                    ModelState.Clear();
                }
                catch(Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View(model);
        }

        public ActionResult Exclusao(int id)
        {
            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                repository.Delete(id);

                TempData["Mensagem"] = "Funcionário excluído com sucesso!";
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View();
        }
    }
}