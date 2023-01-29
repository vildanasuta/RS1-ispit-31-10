using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaticnaKnjigaDetaljiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaDetaljiController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public class Upis
        {
            public DateTime datum { get; set; }
            public int godinaStudija { get; set; }
            public int akademskaGodinaId { get; set; }
            public float cijenaSkolarine { get; set; }
            public bool obnova { get; set; }
        }

        [HttpPost("{id}")]
        public ActionResult Dodaj(int id,[FromBody] Upis u)
        {
            UpisAkGodine upis = new UpisAkGodine();
            Student s = _dbContext.Student.Find(id);
            upis.studentId = s.id;
            upis.akademskaGodinaId = u.akademskaGodinaId;
            upis.datum1_ZimskiUpis = u.datum;
            upis.cijenaSkolarine = u.cijenaSkolarine;
            upis.godinaStudija = u.godinaStudija;
            upis.evidentiraoKorisnik = HttpContext.GetLoginInfo()?.korisnickiNalog;
            upis.evidentiraoKorisnikId = 1;
            _dbContext.Add(upis);
            _dbContext.SaveChanges();
            return Ok(upis);
        }

        [HttpGet("{id}")]
        public List<UpisAkGodine> GetAll(int id)
        {
            return _dbContext.UpisAkGodine.Include(x => x.akademskaGodina).Include(x => x.student)
                .Include(x => x.evidentiraoKorisnik)
                .Where(x=>x.studentId==id).ToList();
        }
        [HttpPost("{id}")]
        public UpisAkGodine Ovjeri(int id,DateTime ovjeraDatum)
        {
            UpisAkGodine ovjeraZimskog = new UpisAkGodine();
            ovjeraZimskog= _dbContext.UpisAkGodine.Find(id);
            ovjeraZimskog.datum2_ZimskiOvjera = ovjeraDatum;
            _dbContext.UpisAkGodine.Update(ovjeraZimskog);
            _dbContext.SaveChanges();
            return ovjeraZimskog;
        }






    }
}
