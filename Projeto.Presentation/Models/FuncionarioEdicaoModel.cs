using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class FuncionarioEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do Funcionário")]
        public int IdFuncionario { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do Funcionário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, informe o salário do Funcionário")]
        public decimal Salario { get; set; }
        [Required(ErrorMessage = "Por favor, informe e data de admissão do Funcionário")]
        public DateTime DataAdmissao { get; set; }
    }
}