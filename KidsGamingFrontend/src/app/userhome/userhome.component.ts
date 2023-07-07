import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-userhome',
  templateUrl: './userhome.component.html',
  styleUrls: ['./userhome.component.css']
})
export class UserhomeComponent implements OnInit {
  gamelist!:any;
  editproduct!:any;
  buyform!:any;
  userid!:number;
  membershipform!:any;
  membership!:number;
  email!:any;
  fullname!:any;
  game!:number;
  otpform!:any;
  otp!:any;
  otpdata!:any;

  ticketCount:any;
  ticketdata!:any;
  // Total:number=this.game*this.gamelist.Quantity;
  
  constructor(private api:ApiService,private fb:FormBuilder,private auth:AuthService,private route:Router){

  }
  ngOnInit(){
    this.userid=this.auth.getId();
      this.api.getgames().subscribe(x=>{
      this.gamelist=x;}); 
      this.api.membershipdata(this.userid).subscribe(x=>{
      this.ticketdata=x;});
      this.buyform=this.fb.group({
        gameId:['',Validators.required],
        userId:[this.userid,Validators.required],
        gamePrice:['',Validators.required],
        quantity:['',Validators.required]
      })

      this.otpform=this.fb.group({
        otp:['',Validators.required]
      })

      this.fullname=this.auth.getfullname();
      this.membership=this.auth.getmembership();
      this.email=this.auth.getemail();
      console.log(this.userid);
      this.membershipform=this.fb.group({
      userId:[this.userid]
      });
  }

  Buy(index:number){
    var data=this.gamelist[index];
    console.log(data);
    this.editproduct=data;
    const formfiller={
      gameId:data.gameId,
      gameName:data.gameName,
      gamePrice:data.gamePrice
    };
    this.buyform.patchValue(formfiller);
  }
  
  checkotp(){
    this.otpdata=this.otpform.value;
    if(this.otp==this.otpdata.otp){
      alert("Game Bought!!");
    this.route.navigate(['/gamepage']);
  }
  else{
    alert("wrong Otp!!");
  }
 }

  purchaseMembership(){
    console.log(this.membershipform.value);
       this.api.membership(this.membershipform.value).subscribe({
        next:(res=>{
          alert("Error");
        }),
        error:(err=>{
          alert("membership bought");
          this.membership=2;
          this.api.membershipdata(this.userid).subscribe(x=>{
            this.ticketdata=x;
          });
        })
      })
  }

  logout(){
    this.auth.logout();
    this.route.navigate(['/login']);
  }

  otpgen(){
    this.api.getotp(this.email).subscribe({
      next:(res=>{
        this.otp=res;
        console.log(this.otp);
      }),
      error:(err=>{
        alert("user not found");
      })
    })  
  }

  play(){
    const user={userId:this.userid}
    this.api.playgame(user).subscribe(x=>{
      console.log(x);
      this.api.membershipdata(this.userid).subscribe(x=>{
        this.ticketdata=x;
      });
      this.api.getgames().subscribe(x=>{
        this.gamelist=x});
    })
  }
}