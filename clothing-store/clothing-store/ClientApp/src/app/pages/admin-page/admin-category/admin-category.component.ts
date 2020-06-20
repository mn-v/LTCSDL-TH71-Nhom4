import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-admin-category',
  templateUrl: './admin-category.component.html',
})
export class AdminCategoryComponent implements OnInit {

  categories: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0,
  };

  category: any = {
    productId: "1",
    categoryId: "1",
    productName: "Áo thun",
    price: "250000",
    stock: "20",
    dateCreate: "",
  };
  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) { }

  ngOnInit() {
  }

  searchCategory(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: "",
    };
    
  }

}
