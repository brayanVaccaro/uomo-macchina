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
        public Guid Id { get; set; }
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

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateEventCommand cmd)
        {
            var vueCalEvent = await _dbContext.Eventi
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (vueCalEvent == null)
            {
                vueCalEvent = new VueCalEvent
                {
                    Id = cmd.Id
                };
            };
            _dbContext.Eventi.Add(vueCalEvent);

            vueCalEvent.AllDay = cmd.AllDay;
            vueCalEvent.Background = cmd.Background;
            vueCalEvent.Class = cmd.CssClass;
            vueCalEvent.Content = cmd.Content;
            vueCalEvent.Deletable = cmd.Deletable;
            vueCalEvent.Resizable = cmd.Resizable;
            vueCalEvent.End = DateTime.Parse(cmd.EndDate + cmd.EndTime, CultureInfo.CurrentCulture);
            vueCalEvent.Title = cmd.Title;
            vueCalEvent.Split = cmd.Split;
            vueCalEvent.Start = DateTime.Parse(cmd.StartDate + cmd.StartTime, CultureInfo.CurrentCulture);

            await _dbContext.SaveChangesAsync();

            return vueCalEvent.Id;
        }

    }
}
