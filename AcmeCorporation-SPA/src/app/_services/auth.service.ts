import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router, Routes } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { baseUrlApi } from '../constants';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private alertify: AlertifyService, private router: Router) { }
  // baseUrl = 'http://localhost:5000/api/users/';
  decondedToken: any;
  jwtHelper = new JwtHelperService();
  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

   login(model: any) {
     return this.http.post(baseUrlApi + 'users/authenticate', model)
       .pipe(
         map((response: any) => {
           console.log(response);
           const user = response;
           if (user) {
             localStorage.setItem('token', user.token);
             this.decondedToken = this.jwtHelper.decodeToken(user.token);
             if (this.decondedToken.role === 'Admin') {
              this.router.navigate(['/admin']);
             }
           }
         })
       );
   }

  emailExist(email: string) {
    return this.http.get(baseUrlApi + 'users/validateEmailExist?email=' + email);
  }

   loggedInAdmin() {
     const token = localStorage.getItem('token');
     const decodeToken = this.jwtHelper.decodeToken(token);
     return !this.jwtHelper.isTokenExpired(token) && decodeToken.role === 'Admin';
   }

   loggedInUser() {
    const token = localStorage.getItem('token');
    const decodeToken = this.jwtHelper.decodeToken(token);
    return !this.jwtHelper.isTokenExpired(token) && decodeToken.role === 'User';
 }

   register(model: any) {
     return this.http.post(baseUrlApi + '/users/register', model);
   }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('Successfully logged out');
    this.router.navigate(['/home']);
  }
}
