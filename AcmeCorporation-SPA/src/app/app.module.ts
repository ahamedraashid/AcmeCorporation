import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { ProductService } from './_services/product.service';
import { TimerService } from './_services/timer.service';
import { AdminComponent } from './admin/admin.component';
import { appRoutes } from './routes';
import { HomeComponent } from './home/home.component';
import { ProductAdminListComponent } from './product-admin-list/product-admin-list.component';
import { DatatableComponent } from './datatable/datatable.component';
import { AddProductComponent } from './add-product/add-product.component';
import { DatetimepickerComponent } from './datetimepicker/datetimepicker.component';
import { DatetimeService } from './_services/datetime.service';
import {  AdminGuard } from './_guard/admin.guard';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { PlaceBidComponent } from './place-bid/place-bid.component';
import { DeleteProductComponent } from './delete-product/delete-product.component';

@NgModule({
  declarations: [
    AppComponent,
      ProductListComponent,
      SearchBarComponent,
      NavbarComponent,
      LoginComponent,
      RegisterComponent,
      AdminComponent,
      HomeComponent,
      ProductAdminListComponent,
      DatatableComponent,
      AddProductComponent,
      DatetimepickerComponent,
      ProductDetailsComponent,
      PlaceBidComponent,
      DeleteProductComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('token');
        },
        allowedDomains: ['localhost:5000'],
        authScheme: 'bearer '
      },
    }),
  ],
  providers: [
    AuthService,
    AlertifyService,
    ProductService,
    TimerService,
    DatetimeService,
    AdminGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
