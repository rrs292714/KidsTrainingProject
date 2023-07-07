import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-adminhome',
  templateUrl: './adminhome.component.html',
  styleUrls: ['./adminhome.component.css']
})
export class AdminhomeComponent {

  constructor(private auth:AuthService,private route:Router){}
  logout(){
    this.auth.logout();
    this.route.navigate(['/']);
  }
}
