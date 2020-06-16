import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-women',
  templateUrl: './women.component.html',
})
export class WomenComponent implements OnInit {
  public res: any;
  public lstCategoryName: [];
  public lstProduct: [];
  flag:string ="1";
  categoryName = "";

  products: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    totalPages: 0
  }

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {

  }

  ngOnInit() {
    this.searchProductByGender(1);
  }

  //lay danh sach san pham theo ten cua loai san pham chon o phan loai
  getProduct(cPage, name) {
    let x = {
      page: cPage,
      size: 3,
      keyword: "",
      categoryName: name,
      gender: true
    }
    this.http.post('https://localhost:44320/' + 'api/Products/get-product-by-categoryName-linq', x).subscribe(result => {
      this.flag="1";
      this.categoryName = name;  
      this.products = result;
      this.products = this.products.data;
      console.log(this.products);
    }, error => console.error(error));
  }

  //lay danh sach ten loai san pham de hien thi len phan loai
  getCategoryName(cGender) {
    var x = {
      gender: cGender
    }
    this.http.post('https://localhost:44320/' + 'api/Categories/get-categoryname-by-gender-linq', x)
      .subscribe(result => {
        this.res = result;
        this.lstCategoryName = this.res.data;
      }, error => console.error(error));
  }

  //danh sach tat ca mat hang cua nu, hien len khi load sang trang women
  searchProductByGender(cPage) {
    let x = {
      page: cPage,
      size: 3,
      keyword: "",
      gender: true
    }
    this.http.post("https://localhost:44320/api/Products/search-product-by-gender", x).subscribe(result => {
      this.flag="2";  
      this.products = result;
      this.products = this.products.data;
      console.log(this.products);
    }, error => console.error(error));
  }

  //chia lam 2 truong hop:
  // flag = 1 : phan trang theo phan loai san pham
  // flag = 2 : phan trang theo san pham nu
  searchNext() {
    if (this.flag == "1") {
      if (this.products.page < this.products.totalPages) {
        let nextPage = this.products.page + 1;
        let x = {
          page: nextPage,
          size: 3,
          keyword: "",
          categoryName: this.categoryName,
          gender: true
        }
        this.http.post('https://localhost:44320/' + 'api/Products/get-product-by-categoryName-linq', x).subscribe(result => {
          this.products = result;
          this.products = this.products.data;
          console.log(this.products);
        }, error => console.error(error));
      }
      else {
        alert("Bạn đang ở trang cuối cùng!");
      }
    }
    else {
      if (this.products.page < this.products.totalPages) {
        let nextPage = this.products.page + 1;
        let x = {
          page: nextPage,
          size: 3,
          keyword: "",
          gender: true
        }
        this.http.post("https://localhost:44320/api/Products/search-product-by-gender", x).subscribe(result => {
          this.products = result;
          this.products = this.products.data;
          console.log(this.products);
        }, error => console.error(error));
      }
      else {
        alert("Bạn đang ở trang cuối cùng!");
      }
    }
  }

  //tuong tu searchNext()
  searchPrevious() {
    if(this.flag == "1"){
      if (this.products.page > 1) {
        let previous = this.products.page - 1;
        let x = {
          page: previous,
          size: 3,
          keyword: "",
          categoryName: this.categoryName,
          gender: true
        }
        this.http.post('https://localhost:44320/' + 'api/Products/get-product-by-categoryName-linq', x).subscribe(result => {
          this.products = result;
          this.products = this.products.data;
          console.log(this.products);
        }, error => console.error(error));
      }
      else {
        alert("Bạn đang ở trang đầu tiên!");
      }
    }
    else{
      if (this.products.page > 1) {
        let previous = this.products.page - 1;
        let x = {
          page: previous,
          size: 3,
          keyword: "",
          gender: true
        }
        this.http.post("https://localhost:44320/api/Products/search-product-by-gender", x).subscribe(result => {
          this.products = result;
          this.products = this.products.data;
          console.log(this.products);
        }, error => console.error(error));
      }
      else {
        alert("Bạn đang ở trang đầu tiên!");
      }
    }
  }
}