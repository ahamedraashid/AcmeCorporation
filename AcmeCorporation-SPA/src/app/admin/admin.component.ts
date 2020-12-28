import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  // isAdmin: boolean;
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  get LoggedInAsAdmin() {
    return this.authService.loggedInAdmin();
  }

}