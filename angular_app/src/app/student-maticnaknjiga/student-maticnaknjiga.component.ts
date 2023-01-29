import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {
   studentid: any;
  studentPodaci: any;
  prikazi:any;
  akademske:any;
  datum:any;
  godinaStudija:any;
  akademskaGodinaId:any;
  cijenaSkolarine:any;
  obnova:any;
  podaci:any;
  otvoriOvjeruModal:any;
  datumOvjere:any;
  idOvjereZaPronaci:any;
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    console.log(this.route.params);
    
    this.route.paramMap.subscribe((paramMap) => {
      this.studentid = paramMap.get('studentidbroj');
      this.getStudent();
    });
    this.prikazi=false;
    this.otvoriOvjeruModal=false;
    this.getPodaci();
    this.datumOvjere=new Date().toISOString().slice(0,10);
  }

  getPodaci(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/MaticnaKnjigaDetalji/GetAll/"+this.studentid,this.studentid)
    .subscribe(x=> {
        this.podaci=x;
        }
    )
  }

  getStudent = () => {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Student/GetById/"+this.studentid).subscribe(x=>
      {
        this.studentPodaci=x;
      });
  }
  otvori(){
    this.prikazi=true;
    this.httpKlijent.get(MojConfig.adresa_servera+"/AkademskeGodine/GetAll_ForCmb").subscribe(x=>{
      this.akademske=x;
    })
  }
  upis(){
    let upis={
      datum:this.datum,
      godinaStudija:this.godinaStudija,
      akademskaGodinaId:this.akademskaGodinaId,
      cijenaSkolarine:this.cijenaSkolarine,
      obnova:this.obnova
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/MaticnaKnjigaDetalji/Dodaj/"+this.studentid,upis).subscribe(x=>{
      if(x) this.getPodaci();
    })
    this.prikazi=false;
  }
  otvoriOvjeru(idOvjere:any){
    this.otvoriOvjeruModal=true;
    this.idOvjereZaPronaci=idOvjere;
  }
  ovjeri(){
    this.httpKlijent.post(MojConfig.adresa_servera+"/MaticnaKnjigaDetalji/Ovjeri/"+this.idOvjereZaPronaci,this.datumOvjere).subscribe(
      x=>{
        if(x) this.getPodaci();
     })
    this.otvoriOvjeruModal=false;
  }
}
