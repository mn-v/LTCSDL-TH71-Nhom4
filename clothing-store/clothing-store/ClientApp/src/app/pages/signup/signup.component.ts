import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as bcrypt from 'bcryptjs';

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
    roleId: 2
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }

  addUser() {
    var x = this.users;
    bcrypt.hash(this.users.passWord, 10, (err, hash) => {
      if (!err) {
        x.passWord = hash;  
        this.http.post('https://localhost:44320/api/Users/create-user', x)
          .subscribe(result => {
            var res: any = result;
            if (res.success) {
              alert("Dang ki thanh cong!")
              window.open('http://localhost:4200/login','_self');
            }
            else {
              alert("Dang ki khong thanh cong!");
            }
          }, error => console.error(error));
      } else {
        alert("Dang ki khong thanh cong!!!");
        console.log('Error: ', err)
      }
    })
  }
}
