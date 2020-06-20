import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import * as bcrypt from 'bcryptjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  headerFooter: boolean;
  usertk: any = {
    data: []
  };

  user: string = null;
  pass: string = null;
  result: any = [];
  constructor(private http: HttpClient, @Inject('BASE_URL')
   baseUrl: string, private cookieService: CookieService) {

  }

  login() {
    var x = {
      username: this.user,
      password: this.pass
    };

    // Kiều
    this.http.post('https://localhost:44320/api/Users/check-tai-khoan', x)
      .subscribe(result => {
        var res: any = result;
        var userId;
        if (res.data.find(u => u.roleId == 1)) {
          alert("Bạn đang được chuyển hướng với quyền truy cập của Admin!")
          window.open('https://localhost:44320/admin');
        }
        else if (res.data.find(u => u.roleId == 2)) {
          alert("Đăng nhập thành công!")
          window.open('https://localhost:44320/');

          //Lấy userId
          this.http.post("https://localhost:44320/api/Users/get-userId", x).subscribe(result => {
            this.usertk = result;
            this.usertk = this.usertk.data;
          }, error => console.error(error));

          // Lưu userId
          userId = this.usertk.userId;
          this.cookieService.set("userId", userId);
        }
        else alert("Tài khoản hoặc mật khẩu không đúng!");
      }, error => console.error(error));


      // Phước
        this.http.post('https://localhost:44320/api/Users/check-tai-khoan', x)
      .subscribe(result => {
        var res: any = result;
        var userId;
        this.result = res.data;
        if (res.success && res.data.length > 0) {
          bcrypt.compare(x.password, this.result[0].password, (err, res) => {
            if (res == true) {
              if (this.result[0].roleId == 1) {
                alert("Bạn đang được chuyển hướng với quyền truy cập của ADMIN!");
                window.open('https://localhost:44320/admin');
              }
              else {
                alert("Đăng nhập thành công!");
                window.open('https://localhost:44320/');
                userId = (this.result[0].userId).toString();
              }
            }
            else {
              alert("Mật khẩu không đúng!");
              console.log('Error: ', err)
            }
          });
        } else {
          alert("Tài khoản không đúng!!!");
        }
      }, error => error => console.error(error));
  }
}