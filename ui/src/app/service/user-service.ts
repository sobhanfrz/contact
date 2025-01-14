import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { result } from "../model/result";
import { userloginmodel } from "../model/user-login-model";

@Injectable({providedIn:'root'})
export class userservice{
    constructor(private http:HttpClient){}
postLogin(request:userloginmodel){
    let url="https://localhost:50879/user/login"
  return this.http.post<result<number>>(url,request)
}
}