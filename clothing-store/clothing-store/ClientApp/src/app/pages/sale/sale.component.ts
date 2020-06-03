import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
})
export class SaleComponent implements OnInit {
  products: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    totalPage: 0
  }

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchProduct(1);
  }

  searchProduct(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post("https://localhost:44320/api/Products/search-product", x).subscribe(result => {
      this.products = result;
      this.products = this.products.data;
    }, error => console.error(error));
  }

  searchNext() {
    if (this.products.page < this.products.totalPage) {
      let nextPage = this.products.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44320/api/Products/search-product", x).subscribe(result => {
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
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44320/api/Products/search-product", x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang đầu tiên!");
    }
  }
}
