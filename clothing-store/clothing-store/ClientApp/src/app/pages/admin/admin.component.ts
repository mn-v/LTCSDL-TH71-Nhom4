import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  products: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    totalPages: 0
  }

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    // this.searchProduct(1);
  }
  searchNext() {
    if (this.products.page < this.products.totalPages) {
      let nextPage = this.products.page + 1;
      let x = {
        page: nextPage,
        size: 3,
        keyword: ""
      }
      this.http.post("https://localhost:44320/api/Products/get-product-accessories-linq", x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang cuối cùng!");
    }
  }

  searchPrevious() {
    if (this.products.page > 1) {
      let previous = this.products.page - 1;
      let x = {
        page: previous,
        size: 3,
        keyword: ""
      }
      this.http.post("https://localhost:44320/api/Products/get-product-accessories-linq", x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang đầu tiên!");
    }
  }

}
