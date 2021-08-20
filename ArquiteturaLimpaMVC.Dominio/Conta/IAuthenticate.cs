using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Dominio.Conta
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string senha);

        Task<bool> RegistrarUsuario(string email, string senha);

        Task Sair();
    }
}