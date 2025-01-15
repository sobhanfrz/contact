import { Component } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { userloginmodel } from "../../model/user-login-model";
import { userservice } from "../../service/user-service";
import { Router } from "@angular/router";

@Component ({ 
    imports:[ReactiveFormsModule],
selector:'login-page',
templateUrl:'./login-page.component.html',
styleUrl:'login-page.component.css'
})

export class LoginPageComponent{
    constructor(private userservice:userservice,private router:Router){}
loginform = new FormGroup({
    username:new FormControl('',Validators.required),
    password:new FormControl('')
})
login()
{
    console.log(this.loginform.valid)
    
let request : userloginmodel = {
username:this.loginform.value.username as string ,
password:this.loginform.value.password as string
    }
    this.userservice.postLogin(request).subscribe((response)=>{
        if(response.success)
        {
            
     //تا اینجا
//چه طوری میشه پسوورد رو برگردوند به حالت اینتجر 
     sessionStorage.setItem('userid',response.data.toString());
this.router.navigate(['profile']);
        }
        else{
            alert(response.errormessage);
        }
    });
}
}

