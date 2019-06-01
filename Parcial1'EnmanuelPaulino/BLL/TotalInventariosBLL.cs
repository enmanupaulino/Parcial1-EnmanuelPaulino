using Parcial1_EnmanuelPaulino.DAL;
using Parcial1_EnmanuelPaulino.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_EnmanuelPaulino.BLL
{
    public class TotalInventariosBLL
    {
        public static bool Guardar(TotalInventarios totalInventarios)
        {
            bool paso = true;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.totalInventarios.Add(totalInventarios) != null)
                    paso = (contexto.SaveChanges() > 0);



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }
        public static bool Modificar(TotalInventarios totalInventarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(totalInventarios).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.totalInventarios.Find(Id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = (contexto.SaveChanges() > 0);


            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static TotalInventarios Buscar(int Id)
        {

            Contexto contexto = new Contexto();
            TotalInventarios totalInventarios = new TotalInventarios();
            try
            {
                totalInventarios = contexto.totalInventarios.Find(Id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }
            return totalInventarios;

        }


        public static List<TotalInventarios> GetList(Expression<Func<TotalInventarios, bool>> totalInventario)
        {

            List<TotalInventarios> Lista = new List<TotalInventarios>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.totalInventarios.Where(totalInventario).ToList();

            }
            catch
            (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
