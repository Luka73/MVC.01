using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class FuncionarioCadastroModel
    {
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, preencha o nome do Funcionário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o salário do Funcionário.")]
        [Range(100.00, 20000.00, ErrorMessage = "O salário deve estar entre {1} e {2}.")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a data de admissão do Funcionário.")]
        public DateTime DataAdmissao { get; set; }
    }
}