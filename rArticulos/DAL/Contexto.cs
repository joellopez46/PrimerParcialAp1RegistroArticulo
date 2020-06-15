using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RegistroArticulos.Entidades;

namespace RegistroArticulos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuiler)
        {
            optionBuiler.UseSqlite(@"Data Source= DATA\BaseDeDatos.db");
        }
    }
}
