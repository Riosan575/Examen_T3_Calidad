using Examen_T3_Calidad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.DB.Mapping
{
    public class NotaEtiquetaMap: IEntityTypeConfiguration<NotaEtiqueta>
    {
        public void Configure(EntityTypeBuilder<NotaEtiqueta> builder)
        {
            builder.ToTable("NotaEtiqueta");
            builder.HasKey(o => o.Id);
        }
    }
}
