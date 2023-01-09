using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Autenticar(string email,string password);
        Task<bool> Cadastrar(string email,string password);
        Task Logout();
    }
}
