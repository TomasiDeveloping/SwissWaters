import { Injectable } from '@angular/core';
import {BehaviorSubject, map} from "rxjs";
import {ApiUser} from "../models/apiUser.model";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import Swal from "sweetalert2";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly apiUrl = environment.apiUrl + 'apiUser/';

  currentUser = new BehaviorSubject<ApiUser | null>(null);

  constructor(private readonly http: HttpClient, private readonly router: Router) { }

  get apiUser() {
    return this.currentUser.asObservable();
  }
  userIsAuthenticated(): boolean {
    return this.currentUser.value !== null;
  }

  login(email: string, password: string) {
    this.http.post<ApiUser>(this.apiUrl + 'Login', {email, password}).subscribe({
      next: ((response) => {
        this.currentUser.next(response);
        this.router.navigate(['/account']).then();
      }),
      error: (error) => {
        Swal.fire('Login', error.error, 'error').then();
      }
    });
  }
}
