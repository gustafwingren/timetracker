import { HeaderComponent } from './header.component';
import { Meta, moduleMetadata, StoryObj } from '@storybook/angular';
import { SharedModule } from '../shared.module';
import { RouterTestingModule } from '@angular/router/testing';
import { MsalService } from '@azure/msal-angular';

const meta: Meta<HeaderComponent> = {
  title: 'Header',
  component: HeaderComponent,
  tags: ['autodocs'],
  decorators: [
    moduleMetadata({
      imports: [SharedModule, RouterTestingModule],
      providers: [{ provide: MsalService, useValue: {} }],
    }),
  ],
};

export default meta;

type Story = StoryObj<HeaderComponent>;

export const DefaultHeader: Story = {};
