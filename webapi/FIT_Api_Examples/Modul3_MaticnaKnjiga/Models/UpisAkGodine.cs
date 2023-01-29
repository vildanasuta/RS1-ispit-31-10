﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;

namespace FIT_Api_Examples.Modul2.Models
{
    public class UpisAkGodine
    {

        [Key]
        public int id { get; set; }
        public DateTime? datum2_ZimskiOvjera { get; set; }
        public DateTime? datum1_ZimskiUpis { get; set; }
        public int godinaStudija { get; set; }

        [ForeignKey(nameof(student))]
        public int studentId { get; set; }
        public Student student { get; set; }

        [ForeignKey(nameof(akademskaGodina))]
        public int akademskaGodinaId { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }

        public float? cijenaSkolarine { get; set; }

        [ForeignKey(nameof(evidentiraoKorisnik))]
        public int evidentiraoKorisnikId { get; set; }
        public KorisnickiNalog evidentiraoKorisnik { get; set; }

        public bool obnovaGodine { get; set; }
    }
}
