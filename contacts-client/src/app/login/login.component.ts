import { Component } from '@angular/core';
import { Login } from '../models/login';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../services/auth.service';
import { SharedDataService } from '../services/shared-data.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  login: Login = new Login();

  constructor(private authService: AuthService, private sharedService: SharedDataService){

  }

  onSubmit(): void {
    this.authService.Login(this.login).subscribe(response=>{
      this.authService.setAuthenticatedToken(response);
      this.sharedService.navigate("contacts");
    });
  }

}
