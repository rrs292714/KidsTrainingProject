import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddgamesComponent } from './addgames/addgames.component';
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GamePageComponent } from './game-page/game-page.component';
import { GamelistComponent } from './gamelist/gamelist.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserhomeComponent } from './userhome/userhome.component';

const routes: Routes = [
  {path:'',component:DashboardComponent,
  children:[
    {
    path:'',component:LoginComponent,
  },
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent}
]},
{path:'adminhome',component:AdminhomeComponent},
  {
    path:'addgames',component:AddgamesComponent
  },
  {
    path:'gamelist',component:GamelistComponent
  },
  {
    path:'userhome',component:UserhomeComponent
  },
  {path:'gamepage',component:GamePageComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
