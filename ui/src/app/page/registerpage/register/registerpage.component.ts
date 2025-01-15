import { Component } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule } from "@angular/forms";
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
    username:new FormControl(''),
    fullname:new FormControl(''),
    password:new FormControl(''),
    imagedata:new FormControl('')
} )

//base64تا اینجا مشکلی که داشتم
//  این بود که آدرس محلی فایل برمیگردوند نه فرمت 
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

}