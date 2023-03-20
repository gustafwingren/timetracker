import { ActivityDto } from './activity-dto';

export interface CustomerDto {
  id: string;
  name: string;
  number: string;
  activities: ActivityDto[];
}
