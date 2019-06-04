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
    public class UbicacionesBLL
    {

        public static bool Guardar (Ubicaciones ubicaciones)
        {
            bool paso = true;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.ubicaciones.Add(ubicaciones) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;

            }
            finally {
                contexto.Dispose();
            }
            return paso;
        }
        
        public  static bool Modificar (Ubicaciones ubicaciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(ubicaciones).State = EntityState.Modified;
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
                var Eliminar = contexto.ubicaciones.Find(Id);
                contexto.Entry(Eliminar).State = EntityState.Deleted;
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
        public static Ubicaciones Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Ubicaciones ubicaciones = new Ubicaciones();
            try
            {
                ubicaciones = contexto.ubicaciones.Find(Id);
            }
            catch (Exception)
            {
                throw;


            }
            finally
            {
                contexto.Dispose();

            }
            return ubicaciones;
        }
        public static List<Ubicaciones>GetList(Expression<Func<Ubicaciones,bool>> ubicaciones)
        {


            List<Ubicaciones> Lista = new List<Ubicaciones>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.ubicaciones.Where(ubicaciones).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
            }
}
