import {
  Component,
  inject,
  OnChanges,
  OnDestroy,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { Subject, takeUntil } from 'rxjs';
import { Toast } from '../../core/models/toast';
import { ToastService } from '../../core/services/toast.service';
import { SuccessIconComponent } from '../icons/success-icon/success-icon.component';
import { ToastType } from '../../core/enums/toastType';
import { ErrorIconComponent } from '../icons/error-icon/error-icon.component';
import { InfoIconComponent } from '../icons/info-icon/info-icon.component';
import { WarningIconComponent } from '../icons/warning-icon/warning-icon.component';

@Component({
  selector: 'app-toast',
  standalone: true,
  imports: [
    CommonModule,
    SuccessIconComponent,
    ErrorIconComponent,
    InfoIconComponent,
    WarningIconComponent,
  ],
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.scss'],
})
export class ToastComponent implements OnInit, OnChanges, OnDestroy {
  toastService = inject(ToastService);

  destroy$ = new Subject<boolean>();
  toasts: Toast[] = [];

  ngOnInit() {
    this.toastService.showToast$
      .pipe(takeUntil(this.destroy$))
      .subscribe(toast => {
        const newId = this.toasts.length + 1;
        toast.id = newId;
        setTimeout(() => {
          this.toasts.forEach((value, index) => {
            if (value.id == newId) {
              this.toasts.splice(index, 1);
            }
          });
        }, toast.duration || 5 * 1000);
        this.toasts.push(toast);
      });
  }

  ngOnDestroy() {
    this.destroy$.next(true);
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log('changes', changes);
  }

  protected readonly ToastType = ToastType;
}
