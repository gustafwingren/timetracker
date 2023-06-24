import { ToastType } from '../enums/toastType';

export interface Toast {
  id?: number;
  type: ToastType;
  heading: string;
  message: string;
  duration?: number;
}
