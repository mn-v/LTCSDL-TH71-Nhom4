import { Component, Inject } from '@angular/core';
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
    roleId: 2
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
          alert("Bạn đã đăng kí thành công!")
          this.users = res.data;
          
        }
        else {
          alert("Đăng kí không thành công!");
        }
      }, error => console.error(error));
  }
}
