using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    public class VueCalEventQuery
    {
        public Guid IdCurrentUser { get; set; }
        public string Filter { get; set; }
    }

    public class VueCalEventsDTO
    {
        public IEnumerable<VueCalEventDTO> Events { get; set; }
        public int Count { get; set; }

    }

    public class VueCalEventDTO
    {
        public Guid Id { get; set; }
        public String Start { get; set; }
        public String End { get; set; }
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
        /// Returns events
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<VueCalEventsDTO> Query(VueCalEventQuery qry)
        {

            var risultato = new VueCalEventsDTO();
            try
            {
                risultato.Events = await _dbContext.VueCalEvent.Select(x => new VueCalEventDTO
                {
                    Id = x.Id,
                    Start = x.Start.ToString("yyyy-MM-dd HH:mm"),
                    End = x.End.ToString("yyyy-MM-dd HH:mm"),
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
