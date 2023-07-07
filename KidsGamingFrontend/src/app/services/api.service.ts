import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  ticketCount!:any;
  constructor(private hc:HttpClient) { }

  add(formdata:any){
    return this.hc.post('https://localhost:7081/api/Game',formdata);
  }

  getgames(){
    return this.hc.get('https://localhost:7081/api/Game');
  }

  deletegame(id:number){
    return this.hc.delete('https://localhost:7081/api/Game/'+id);
  }

  editproduct(formdata:any){
    return this.hc.put<any>('https://localhost:7081/api/Game/Edit',formdata);
  }

  membership(user:any){
    return this.hc.put('https://localhost:7081/api/Game/membership', user);
  }

  buygame(data:any){
    return this.hc.post('https://localhost:7081/api/Game/Buy',data);
  }

  getotp(email:string){
    return this.hc.get('https://localhost:7081/api/Game/Otp/'+email);
  }

  membershipdata(id:number){
    return this.hc.get('https://localhost:7081/api/Membership/'+id)
  }


  playgame(userid:any){
    return this.hc.put('https://localhost:7081/api/Game/Play',userid)
  }
}
