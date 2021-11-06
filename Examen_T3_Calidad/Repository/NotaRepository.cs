using Examen_T3_Calidad.DB;
using Examen_T3_Calidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.Repository
{
    public interface INotaRepository
    {
        public void Create(Nota nota, List<int> etiqueta);
        public void Edit(Nota nota);
        public void Det(int id);
        public void Eliminar(int id);

    }
    public class NotaRepository: INotaRepository
    {
        private readonly NotaContext context;

        public NotaRepository(NotaContext context)
        {
            this.context = context;
        }

        public void Create(Nota nota, List<int> etiqueta)
        {
            List<NotaEtiqueta> etic = new List<NotaEtiqueta>();
            context.Notas.Add(nota);
            context.SaveChanges();
            foreach (var item in etiqueta)
            {
                var etique = new NotaEtiqueta();
                etique.EtiquetaId = item;
                etique.NotaId = nota.Id;
                etic.Add(etique);
            }
            context.NotaEtiquetas.AddRange(etic);
            context.SaveChanges();
        }

        public void Det(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Nota nota)
        {
            nota.Fecha = DateTime.Now;
            context.Notas.Update(nota);
            context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var nota = context.Notas.Where(o => o.Id == id).FirstOrDefault();
            var etiqueta = context.NotaEtiquetas.Where(o => o.NotaId == id).ToList();
            context.Notas.Remove(nota);
            context.NotaEtiquetas.RemoveRange(etiqueta);
            context.SaveChanges();
        }
    }
}
