import { Routes } from '@angular/router';
import { LoginPageComponent } from './page/loginpage/login-page.component';
import { profilePageComponent } from './page/profilepage/profile-page.component';
import { registerPageComponent } from './page/registerpage/register/registerpage.component';

export const routes: Routes = [
{path:'login',component:LoginPageComponent},
{path:'profile',component:profilePageComponent},
{path:'register',component:registerPageComponent}
];
