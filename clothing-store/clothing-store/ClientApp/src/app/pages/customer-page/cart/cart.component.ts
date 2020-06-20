import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  constructor(private activateRoute: ActivatedRoute, private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) { 

  }

  ngOnInit() {
    this.activateRoute.paramMap.subscribe(params => {
      let productId = params.get('id')
      let price = params.get('price')
    })
  }

}
