export interface Modal {
  heading: string;
  message: string;
  cancelAction?: () => void;
  cancelButtonText?: string;
  confirmAction?: () => void;
  confirmButtonText?: string;
}
