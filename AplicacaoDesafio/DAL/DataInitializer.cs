using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AplicacaoDesafio.Models;

namespace AplicacaoDesafio.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        public override void InitializeDatabase(DataContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(DataContext context)
        {
            var user = new List<User>
            {
            new User{ID=1, Nome="Dimitri",Sobrenome="Rocha",CPF="03128799547", Email="dimitrirocha10@gmail.com", Login="dRocha", Senha="123456", Status=true},
            //new User{Nome="Joao",Sobrenome="Teste",CPF="03128799547", Email="joao@hotmail.com", Login="jao", Senha="123456", Status=true}
            };

            base.Seed(context);
            context.SaveChanges();
        }
    }
}