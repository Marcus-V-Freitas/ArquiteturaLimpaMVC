using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Dominio.Validacoes
{
    public class ValidacaoDominioException:Exception
    {
        public ValidacaoDominioException(string erro):base(erro)
        {

        }

        public static void Validar(bool existeErro,string erro)
        {
            if (existeErro)
                throw new ValidacaoDominioException(erro);
        }
    }
}
