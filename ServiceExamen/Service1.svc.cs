using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Data.SqlClient;
using System.Data;


namespace ServiceExamen
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        string IService1.AgregarCliente(clientes reg)
        {
            string msg = "";
            using (SqlConnection cn = new SqlConnection("server=.;database=negocios2017;uid=sa;pwd=sql")) {

                try
                {
                    SqlCommand cmd = new SqlCommand("USP_AGREGARCLIENTEF", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",reg.idcliente);
                    cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                    cmd.Parameters.AddWithValue("@dir", reg.direccion);
                    cmd.Parameters.AddWithValue("@idp", reg.idpais);
                    cmd.Parameters.AddWithValue("@tel", reg.telefono);
                    cn.Open();

                    cmd.ExecuteNonQuery();
                    msg = "Agregado";
                    
                }
                catch (Exception e)
                {
                    msg = e.Message;

                }
                finally {
                    cn.Close();

                }
                
            }
            
            return msg;
        }

        string IService1.EliminarCliente(string id)
        {
            string msg = "";
            using (SqlConnection cn = new SqlConnection("server=.;database=negocios2017;uid=sa;pwd=sql"))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ELIMINARF", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                   
                    cn.Open();

                    cmd.ExecuteNonQuery();
                    msg = "Eliminado";

                }
                catch (Exception e)
                {
                    msg = e.Message;

                }
                finally
                {
                    cn.Close();

                }

            }

            return msg;
        }

        List<clientes> IService1.listaClientes()
        {
            List<clientes> lista = new List<clientes>();
            using (SqlConnection cn = new SqlConnection("server=.;database=negocios2017;uid=sa;pwd=sql"))
            {

                SqlCommand cmd = new SqlCommand("USP_LISTACLIENTEF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    clientes reg = new clientes();
                    reg.idcliente = dr.GetString(0);
                    reg.nombrecia = dr.GetString(1);
                    reg.direccion = dr.GetString(2);
                    reg.nombrepais = dr.GetString(3);
                    reg.telefono = dr.GetString(4);
                    lista.Add(reg);
                }
                dr.Close();
                cn.Close();
            }

            return lista;
        }

        List<paises> IService1.listaPaises()
        {
            List<paises> lista = new List<paises>();
            using (SqlConnection cn = new SqlConnection("server=.;database=negocios2017;uid=sa;pwd=sql"))
            {

                SqlCommand cmd = new SqlCommand("USP_LISTAPAISESF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    paises reg = new paises();
                    reg.idpais = dr.GetString(0);
                    reg.nombrepais = dr.GetString(1);
                  
                    lista.Add(reg);
                }
                dr.Close();
                cn.Close();
            }

            return lista;
        }
    }
}
