import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user-service.service';
import { Contact } from '../models/contact';
import {MatTableModule} from '@angular/material/table';
import { Router } from '@angular/router';
import { SharedDataService } from '../services/shared-data.service';

@Component({
  selector: 'app-contacts',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.scss'
})
export class ContactsComponent implements OnInit {

  contactsList: Contact[] = [];
  pageNumber: number = 1;
  pageSize: number = 10;
  displayedColumns: string[] = ['name', 'surname', 'tel', 'emailAddress', 'dateOfBirth', 'action'];

  constructor(private userService: UserService, private router: Router, private sharedService: SharedDataService){

  }

  ngOnInit(): void {
     this.getUsers();
  }

  getUsers(): void{
    //returns observable
    this.userService.getUsers(this.pageNumber, this.pageSize).subscribe(response => {
      this.contactsList=response;
    });
  }

  deleteContact(contact: Contact): void{
    //returns observable
    this.userService.deleteUser(contact).subscribe(response => {
      console.log("User deleted");
      this.getUsers();
    });
  }

  manageContact(contact: Contact): void{
    this.sharedService.navigateWithBody(contact);
  }

  addContact(): void{
    this.sharedService.navigate("contacts/manage")
  }

}
