import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

declare var jQuery: any;
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  // @ViewChild('frame', { static: true }) demoBasic: ModalDirective;

  loginForm: any;

  constructor(private authService: AuthService, private alertify: AlertifyService) {

  }
  ngOnInit() {
    this.loginForm = new FormGroup({
      loginFormModalEmail: new FormControl('', [Validators.email, Validators.required]),
      loginFormModalPassword: new FormControl('', [Validators.required, Validators.minLength(6)])
    });
  }

  get loginFormModalEmail() {
    return this.loginForm.get('loginFormModalEmail');
  }

  get loginFormModalPassword() {
    return this.loginForm.get('loginFormModalPassword');
  }



  login() {
    const model = {
      EmailAddress: this.loginFormModalEmail.value,
      Password: this.loginFormModalPassword.value
    };

    this.authService.login(model).subscribe(next => {
      jQuery('#loginForm').modal('hide');
      this.alertify.success('Logged in successfully!');
      // console.log('logged in succesfully');
    }, error => { this.alertify.error('Incorrect Email Address or Password!'); });
  }


}
