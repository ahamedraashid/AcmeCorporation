import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router, private alertifyService: AlertifyService) { }
  ngOnInit() {
    if (!this.LoggedInAsAdmin) {
      this.alertifyService.error('Please login as an admin to access admin panel')
    }
  }
  get LoggedInAsAdmin() {
    return this.authService.loggedInAdmin();
  }

}
