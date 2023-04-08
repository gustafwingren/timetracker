export interface ProblemDetailsResponse {
  status: number;
  type: string;
  title: string;
  errors: [string, string[]];
}
