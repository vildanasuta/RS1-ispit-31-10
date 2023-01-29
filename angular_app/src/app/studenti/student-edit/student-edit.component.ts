import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MojConfig } from 'src/app/moj-config';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})
export class StudentEditComponent implements OnInit {
  @Input() student:any;
  opstine:any;
  constructor(private httpKlijent:HttpClient) { }
  fetchOpstine():any
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstine=x;
    });
  }
  spasi(){
    console.log(this.student);
    this.httpKlijent.post(MojConfig.adresa_servera+"/Student/Spasi/"+this.student.id,this.student).subscribe(x=>{
      console.log(this.student);
    });
    location.reload();
    this.student.prikazi=false;

  }
  ngOnInit(): void {
    this.fetchOpstine();
    console.log(this.opstine);
  }
  

}
