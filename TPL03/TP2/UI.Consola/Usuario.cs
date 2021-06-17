using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuario

    {
        Usuario()
        {
            UsuarioLogic nuevoUsuario = UsuarioNegocio;
        }

        private UsuarioLogic _UsuarioNegocio;
 
        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value;  }
        }


    }
}
