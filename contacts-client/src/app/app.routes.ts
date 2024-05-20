import { Routes } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';
import { LoginComponent } from './login/login.component';
import { ManageComponent } from './contacts/manage/manage.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [

    {path: 'login', component: LoginComponent},
    {path: 'contacts', component: ContactsComponent, canActivate: [authGuard]},
    {path: 'contacts/manage', component: ManageComponent, canActivate: [authGuard]},
    {path: '**', redirectTo: "login"}

];
