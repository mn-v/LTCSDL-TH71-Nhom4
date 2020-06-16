import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
})
export class SignupComponent {

  users: any = {
    userName: null,
    passWord: null,
    email: null,
    dob: null,
    phoneNumber: null,
    roleId: 1
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }
  addUser() {
    var x = this.users;
    this.http.post('https://localhost:44320/api/Users/create-user', x)
      .subscribe(result => {
        var res: any = result;
        console.log(res);
        if (res.success) {
          alert("Dang ki thanh cong!")
          this.users = res.data;
        }
        else {
          alert("Dang ki khong thanh cong!");
        }
      }, error => console.error(error));

  }
}
