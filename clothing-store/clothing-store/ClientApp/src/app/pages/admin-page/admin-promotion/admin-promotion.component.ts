import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
declare var $:any;

@Component({
  selector: 'app-admin-promotion',
  templateUrl: './admin-promotion.component.html',
  styleUrls: ['./admin-promotion.component.scss']
})
export class AdminPromotionComponent implements OnInit {

  promotions: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 3,
    totalPages: 0,
  };

  promotion: any = {
    promotionId: 0,
    promotionName: "meo",
    discountPercent: 0.0,
    salePercent: "",
    discount: 0,
  };

  isEdit: boolean = true; 

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {}

  ngOnInit() {
    this.searchPromotion(1);
  }

  searchPromotion(cPage) {
    let x = {
      page: cPage,
      size: 3,
      keyword: "",
    };
    this.http
      .post("https://localhost:44320/" + "api/Promotion/search-promotion", x)
      .subscribe(
        (result) => {
          this.promotions = result;
          this.promotions = this.promotions.data;
          console.log(this.promotions);
        },
        (error) => console.error(error)
      );
  }

  searchNext() {
    if (this.promotions.page < this.promotions.totalPages) {
      let nextPage = this.promotions.page + 1;
      let x = {
        page: nextPage,
        size: 3,
        keyword: "",
      };
      this.http
        .post("https://localhost:44320/api/Promotion/search-promotion", x)
        .subscribe(
          (result) => {
            this.promotions = result;
            this.promotions = this.promotions.data;
          },
          (error) => console.error(error)
        );
    } else {
      alert("Bạn đang ở trang cuối cùng!");
    }
  }

  searchPrevious() {
    if (this.promotions.page > 1) {
      let nextPage = this.promotions.page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: "",
      };
      this.http
        .post("https://localhost:44320/api/Promotion/search-promotion", x)
        .subscribe(
          (result) => {
            this.promotions = result;
            this.promotions = this.promotions.data;
          },
          (error) => console.error(error)
        );
    } else {
      alert("Bạn đang ở trang đầu tiên!");
    }
  }

  deleteModal(index)
  {
    this.promotion = index;
    $('#myModal').modal("show");
  }

  openModal(isNew, index)
  {
    if(isNew)
    {
      this.isEdit = false
      this.promotion = {
        promotionId: 0,
        promotionName: "",
        discount: 0,
      };
    }
    else
    {
      this.isEdit = true;
      this.promotion = index;
    }
    $('#Modal').modal("show");
  }

  addPromotion()
  {
    var x = this.promotion;
    this.promotion.discountPercent = this.promotion.discount / 100;
    console.log(x);
    this.http.post('https://localhost:44320/api/Promotion/create-promotion', x).subscribe(result=>{
        var res:any = result;
        if(res.success){
          alert("New product have been added successfully!");
          $('#Modal').modal("hide")
          this.promotion = res.data;
          this.isEdit = true;
          this.searchPromotion(1);
          ;
        }
      }, error => console.error(error));
  }

  updatePromotion()
  {
    var x = this.promotion;
    this.promotion.discountPercent = this.promotion.discount / 100;
    console.log(x);
    this.http.post('https://localhost:44320/api/Promotion/update-promotion', x).subscribe(result=>{
        var res:any = result;
        if(res.success){
          this.promotion = res.data;
          this.isEdit = true;
          this.searchPromotion(1);
          alert("New product have been saved successfully!");
          $('#Modal').modal("hide");
        }
      }, error => console.error(error));
  }

  deletePromotion()
  {
    console.log(this.promotion.promotionId);
    this.http.post('https://localhost:44320/api/Promotion/delete-promotion', this.promotion.promotionId)
    .subscribe(result=>{
        var res:any = result;
        if(res.success){
          this.searchPromotion(1);
          alert("New product have been deleted successfully!");
        }
      }, error => console.error(error));
  }
}
