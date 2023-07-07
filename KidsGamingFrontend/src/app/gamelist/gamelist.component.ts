import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-gamelist',
  templateUrl: './gamelist.component.html',
  styleUrls: ['./gamelist.component.css']
})
export class GamelistComponent implements OnInit{
gamelist!:any;
editform!:any;
role!:any;
editproduct!:any;
constructor(private api:ApiService,private fb:FormBuilder,private auth:AuthService){}
  ngOnInit():void{
    this.api.getgames().subscribe(x=>{
      console.log(x);
      this.gamelist=x});
      this.editform=this.fb.group({
        gameId:['',Validators.required],
        gameName:['',Validators.required],
        gamePrice:['',Validators.required]
      })
      this.role=this.auth.getrole();
      console.log(this.role)  
  }
  
  delete(id:number){
    this.api.deletegame(id).subscribe(x=>{
      alert("game deleted");
      this.api.getgames().subscribe(x=>{
        this.gamelist=x;
      })
    })
  }

  edit(index:number){
    var data=this.gamelist[index];
    console.log(data);
    this.editproduct=data;
    const formfiller={
      gameId:data.gameId,
      gameName:data.gameName,
      gamePrice:data.gamePrice
    };
    this.editform.patchValue(formfiller);
  }

  Buy(id:number){

  }

  submit(){
    this.api.editproduct(this.editform.value).subscribe(x=>{
      this.gamelist=x;
    })
  }
}