using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;
            
        }
        public async Task<Evento> AddEventos(Evento model)
        {
           try
           {
             _geralPersist.Add<Evento>(model);
             
             if(await _geralPersist.SaveChangeAsync())
             {
                return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
             }

             return null;
           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }
          public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if(evento == null) return null;

                model.Id = eventoId;

                _geralPersist.Update(model);

                if(await _geralPersist.SaveChangeAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if(evento == null) throw new Exception("Evento não foi encontrado");

                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByAsync(bool includePalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByAsync(includePalestrante);
                if(eventos == null) return null;

                return eventos;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemasAsync(string tema, bool includePalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemasAsync(tema, includePalestrante);
                if(eventos == null) return null;

                return eventos;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId,includePalestrante);
                if(eventos == null) return null;

                return eventos;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

      
    }
}