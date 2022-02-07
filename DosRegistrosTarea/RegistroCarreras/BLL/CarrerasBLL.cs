using System;
using RegistroCarreras.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroCarreras.DAL;

namespace RegistroCarreras.BLL
{
    public class CarrerasBLL
    {

        public static bool Existe(int carreraId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Carreras.Any(e => e.CarrerasId == carreraId);

            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;




        }


        private static bool Insertar(Carreras carreras)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Carreras.Add(carreras);
                paso = contexto.SaveChanges() > 0;

            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return paso;

        }

        public static bool Guardar(Carreras carreras)
        {
            if (!Existe(carreras.CarrerasId))
                return Insertar(carreras);
            else
                return Modificar(carreras);

        }

        private static bool Modificar(Carreras carreras)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(carreras).State = EntityState.Modified;
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }
        public static bool Eliminar(int carrerasId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var libro = contexto.Carreras.Find(carrerasId);
                if (libro != null)
                {
                    contexto.Carreras.Remove(libro);
                    paso = contexto.SaveChanges() > 0;
                }
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

        public static Carreras? Buscar(int carrerasId)
        {
            Contexto contexto = new Contexto();
            Carreras? libro;
            try
            {
                libro = contexto.Carreras.Find(carrerasId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return libro;
        }

        public static List<Carreras> GetList(Expression<Func<Carreras, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Carreras> lista = new List<Carreras>();
            try
            {
                lista = contexto.Carreras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }


    }
}


