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
        

            Data.Database.UsuarioAdapter _UsuarioData;

            public Data.Database.UsuarioAdapter UsuarioData
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


            public UsuarioLogic()
            {
                //constructor
            }

            public Business.Entities.Usuario GetOne(int ID)
            {
                 return _UsuarioData.GetOne(ID);
            }

        public List<Usuario> GetAll()
        {
            return _UsuarioData.GetAll();
        }

            public void Save(Business.Entities.Usuario UsuarioIngresado)
            {
                        Save(UsuarioIngresado); 
            }
 
            public void Delete(int ID)
            {
                _UsuarioData.Delete(ID);
            }
        }


    }

