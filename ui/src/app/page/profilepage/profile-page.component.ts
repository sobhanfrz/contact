import { Component, OnInit } from "@angular/core";
import { userservice } from "../../service/user-service";

@Component ({
selector:'profile-page',
templateUrl:'./profile-page.component.html',
styleUrl:'profile-page.component.css'
})

export class profilePageComponent implements OnInit{
constructor(private userservice: userservice){}
username="";
fullname="";
avatar="";
    ngOnInit() {
    
        this.userservice.getprofile().subscribe((response)=>
        
        {
        this.username=response.data.username;
        this.fullname=response.data.fullname;
        this.avatar=response.data.avatar;
        }
        
        );
      
    }

}