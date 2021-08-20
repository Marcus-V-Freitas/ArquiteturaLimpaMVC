using System;

namespace ArquiteturaLimpaMVC.Dominio.Validacoes
{
    public class ValidacaoDominioException : Exception
    {
        public ValidacaoDominioException(string erro) : base(erro)
        {
        }

        public static void Validar(bool existeErro, string erro)
        {
            if (existeErro)
                throw new ValidacaoDominioException(erro);
        }
    }
}