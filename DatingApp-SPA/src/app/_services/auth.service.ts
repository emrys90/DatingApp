import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private baseUrl = environment.apiUrl + 'auth/';
    private jwtHelper = new JwtHelperService();
    private decodedToken: any;

    constructor(private http: HttpClient) {
        const token = localStorage.getItem('token');
        if (token) {
            this.decodedToken = this.jwtHelper.decodeToken(token);
        }
    }

    login(model: any) {
        return this.http.post(this.baseUrl + 'login', model).pipe(
            map((response: any) => {
                const user = response;
                if (user) {
                    localStorage.setItem('token', user.token);
                    this.decodedToken = this.jwtHelper.decodeToken(user.token);
                }
            })
        );
    }

    logout() {
        localStorage.removeItem('token');
    }

    register(model: any) {
        return this.http.post(this.baseUrl + 'register', model);
    }

    loggedIn() {
        const token = localStorage.getItem('token');
        const val = token == null ? undefined : token;

        return !this.jwtHelper.isTokenExpired(val);
    }

    getUserId() {
        return this.decodedToken.nameid;
    }

    getUsername() {
        return this.decodedToken.unique_name;
    }
}
