import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { WomenComponent } from '../women/women.component';
import { CookieService } from 'ngx-cookie-service';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  product: any = {
    data: []
  };

  cart: any = {
    data: []
  };
  
  userId:any;
  size:any;
  quanity:any;
  sizeTK:any;
  
  constructor(private activateRoute: ActivatedRoute, private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string, private cookieService: CookieService) { 

  }

  ngOnInit() {
    this.activateRoute.paramMap.subscribe(params => {
      let productId = params.get('id')
      this.detail(productId);
      this.userId = parseInt(this.cookieService.get("userId"));
      
    })
  }

  detail(id) {
    this.http.post("https://localhost:44320/api/Products/get-by-id/" + id, id).subscribe(result => {
      this.product = result;
      this.product = this.product.data;
    }, error => console.error(error));
    
  }

  AddProductCart() {
      this.activateRoute.paramMap.subscribe(params => {
        let productId = params.get('id')
        this.detail(productId);
      })
      
      
      if  (this.quanity == 0) {
        this.quanity = 1;
      }


      if (this.size == 2) {
        this.sizeTK = "S";
      } 
      else
        if (this.size == 1) {
          this.sizeTK = "M";
        } 
        else
          if (this.size == 3) {
            this.sizeTK = "L";
          }
          else
            this.sizeTK = "M";
      let x =  {
        Size:this.sizeTK,
        UnitPrice:this.product.price,
        Quantity:this.quanity,
        ProductID:this.product.productId,
        UserID: this.userId
      }

      this.http.post("https://localhost:44320/api/Carts/create-cart" , x).subscribe(result => {
        this.cart = result;
        this.cart = this.cart.data;
      }, error => console.error(error));
    }
    
    
       
       

}
