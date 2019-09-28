import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable({
    providedIn: 'root'
})
export class GuestGuard implements CanActivate {
    constructor(
        private authService: AuthService,
        private router: Router,
        private alertify: AlertifyService
    ) {}

    canActivate(): boolean {
        if (!this.authService.loggedIn()) {
            return true;
        }

        this.router.navigate(['/discover']);
        return false;
    }
}
