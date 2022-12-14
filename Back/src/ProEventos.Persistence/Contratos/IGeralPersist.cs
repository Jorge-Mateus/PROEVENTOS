using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IGeralPersist
    {
        void Add<T>(T Entity) where T: class;
        void Update<T>(T Entity) where T: class;
        void Delete<T>(T Entity) where T: class;
        void DeletRange<T>(T[] Entity) where T: class;
        Task<bool> SaveChangeAsync();


    }
}