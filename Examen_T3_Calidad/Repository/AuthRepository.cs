using Examen_T3_Calidad.DB;
using Examen_T3_Calidad.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.Repository
{
    public interface IAuthRepository
    {
        public Usuario Login(string username, string password);
        public Usuario Register(Usuario account);
    }
    public class AuthRepository : IAuthRepository
    {
        private readonly NotaContext context;
        private IConfiguration configuration;

        public AuthRepository(NotaContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public Usuario Login(string username, string password)
        {
            return context.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
        }

        public Usuario Register(Usuario account)
        {
            context.Usuarios.Add(account);
            context.SaveChanges();

            return account;
        }
    }
}
