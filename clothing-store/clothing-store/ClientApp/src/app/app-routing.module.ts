import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ShopComponent } from './pages/shop/shop.component';
import { SaleComponent } from './pages/sale/sale.component';


const routes: Routes = [
    { path: '', component: HomePageComponent},
    { path: 'shop', component: ShopComponent},
    { path: 'sale', component: SaleComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
