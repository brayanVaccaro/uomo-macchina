using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using System.Globalization;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace Core.Services.Shared
{
    public class AddOrUpdateEventCommand
    {
        public Guid? Id { get; set; }
        public string StartDate { get; set; }  //da usare in locale
        public string EndDate { get; set; } //da usare in locale
        public string StartTime { get; set; } //da usare in locale
        public string EndTime { get; set; } //da usare in locale
        public string Title { get; set; }
        public string Content { get; set; }
        public string CssClass { get; set; }
        public bool? Background { get; set; }
        public string Split { get; set; }
        public bool? AllDay { get; set; }
        public bool? Deletable { get; set; }
        public bool? Resizable { get; set; }
        public Guid? RendicontazioneId { get; set; }
        public Guid? FeriaId { get; set; }
        public Guid? PermessoId { get; set; }
        public Guid? TrasfertaId { get; set; }

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateEventCommand cmd)
        {
            VueCalEvent vueCalEvent = new();
            switch (cmd)
            {
                case { RendicontazioneId: Guid id }:
                    vueCalEvent = await _dbContext.Eventi.Where(x => x.RendicontazioneId == cmd.RendicontazioneId).FirstOrDefaultAsync();
                    break;
                case { FeriaId: Guid id }:
                    vueCalEvent = await _dbContext.Eventi.Where(x => x.FeriaId == cmd.FeriaId).FirstOrDefaultAsync();
                    break;
                case { PermessoId: Guid id }:
                    vueCalEvent = await _dbContext.Eventi.Where(x => x.PermessoId == cmd.PermessoId).FirstOrDefaultAsync();
                    break;
                case { TrasfertaId: Guid id }:
                    vueCalEvent = await _dbContext.Eventi.Where(x => x.TrasfertaId == cmd.TrasfertaId).FirstOrDefaultAsync();
                    break;
            }

            if (vueCalEvent == null)
            {
                vueCalEvent = new VueCalEvent
                {
                    Start = DateTime.Parse(cmd.StartDate + " " + cmd.StartTime),
                };
                _dbContext.Eventi.Add(vueCalEvent);
            };

            vueCalEvent.Start = DateTime.Parse(cmd.StartDate + " " + cmd.StartTime);
            vueCalEvent.End = DateTime.Parse(cmd.EndDate + " " + cmd.EndTime);
            vueCalEvent.Title = cmd.Title;
            vueCalEvent.Content = cmd.Content;
            vueCalEvent.Class = cmd.CssClass;
            vueCalEvent.Background = cmd.Background;
            vueCalEvent.Split = cmd.Split;
            vueCalEvent.AllDay = cmd.AllDay;
            vueCalEvent.Deletable = cmd.Deletable;
            vueCalEvent.Resizable = cmd.Resizable;
            vueCalEvent.RendicontazioneId = cmd.RendicontazioneId;
            vueCalEvent.FeriaId = cmd.FeriaId;
            vueCalEvent.PermessoId = cmd.PermessoId;
            vueCalEvent.TrasfertaId = cmd.TrasfertaId;

            await _dbContext.SaveChangesAsync();

            return vueCalEvent.Id;
        }

    }
}
