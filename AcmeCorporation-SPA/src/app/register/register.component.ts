import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { emailAlreadyExist } from '../customValidation';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

declare var jQuery: any;
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  constructor(public authService: AuthService, private alertify: AlertifyService) {
  }

  ngOnInit() {
    this.registerForm = new FormGroup({
      signupFormModalName: new FormControl('', Validators.required),
      signupFormModalEmail: new FormControl('', {validators: [Validators.email], asyncValidators: [emailAlreadyExist(this).bind(this)]}),
      signupFormModalPassword: new FormControl('', [Validators.required, Validators.minLength(6)]),
    });
  }



  get signupFormModalName() {
    return this.registerForm.get('signupFormModalName');
  }

  get signupFormModalEmail() {
    return this.registerForm.get('signupFormModalEmail');
  }

  get signupFormModalPassword() {
    return this.registerForm.get('signupFormModalPassword');
  }

  register() {
    const model = {
      Username: this.signupFormModalName.value,
      EmailAddress: this.signupFormModalEmail.value,
      Password: this.signupFormModalPassword.value
    };

    this.authService.register(model).subscribe(next => {
      jQuery('#registerForm').modal('hide');
      this.alertify.success('Registered successfully');
    }, error => { console.log('failed to register'); });
  }
}
