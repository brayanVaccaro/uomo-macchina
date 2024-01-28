using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    public class EventoQuery
    {
        public Guid IdCurrentUser { get; set; }
        public string Filter { get; set; }
    }

    public class EventiDTO
    {
        public IEnumerable<EventoDTO> Eventi { get; set; }
        public int Count { get; set; }

    }

    public class EventoDTO
    {
        public Guid Id { get; set; }
        public String StartDate { get; set; }  //da usare in locale
        public String EndDate { get; set; } //da usare in locale
        public String StartTime { get; set; } //da usare in locale
        public String EndTime { get; set;} //da usare in locale
        public string Title { get; set; }
        public string Content { get; set; }
        public string CssClass { get; set; }
        public bool? Background { get; set; }
        public string Split { get; set; }
        public bool? AllDay { get; set; }
        public bool? Deletable { get; set; }
        public bool? Resizable { get; set; }

    }

    public partial class SharedService
    {
        /// <summary>
        /// Ritorna gli eventi
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<EventiDTO> GetAllEvents()
        {

            var risultato = new EventiDTO();
            try
            {
                risultato.Eventi = await _dbContext.VueCalEvent.Select(x => new EventoDTO
                {
                    Id = x.Id,

                    StartDate = x.Start.ToString("yyyy-MM-dd"), //da usare in locale
                    StartTime = x.Start.ToString("HH:mm"), //da usare in locale
                    EndDate = x.End.ToString("yyyy-MM-dd"), //da usare in locale
                    EndTime = x.End.ToString("HH:mm"), //da usare in locale
                    Title = x.Title,
                    Content = x.Content,
                    CssClass = x.Class,
                    Background = x.Background,
                    Split = x.Split,
                    AllDay = x.AllDay,
                    Deletable = x.Deletable,
                    Resizable = x.Resizable,
                }).ToArrayAsync();
                risultato.Count = await _dbContext.VueCalEvent.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }
    }


}
