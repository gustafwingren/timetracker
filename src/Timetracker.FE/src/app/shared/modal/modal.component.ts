import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from '../button/button.component';
import { ButtonColor } from '../button/button-color';
import { ModalService } from '../../core/services/modal.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule, ButtonComponent],
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss'],
})
export class ModalComponent implements OnInit, OnDestroy {
  destroy$ = new Subject();
  isOpen = false;
  heading = '';
  message = '';
  cancelButtonText: string | undefined = 'Cancel';
  confirmButtonText: string | undefined = 'Confirm';
  cancelAction: (() => void) | undefined;
  confirmAction: (() => void) | undefined;
  modalService = inject(ModalService);

  ngOnInit(): void {
    this.modalService.showModal$
      .pipe(takeUntil(this.destroy$))
      .subscribe(modal => {
        if (this.isOpen) {
          return;
        }

        this.isOpen = true;
        this.heading = modal.heading;
        this.message = modal.message;
        this.cancelAction = modal.cancelAction;
        this.cancelButtonText = modal.cancelButtonText;
        this.confirmAction = modal.confirmAction;
        this.confirmButtonText = modal.confirmButtonText;
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next(true);
  }

  cancel(): void {
    this.isOpen = false;
    this.cancelAction?.call(this);
  }

  confirm(): void {
    this.isOpen = false;
    this.confirmAction?.call(this);
  }

  protected readonly ButtonColor = ButtonColor;
}
