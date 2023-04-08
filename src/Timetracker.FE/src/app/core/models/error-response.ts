import { ErrorType } from '../enums/error-type';

export interface ErrorResponse {
  code: string;
  description: string;
  type: ErrorType;
  numericType: number;
}
