using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dominio1;

namespace negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
			List<Elemento>lista = new List<Elemento>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.SetearConsulta("select id, Descripcion from Elementos");
				datos.EjecutarLectura();

				while (datos.Lector.Read())
				{
					Elemento aux = new Elemento();
					aux.id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.CerrarConexion();
			}
        }

    }
}
