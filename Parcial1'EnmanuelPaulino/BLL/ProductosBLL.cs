using Parcial1_EnmanuelPaulino.DAL;
using Parcial1_EnmanuelPaulino.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace Parcial1_EnmanuelPaulino.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.productos.Add(productos) != null)
                {
                   var total = contexto.totalInventarios.Find(1);
                    total.TotalInventario += productos.ValorInventario;
                   paso = (contexto.SaveChanges() > 0);
                }
            }
            catch (Exception)
            { throw;}
            finally
            {contexto.Dispose();}
            return paso;
        }
       public static bool Modificar (Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
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

        public static bool Eliminar (int Id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.productos.Find(Id);
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
        public static Productos Buscar (int Id)
        {

            Contexto contexto = new Contexto();
            Productos productos = new Productos();
            try
            {
                productos = contexto.productos.Find(Id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }
            return productos;

        }


        public static List<Productos> GetList(Expression<Func<Productos, bool>> productos) {

            List<Productos> Lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.productos.Where(productos).ToList();

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
