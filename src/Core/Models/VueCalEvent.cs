using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class VueCalEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Start { get; set; } //formato YYYY/MM/DD hh:mm
        public DateTime End { get; set; }
        public string Title { get; set; } //Optional
        public string Content { get; set; } //Optional

        public string Class { get; set; } // Optional - space-separated css classes.
        public bool? Background { get; set; } // Optional. (Event type not CSS property)
        public string Split { get; set; } // Optional.
        public bool? AllDay { get; set; }// Optional.
        public bool? Deletable { get; set; }// optional - force undeletable when events are editable.
        public bool? Resizable { get; set; } // optional - force unresizable when events are editable.
    }
}
