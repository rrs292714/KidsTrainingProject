import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
role!:string;
token:any;
userid!:number;
membership!:number;
fullname!:any;
email!:string;
  constructor(private hc:HttpClient) { }

  login(formdata:any){
    return this.hc.post('https://localhost:7081/api/Auth/login',formdata)
  }

  register(formdata:any){
    return this.hc.post('https://localhost:7081/api/Auth/register',formdata)
  }

  savetoken(tkn:any){
    console.log(tkn.token.value)
    console.log(tkn.role)
    this.role=tkn.role;
    this.token=tkn.token.value;
    this.userid=tkn.id;
    this.membership=tkn.membership;
    this.fullname=tkn.fullName;
    this.email=tkn.email;
    localStorage.setItem('role',this.role);
    localStorage.setItem('token',this.token);
    localStorage.setItem('id',this.userid.toString());
    localStorage.setItem('membership',this.membership.toString());
    localStorage.setItem('fullName',this.fullname);
    localStorage.setItem('email',this.email);
  }

  getemail(){
    return localStorage.getItem('email');
  }
  getfullname(){
    return localStorage.getItem('fullName');
  }
  getmembership(){
    const storedId = localStorage.getItem('membership');
    return storedId ? Number.parseInt(storedId) : 0;
  }
  getrole(){
    return localStorage.getItem('role');
  }
  gettoken(){
  return localStorage.getItem('token');
  }
  getId() {
    const storedId = localStorage.getItem('id');
    return storedId ? Number.parseInt(storedId) : 0;
  }
  logout(){
    localStorage.clear();
  }
}
