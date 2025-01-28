import { Component } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { userservice } from "../../../service/user-service";
import { Route, Router } from "@angular/router";
import { useraddmodel } from "../../../model/user-add-model";

@Component ({
    imports:[ReactiveFormsModule],
selector:'register-page',
templateUrl:'./register-page.component.html',
styleUrl:'registerpage.component.css'
})

export class registerPageComponent{
    constructor(private userservice:userservice,private router:Router){}
    url="";
    registerform=new FormGroup(
{
    username:new FormControl('',Validators.required),
    fullname:new FormControl('',Validators.required),
    password:new FormControl('',Validators.required),
    imagedata:new FormControl('')
} )

show(event:any) {
    let file = event.target.files[0];

    let reader = new FileReader();

    reader.readAsDataURL(file);
    
    reader.onload = (e) => {
        if (e.target) {
            this.url=e.target.result as string;
        }
    };
   
}

register()
{
    if (this.registerform.invalid) {
        this.markAllAsTouched(); // لمس همه فیلدها برای نمایش پیام‌های خطا
        alert('لطفاً همه فیلدها را به‌طور کامل تکمیل کنید.'); // پیام به کاربر
        return;
      }
let request:useraddmodel= {

username:this.registerform.value.username as string,
password:this.registerform.value.password as string,
fullname:this.registerform.value.fullname as string,
imagedata:this.url
}
this.userservice.postRegister(request).subscribe((response)=>
{
if(response.success)
{
    this.router.navigate(["login"]);
}
else
{
    alert(response.errormessage);
}

}


)

}
private markAllAsTouched() {
    Object.values(this.registerform.controls).forEach((control) => {
      control.markAsTouched();
    });
}

}