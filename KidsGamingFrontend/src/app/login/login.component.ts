import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginform!:FormGroup

  constructor(private fb:FormBuilder,private auth:AuthService,private route:Router){}
  
    ngOnInit() {
      this.loginform=this.fb.group({
        Email:['',Validators.required],
        Password:['',Validators.required]
      })
      }
   OnLogin(){
    this.auth.login(this.loginform.value).subscribe({
      next:(res=>{
        alert("login")
        console.log(res)
        this.auth.savetoken(res);
        if(this.auth.role=="Admin"){
          this.route.navigate(['/adminhome']);
        }
        else{
          this.route.navigate(['/userhome']);
        }
      }),
      error:(err=>{
        alert("user not found");
      })
    })
  }
}