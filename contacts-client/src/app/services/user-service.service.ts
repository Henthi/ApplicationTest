import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Contact } from '../models/contact';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private authService: AuthService) { }

  getUsers(pageNumber: number, pageSize:number) {

    let headers = new HttpHeaders();
    headers = headers.append('Authorization', this.authService.getAuthenticatedToken()!);

    return this.http.get<Contact[]>(environment.apiUrl + "User/getUsers?pageNumber=" + pageNumber +"&pageSize=" + pageSize, {headers});
  }

  getUserById(userId: number){

    let headers = new HttpHeaders();
    headers = headers.append('Authorization', this.authService.getAuthenticatedToken()!);

    return this.http.get<Contact>(environment.apiUrl + "User/getUserById?userId=" + userId, {headers});
  }

  addUser(contact: Contact){

    let headers = new HttpHeaders();
    headers = headers.append('Authorization', this.authService.getAuthenticatedToken()!);
    
    return this.http.post(environment.apiUrl + "User/addUser", contact, {headers});
  }

  editUser(contact: Contact){

    let headers = new HttpHeaders();
    headers = headers.append('Authorization', this.authService.getAuthenticatedToken()!);

    return this.http.put(environment.apiUrl + "User/editUser", contact, {headers});
  }

  deleteUser(contact: Contact){

    let headers = new HttpHeaders();
    headers = headers.append('Authorization', this.authService.getAuthenticatedToken()!);

    return this.http.post(environment.apiUrl + "User/deleteUser", contact, {headers});
  }

}
