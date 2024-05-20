import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {

  if (localStorage.getItem("TOKEN")){
    return true;
  } else {
    return false;
  }
  
};
