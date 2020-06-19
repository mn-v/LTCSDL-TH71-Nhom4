import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin-user',
  templateUrl: './admin-user.component.html',
})
export class AdminUserComponent implements OnInit{

  users: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    totalPages: 0
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  }

  ngOnInit() {
    this.searchUser(1);
  }


  searchUser(cPage) {
    var x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post('https://localhost:44320/api/Users/search-user', x)
      .subscribe(result => {
        var res: any = result;
        console.log(res);
        if (res.success) {
          this.users = res.data;
        }
        else {
          alert(res.message);
        }
      }, error => console.error(error));
  }
}