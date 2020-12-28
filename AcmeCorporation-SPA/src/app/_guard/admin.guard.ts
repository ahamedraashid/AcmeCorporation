import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AdminGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private alertifyService: AlertifyService,
    private router: Router
  ) {}
  canActivate(): boolean {
    if (this.authService.loggedInAdmin()) {
    return true;
    }

    this.alertifyService.error('Unauthorized Access: Please login');
    this.router.navigate(['/home']);
    return false;
  }
}
