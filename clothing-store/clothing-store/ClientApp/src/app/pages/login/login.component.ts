import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
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
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private cookieService: CookieService) {

  }

  login() {
    var x = {
      username: this.user,
      password: this.pass
    };

    this.http.post('https://localhost:44320/api/Users/check-tai-khoan', x)
      .subscribe(result => {
        var res: any = result;
        console.log(res);
        this.result = res.data;
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
  }
}