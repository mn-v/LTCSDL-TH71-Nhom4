import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { WomenComponent } from '../women/women.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  product: any = {
    data: []
  }
  
  size:any;
  quanity:any;
  
  constructor(private activateRoute: ActivatedRoute, private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) { 

  }

  ngOnInit() {
    this.activateRoute.paramMap.subscribe(params => {
      let productId = params.get('id')
      this.detail(productId);
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
    let x =  {
      Size:this.size,
      UnitPrice:this.product.price,
      Quantity:this.quanity,
      ProductID:this.product.productId,
      UserID:1
    }
  }

}
