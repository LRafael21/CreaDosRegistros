using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RegistroCarreras.Entidades;

namespace RegistroCarreras.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Carreras> Carreras { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"Data Source=Data\Carreras.db");


        }


    }
}