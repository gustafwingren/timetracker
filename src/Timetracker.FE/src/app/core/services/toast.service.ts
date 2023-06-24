import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Toast } from '../models/toast';
import { ToastType } from '../enums/toastType';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  showToast$ = new Subject<Toast>();

  addToast(
    type: ToastType,
    heading: string,
    message: string,
    duration?: number
  ): void {
    this.showToast$.next({ type, heading, message, duration });
  }
}
