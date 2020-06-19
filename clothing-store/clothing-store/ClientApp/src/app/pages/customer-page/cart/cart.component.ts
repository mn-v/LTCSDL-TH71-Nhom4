import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  userId:any;
  cart: any = {
    data: []
  };

  constructor(private activateRoute: ActivatedRoute, private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string, private cookieService: CookieService) { 

  }

  ngOnInit() {
    this.userId = parseInt(this.cookieService.get("userId"));
    this.getCart(this.userId);
  }

  getCart(id){
    console.log(id);
    this.http.get("https://localhost:44320/api/Carts/get-cart/"+ id, id).subscribe(result => {
      this.cart = result;
      this.cart = this.cart.data;
      console.log(this.cart);
      }, error => console.error(error));
  }

}
