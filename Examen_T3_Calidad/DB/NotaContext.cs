using Examen_T3_Calidad.DB.Mapping;
using Examen_T3_Calidad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.DB
{
    public class NotaContext: DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<NotaEtiqueta> NotaEtiquetas { get; set; }
        public NotaContext(DbContextOptions<NotaContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new NotaMap());
            modelBuilder.ApplyConfiguration(new EtiquetaMap());
            modelBuilder.ApplyConfiguration(new NotaEtiquetaMap());
        }
    }
}
