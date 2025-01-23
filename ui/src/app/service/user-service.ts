import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { result } from "../model/result";
import { userloginmodel } from "../model/user-login-model";
import { userprofilemodel } from "../model/user-profile-model";
import { useraddmodel } from "../model/user-add-model";

@Injectable({providedIn:'root'})
export class userservice{
    constructor(private http:HttpClient){}
postLogin(request:userloginmodel){
    let url="https://localhost:50879/user/login"
  return this.http.post<result<string>>(url,request)
}
postRegister(request:useraddmodel){
  let url="https://localhost:50879/user/add"
return this.http.post<result<number>>(url,request)
}
getprofile(userid:any){
  let url=`https://localhost:50879/user/profile?userid=${userid}`;
return this.http.get<result<userprofilemodel>>(url)
}
}