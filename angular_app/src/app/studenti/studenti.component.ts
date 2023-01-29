import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
  odabranistudent: any;
  opstinePodaci: any;
  studentZaSlanje:any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  fetchStudenti() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  fetchOpstine() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstinePodaci = x;
    });
  }

  ngOnInit(): void {
    this.fetchStudenti();
    this.fetchOpstine();
  }

  get_podaci_filtrirano() {
    let podaci=this.studentPodaci;
    if(this.filter_ime_prezime && this.ime_prezime!=null){
      return podaci.filter((x:any)=>x.ime.startsWith(this.ime_prezime) || x.prezime.startsWith(this.ime_prezime));
    }
    if(this.filter_opstina && this.filter_opstina!=null){
      return podaci.filter((x:any)=>x.opstina_rodjenja.description.startsWith(this.opstina));
    }
    return podaci;
  }
  uredi(s:any){
    this.studentZaSlanje=s;
    this.studentZaSlanje.prikazi=true;
    
  }
  obrisi(s:any){
    this.httpKlijent.post(MojConfig.adresa_servera+"/Student/Obrisi/"+s.id,s.id).subscribe(x=>{
      console.log("Student obrisan");
      this.fetchStudenti();
    })
  }
  otvoriMaticnu(s:any){
    let id=s.id;
    this.router.navigate(["student-maticnaknjiga",id]);
  }
  novi(){
    this.studentZaSlanje={
      id:0,
      prikazi:true,
      opstina_rodjenja_id:2,
      ime:" ",
      prezime:" "
    }
  }

  
}
