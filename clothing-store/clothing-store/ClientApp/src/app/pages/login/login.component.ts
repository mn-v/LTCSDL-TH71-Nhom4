import { Component, OnInit, Inject } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  headerFooter: boolean;


  user: string = null;
  pass: string = null;
  result: any = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }

  dangnhap() {
    var x = {
      user: this.user,
      pass: this.pass
    };

    this.http.post('https://localhost:44320/api/Users/check-tai-khoan', x)
      .subscribe(result => {
        var res: any = result;
        console.log(res);
        this.result = res.data;
        if (res.data.find(ds => ds.roleID == 0))
          window.open('https://localhost:44320/admin');
        else if (res.data.find(ds => ds.roleID == 1))
          window.open('https://localhost:44320/');
      }, error => console.error(error));
  }



}
