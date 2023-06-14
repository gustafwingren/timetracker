import { HeaderComponent } from './header.component';
import { Meta, moduleMetadata, StoryObj } from '@storybook/angular';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthService } from '../../core/services/auth.service';

const meta: Meta<HeaderComponent> = {
  title: 'Header',
  component: HeaderComponent,
  tags: ['autodocs'],
  decorators: [
    moduleMetadata({
      imports: [RouterTestingModule],
      providers: [{ provide: AuthService, useValue: {} }],
    }),
  ],
};

export default meta;

type Story = StoryObj<HeaderComponent>;

export const DefaultHeader: Story = {};
