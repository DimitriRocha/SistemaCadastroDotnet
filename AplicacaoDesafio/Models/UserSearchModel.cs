using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoDesafio.Models
{
    public class UserSearchModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool? Status { get; set; }
    }
}