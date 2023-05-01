import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard = async () => {
  const authService = inject(AuthService);
  const routerService = inject(Router);

  if (!authService.isLoggedIn()) {
    await routerService.navigate(['/login']);

    return false;
  }

  return true;
};
