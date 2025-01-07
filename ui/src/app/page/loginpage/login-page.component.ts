import { Component } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule } from "@angular/forms";
import { userloginmodel } from "../../model/user-login-model";
import { userservice } from "../../service/user-service";

@Component ({
    imports:[ReactiveFormsModule],
selector:'login-page',
templateUrl:'./login-page.component.html',
styleUrl:'login-page.component.css'
})

export class LoginPageComponent{
    constructor(private userservice:userservice){}
loginform = new FormGroup({
    username:new FormControl(''),
    password:new FormControl('')
})
login()
{
let request : userloginmodel = {
username:this.loginform.value.username as string ,
password:this.loginform.value.password as string
    }
    this.userservice.getLogin(request).subscribe();
}
}

