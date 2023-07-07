import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
registerForm!:FormGroup

constructor(private fb:FormBuilder,private auth:AuthService){}

  ngOnInit() {
    this.registerForm=this.fb.group({
      FullName:['',Validators.required],
      Email:['',Validators.required],
      Password:['',Validators.required]
    })
    }


    OnRegister(){
      this.auth.register(this.registerForm.value).subscribe(x=>{
        alert("User Registered!");
        this.registerForm.reset();
      })
    }
}
