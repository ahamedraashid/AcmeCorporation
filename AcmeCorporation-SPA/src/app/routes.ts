import { Routes } from "@angular/router";
import { AddProductComponent } from "./add-product/add-product.component";
import { AdminComponent } from "./admin/admin.component";
import { HomeComponent } from "./home/home.component";
import { ProductDetailsComponent } from "./product-details/product-details.component";
import { AdminGuard } from "./_guard/admin.guard";

export const appRoutes: Routes = [
  { path: 'admin', component: AdminComponent },
  { path: 'home', component: HomeComponent },
  { path: 'admin/addproduct/:id', component: AddProductComponent, canActivate: [AdminGuard] },
  { path: 'admin/addproduct', component: AddProductComponent, canActivate: [AdminGuard] },
  { path: 'product/:id', component: ProductDetailsComponent}
]
