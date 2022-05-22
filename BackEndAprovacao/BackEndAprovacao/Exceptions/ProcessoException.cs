using System;

namespace BackEndAprovacao.Exceptions
{
    public class ProcessoException : Exception
    {


        public ProcessoException(string message):base(message) {}
    }
}
