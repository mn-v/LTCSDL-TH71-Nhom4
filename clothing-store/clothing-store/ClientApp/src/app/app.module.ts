import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HomePageComponent } from './pages/home-page/home-page.component';
import { SaleComponent } from './pages/sale/sale.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
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
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomePageComponent,
    SaleComponent,
    FooterComponent,
    ContactComponent,
    LoginComponent,
    SignupComponent,
    CartComponent,
    MenComponent,
    WomenComponent,
    AccessoriesComponent,
    ProductComponent,
    AdminComponent,
<<<<<<< HEAD
    AdminProductsComponent,
    AdminCategoryComponent,
    AdminPromotionComponent
=======
    AdminUserComponent
>>>>>>> 134de205c0182b123e1ac7219b7c5b3a85b69a40
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
