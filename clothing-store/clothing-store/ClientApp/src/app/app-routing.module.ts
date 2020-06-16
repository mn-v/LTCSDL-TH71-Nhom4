import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { SaleComponent } from './pages/sale/sale.component';
import { ContactComponent } from './pages/contact/contact.component';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';
import { CartComponent } from './pages/cart/cart.component';
import { MenComponent } from './pages/men/men.component';
import { WomenComponent } from './pages/women/women.component';
import { AccessoriesComponent } from './pages/accessories/accessories.component';
import { ProductComponent } from './pages/product/product.component';
import { AdminComponent } from './pages/admin/admin.component';
<<<<<<< HEAD
import { AdminProductsComponent } from './pages/admin-products/admin-products.component';
import { AdminCategoryComponent } from './pages/admin-category/admin-category.component';
import { AdminPromotionComponent } from './pages/admin-promotion/admin-promotion.component';
=======
import { AdminUserComponent } from './pages/admin-user/admin-user.component';
>>>>>>> 134de205c0182b123e1ac7219b7c5b3a85b69a40


const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'men', component: MenComponent },
  { path: 'women', component: WomenComponent },
  { path: 'sale', component: SaleComponent },
  { path: 'accessories', component: AccessoriesComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'cart', component: CartComponent },
  { path: 'product-detail', component: ProductComponent },
  { path: 'admin', component: AdminComponent },
<<<<<<< HEAD
  { path: 'admin-products', component: AdminProductsComponent },
  { path: 'admin-category', component: AdminCategoryComponent },
  { path: 'admin-promotion', component: AdminPromotionComponent },
=======
  { path: 'admin-user', component: AdminUserComponent }
>>>>>>> 134de205c0182b123e1ac7219b7c5b3a85b69a40
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
