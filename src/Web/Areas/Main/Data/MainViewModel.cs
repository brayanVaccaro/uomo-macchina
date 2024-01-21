using Core.Models;
using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UomoMacchina.Areas.Example.Users;
using UomoMacchina.Infrastructure;

namespace UomoMacchina.Areas.Main.Data
{
    public class MainViewModel : PagingViewModel
    {
        public MainViewModel()
        {
            OrderBy = nameof(VueCalEventViewModel.Id);
            OrderByDescending = false;
            VueCalEvents = Array.Empty<VueCalEventViewModel>();
        }
        [Display(Name = "Cerca")]
        public string Filtro { get; set; }

        public VueCalEventViewModel[] VueCalEvents { get; set; }
        
        public override IActionResult GetRoute() => MVC.Main.Main.Main(this).GetAwaiter().GetResult();



        internal void SetVueCalEvents(VueCalEventsDTO vueCalEvenstDTO)
        {
            VueCalEvents = vueCalEvenstDTO.Events.Select(x => new VueCalEventViewModel(x)).ToArray();
            TotalItems = vueCalEvenstDTO.Count;
        }
        public VueCalEventQuery ToVueCalEventQuery()
        {
            return new VueCalEventQuery
            {
                Filter = this.Filtro
            };
        }

        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }

    }
    public class VueCalEventViewModel
    {
        public VueCalEventViewModel(VueCalEventDTO vueCalEventDTO)
        {
            Id = vueCalEventDTO.Id;
            Start = vueCalEventDTO.Start;
            End = vueCalEventDTO.End;

        }

        public Guid Id { get; set; }
        public String Start { get; set; } //formato YYYY/MM/DD hh:mm
        public String End { get; set; }
    }
}
