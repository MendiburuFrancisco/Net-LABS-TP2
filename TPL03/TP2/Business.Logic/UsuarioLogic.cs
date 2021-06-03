using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
namespace Business.Logic
{
    class UsuarioLogic:BusinessLogic
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

            public void GetOne()
            {

            }

            //public List<Usuario> GetAll()
            //{
            //return 
            // }

        public void Save()
            {

            }

            public void Delete()
            {

            }
        }


    }

