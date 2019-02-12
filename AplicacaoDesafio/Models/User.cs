using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AplicacaoDesafio.Attribute;

namespace AplicacaoDesafio.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [Unique(ErrorMessage = "Esse CPF já está cadastrado")]
        public string CPF { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "O email não é válido")]
        public string Email { get; set; }

        [Required]
        [Unique(ErrorMessage = "Esse nome de usuário já existe")]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public bool Status { get; set; }

        public User()
        {
            this.Status = true;
        }
    }
}