using Core.Services.Shared;
using System;
using System.Linq;
using System.Reflection;
using UomoMacchina.Infrastructure;

namespace UomoMacchina.Areas.Main.Data.Shared
{
    public class VueCalEventsViewModel
    {
        public VueCalEventViewModel[] Eventi { get; set; }

        public class VueCalEventViewModel
        {
            public VueCalEventViewModel(EventoDTO vueCalEventDTO)
            {
                Id = vueCalEventDTO.Id;
                StartDate = vueCalEventDTO.StartDate;
                StartTime = vueCalEventDTO.StartTime;
                EndDate = vueCalEventDTO.EndDate;
                EndTime = vueCalEventDTO.EndTime;
                Class = vueCalEventDTO.CssClass;
            }

            public Guid Id { get; set; }
            public string StartDate { get; set; } //formato yyyy-MM-dd 
            public string EndDate { get; set; }//formato yyyy-MM-dd 
            public string StartTime { get; set; } //formato HH:mm
            public string EndTime { get; set; }//formato HH:mm
            public string Class { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public bool? Background { get; set; }
            public string Split { get; set; }
            public bool? AllDay { get; set; }
            public bool? Deletable { get; set; }
            public bool? Resizable { get; set; }

            public AddOrUpdateEventCommand ToAddOrUpdateEventCommand()
            {
                return new AddOrUpdateEventCommand
                {
                    Id = Id,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    StartTime = StartTime,
                    EndTime = EndTime,
                    Title = Title,
                    Content = Content,
                    AllDay = AllDay,
                    Deletable = Deletable,
                    Resizable = Resizable,
                    Background = Background,
                    Split = Split,
                    CssClass = Class,
                };
            }

            
        }
        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }
        internal void SetEventi(EventiDTO EventiDTO)
        {
            Eventi = EventiDTO.Eventi.Select(x => new VueCalEventViewModel(x)).ToArray();

        }
    }
}
