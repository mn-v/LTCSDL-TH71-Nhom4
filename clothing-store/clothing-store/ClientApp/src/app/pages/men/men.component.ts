import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-men',
  templateUrl: './men.component.html',
})
export class MenComponent implements OnInit {

  public res:any;
  public lstCategoryName : [];
  public lstProduct: [];

  products: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 3,
    totalPages: 0
  }

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
      
    }

  ngOnInit() {
    this.searchProductByGender(1);
    this.getCategoryName(false);
  }

  getProduct(cPage, name){
    let x = {
      page: cPage,
      size: 3,
      keyword: "",
      categoryName: name,
      gender: false
    } 
    this.http.post('https://localhost:44320/' + 'api/Products/get-product-by-categoryName-linq', x).subscribe(result => {
      this.res = result;
      this.lstProduct = this.res.data;
      console.log(this.lstProduct);
    }, error => console.error(error));
  }

  getCategoryName(cGender){
    var x ={
      gender: cGender
    }     
    this.http.post('https://localhost:44320/' + 'api/Categories/get-categoryname-by-gender-linq', x)
    .subscribe(result => {
      this.res = result;
      this.lstCategoryName = this.res.data;
      console.log(this.lstCategoryName);
    }, error => console.error(error));
  }

  searchProductByGender(cPage) {
    let x = {
      page: cPage,
      size: 3,
      keyword: "",
      gender: false
    }
    this.http.post("https://localhost:44320/api/Products/search-product-by-gender", x).subscribe(result => {
      this.products = result;
      this.products = this.products.data;
    }, error => console.error(error));
  }

  searchNext() {
    if (this.products.page < this.products.totalPages) {
      let nextPage = this.products.page + 1;
      let x = {
        page: nextPage,
        size: 3,
        keyword: "",
        gender: false
      }
      this.http.post("https://localhost:44320/api/Products/search-product-by-gender", x).subscribe(result => {
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
        keyword: "",
        gender: false
      }
      this.http.post("https://localhost:44320/api/Products/search-product-by-gender", x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang đầu tiên!");
    }
  }
}