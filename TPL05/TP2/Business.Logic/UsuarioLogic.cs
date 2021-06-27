using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data.SqlClient;
using System.Data;

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
            Usuario usr = new Usuario();
            
            try
            {


                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                     
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuarios"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
 
                }

                drUsuarios.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            //return UsuarioData.GetOne(ID);
            return usr;    
        }
         
         
            public List<Usuario> GetAll()
            {
                try
                {
                    return UsuarioData.GetAll();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                    throw ExcepcionManejada;
                }

            }
   
            public void Save(Usuario usuario)
            {

                if (usuario.State == BusinessEntity.States.Deleted)
                {
                this.Delete(usuario.ID);
                }
                else if (usuario.State == BusinessEntity.States.New)
                {
                this.Insert(usuario);
                } 
                else if (usuario.State == BusinessEntity.States.Modified)
                {
                this.Update(usuario);
                }
            
            usuario.State = BusinessEntity.States.Unmodified;

            }
 
            public void Delete(int ID)
            {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuarios=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }catch(Exception Ex)
            {
                Exception ExcepcionManjeada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManjeada;
            }
            finally
            {
                this.CloseConnection();
            }
                UsuarioData.Delete(ID);
            }

            protected void Update(Usuario usuario)
             {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apeliido, email = @email " + 
                    "WHERE id_usuario = @id " ,sqlConn);

                cmdSave.Parameters.Add("@id",SqlDbType.Int).Value = usuario.ID ;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar,50).Value = usuario.NombreUsuario ;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar,50).Value = usuario.Clave ;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado ;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre ;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido ;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email ;

                cmdSave.ExecuteNonQuery();
            }catch(Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Erorr al modificar datos del usuario", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();

            }

            }

            protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios ( nombre_usuario,clave,habilitado,nombre,apellido,email" +
                    "values(@nombre_usuario, @clave, @habilitado,@nombre,@apellido,@email)" +
                    "select @@identity ", sqlConn);

                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
         
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Erorr al modificar datos del usuario", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                CloseConnection();

            }


        }

