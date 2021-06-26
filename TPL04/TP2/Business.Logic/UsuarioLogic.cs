using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

         UsuarioAdapter _UsuarioData;

            public  UsuarioAdapter UsuarioData
            {
                get
                {
                    return _UsuarioData;
                }
                set
                {
                    _UsuarioData = value;
                }
            }


         

            public  Usuario GetOne(int ID)
            {
                 return UsuarioData.GetOne(ID);
            }

             public List<Usuario> GetAll()
            {
                     return UsuarioData.GetAll();
            }

            public void Save(Usuario UsuarioIngresado)
            {
                UsuarioData.Save(UsuarioIngresado); 
            }
 
            public void Delete(int ID)
            {
                UsuarioData.Delete(ID);
            }
        }


    }

