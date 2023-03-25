import { ActivityCreateDto } from './activity-create-dto';

export interface CustomerCreateDto {
  name: string;
  number: string;
  activities?: ActivityCreateDto[];
}
