import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Modal } from '../models/modal';

@Injectable({
  providedIn: 'root',
})
export class ModalService {
  showModal$ = new Subject<Modal>();

  showModal(
    heading: string,
    message: string,
    cancelAction?: () => void,
    cancelButtonText?: string,
    confirmAction?: () => void,
    confirmButtonText?: string
  ): void {
    this.showModal$.next({
      heading,
      message,
      cancelAction,
      cancelButtonText,
      confirmAction,
      confirmButtonText,
    });
  }
}
