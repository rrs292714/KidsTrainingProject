import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-addgames',
  templateUrl: './addgames.component.html',
  styleUrls: ['./addgames.component.css']
})
export class AddgamesComponent implements OnInit {
  gamesform!:FormGroup;
  constructor(private fb:FormBuilder,private api:ApiService){}

  ngOnInit() {
    this.gamesform=this.fb.group({
      gameName:['',Validators.required],
      gamePrice:['',Validators.required]
    })
  }

  OnAdd(){
    this.api.add(this.gamesform.value).subscribe(x=>{
      alert("Product addded");
      this.gamesform.reset();
    })
  }
}
