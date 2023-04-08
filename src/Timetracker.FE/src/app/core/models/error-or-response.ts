import { ErrorResponse } from './error-response';

export interface ErrorOrResponse<T> {
  isError: boolean;
  value: T;
  errors: ErrorResponse[];
  firstError: ErrorResponse;
}
