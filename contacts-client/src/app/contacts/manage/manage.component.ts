import { Component, OnDestroy, OnInit } from '@angular/core';
import { SharedDataService } from '../../services/shared-data.service';
import { Contact } from '../../models/contact';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user-service.service';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { provideNativeDateAdapter } from '@angular/material/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-manage',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatDatepickerModule, CommonModule],
  templateUrl: './manage.component.html',
  styleUrl: './manage.component.scss'
})
export class ManageComponent implements OnInit, OnDestroy {

  selectedContact: Contact = new Contact();
  maxDate: Date = new Date();
  header: string = "";
  isNewUser: boolean = false;

  constructor(private sharedService: SharedDataService, private userService: UserService){
    
  }

  ngOnInit(): void {
    this.selectedContact = this.sharedService.getSelectedContact();

    if (this.selectedContact !== undefined){
      this.header = "Edit User";
      this.isNewUser = false;
    } else {
      this.header = "Add New User";
      this.selectedContact = new Contact();
      this.isNewUser = true;
    }

  }

  ngOnDestroy(): void {
    this.sharedService.unsetSelectedContact();
  }

  onSubmit() { 

    if(this.isNewUser){
      this.userService.addUser(this.selectedContact!).subscribe(response => {
        console.log("Contact added successfully!")
        this.sharedService.navigate("/contacts");
      })
    } else {
      this.userService.editUser(this.selectedContact!).subscribe(response => {
        console.log("Contact edited and saved!");
        this.sharedService.navigate("/contacts");
      })
    }
    
  }

  onBack(){
    this.sharedService.navigate("/contacts");
  }

}
