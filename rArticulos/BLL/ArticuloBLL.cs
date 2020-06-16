using Microsoft.EntityFrameworkCore;
using RegistroArticulos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using RegistroArticulos.Entidades;

namespace RegistroArticulos.BLL
{
   public  class ArticuloBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Articulo.Add(articulos) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Articulos articulo)
        {

            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                db.Entry(articulo).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Articulo.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                db.Dispose();
            }
            return paso;
        }
        public static Articulos Buscar(int id)
        {
            Articulos articulos= new Articulos();
            Contexto db = new Contexto();

            try
            {
                articulos = db.Articulo.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return articulos;

        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulo)
        {
            List<Articulos> Lista = new List<Articulos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Articulo.Where(articulo).ToList();
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

