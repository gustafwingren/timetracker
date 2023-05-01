import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

export const redirectGuard = async () => {
  const authService = inject(AuthService);
  const routerService = inject(Router);

  if (authService.isLoggedIn()) {
    await routerService.navigate(['/home']);

    return false;
  }

  return true;
};
