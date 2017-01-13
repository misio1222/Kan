using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kancelaria.Models
{
    public class QustionModel
    {
        [Required(ErrorMessage ="Proszę podać imię.")]
        public string imie { get; set; }
        [Required(ErrorMessage ="Proszę podać nazwisko.")]
        public string nazwisko { get; set; }
        [Required(ErrorMessage ="Proszę podać adres email.")]
        public string emailAddress { get; set; }
        [Required(ErrorMessage ="Proszę podać numer telefonu.")]
        public string tel { get; set; }
        [Required(ErrorMessage ="Proszę zadać pytanie.")]
        public string question { get; set; }
        public string file { get; set; }
    }
}