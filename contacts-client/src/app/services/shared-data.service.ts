import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SharedDataService {

  selectedContact: Contact | undefined;

  constructor(private router: Router) { }

  navigateWithBody(contact: Contact): void{
    this.selectedContact = contact;
    this.router.navigate(["contacts/manage"]);
  }

  navigate(route: string){
    this.router.navigate([route]);
  }

  getSelectedContact(): Contact{
    return this.selectedContact as unknown as Contact;
  }

  unsetSelectedContact(): void{
    this.selectedContact = undefined;
  }

}
