import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-admin-products",
  templateUrl: "./admin-products.component.html",
  styleUrls: ["./admin-products.component.scss"],
})
export class AdminProductsComponent implements OnInit {
  products: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0,
  };

  product: any = {
    productId: "1",
    categoryId: "1",
    productName: "Áo thun",
    price: "250000",
    stock: "20",
    dateCreate: "",
  };

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {}

  ngOnInit() {
    this.searchProduct(1);
  }

  searchProduct(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: "",
    };
    this.http
      .post("https://localhost:44320/" + "api/Products/search-product", x)
      .subscribe(
        (result) => {
          this.products = result;
          this.products = this.products.data;
          console.log(this.products);
        },
        (error) => console.error(error)
      );
  }

  searchNext() {
    if (this.products.page < this.products.totalPages) {
      let nextPage = this.products.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: "",
      };
      this.http
        .post("https://localhost:44320/api/Products/search-product", x)
        .subscribe(
          (result) => {
            this.products = result;
            this.products = this.products.data;
          },
          (error) => console.error(error)
        );
    } else {
      alert("Bạn đang ở trang cuối cùng!");
    }
  }

  searchPrevious() {
    if (this.products.page > 1) {
      let nextPage = this.products.page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: "",
      };
      this.http
        .post("https://localhost:44320/api/Products/search-product", x)
        .subscribe(
          (result) => {
            this.products = result;
            this.products = this.products.data;
          },
          (error) => console.error(error)
        );
    } else {
      alert("Bạn đang ở trang đầu tiên!");
    }
  }
}
