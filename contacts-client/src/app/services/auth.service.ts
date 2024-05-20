import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  Login(login: Login) {
    return this.http.post<any>(environment.apiUrl + 'Auth/login', login);
  }

  getAuthenticatedToken() {
    return sessionStorage.getItem("TOKEN");
  }

  setAuthenticatedToken(tokenValue:string){
    sessionStorage.setItem("TOKEN", tokenValue);
  }

}