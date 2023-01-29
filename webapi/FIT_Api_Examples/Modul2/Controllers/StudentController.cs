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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult GetAll(string ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime))
                .OrderByDescending(s => s.id)
                .Select(s => new
                {
                    id = s.id,
                    ime = s.ime,
                    prezime = s.prezime,
                    opstina_rodjenja = s.opstina_rodjenja,
                    opstina_rodjenja_id = s.opstina_rodjenja_id,
                    broj_indeksa = s.broj_indeksa,
                    datum_rodjenja = s.created_time,
                    slika_korisnika = s.slika_korisnika


                })
                .AsQueryable();


            return Ok(data.Take(100).ToList());
        }
        [HttpPost("{id}")]
        public ActionResult Obrisi(int id)
        {
            _dbContext.Remove(_dbContext.Student.Find(id));
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPost("{id}")]
        public ActionResult Spasi(int id, [FromBody] StudentAddVM studentAddVM)
        {
            if (id == 0)
            {
                Student s = new Student();
                s.ime = studentAddVM.ime;
                s.prezime = studentAddVM.prezime;
                s.broj_indeksa = studentAddVM.broj_indeksa;
                s.opstina_rodjenja_id = studentAddVM.opstina_rodjenja_id;
                _dbContext.Student.Add(s);
                _dbContext.SaveChanges();
            }
            Student student = _dbContext.Student.Find(id);
            if (student != null)
            {
                student.ime = studentAddVM.ime;
                student.prezime = studentAddVM.prezime;
                student.broj_indeksa = studentAddVM.broj_indeksa;
                student.opstina_rodjenja_id = studentAddVM.opstina_rodjenja_id;
                _dbContext.Student.Update(student);
                _dbContext.SaveChanges();
                _dbContext.SaveChanges();
            }
            return Ok();

        }
        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            Student s = _dbContext.Student.Find(id);
            return s;
        }



    }
}
