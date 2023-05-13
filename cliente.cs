using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificacao3
{
    public class Cliente
    {
        private string _nome;
        public Cliente(string nome)
        {
            _nome = nome;
        }

        public string GetNome()
        {
            return _nome;
        }

    }
}
