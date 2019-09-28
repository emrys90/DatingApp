import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { User } from '../_models/user';
import { Observable, of } from 'rxjs';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MemberListResolver implements Resolve<User[] | null> {
    constructor(private userService: UserService, private router: Router, private alertifyService: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User[] | null> {
        return this.userService.getUsers()
            .pipe(
                catchError(error => {
                    this.alertifyService.error('Problem retrieving data');
                    this.router.navigate(['/']);
                    return of(null);
                })
            );
    }
}
