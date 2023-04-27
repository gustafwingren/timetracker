import { HeaderComponent } from './header.component';
import { Meta, moduleMetadata, StoryObj } from '@storybook/angular';
import { SharedModule } from '../shared.module';
import { RouterTestingModule } from '@angular/router/testing';

const meta: Meta<HeaderComponent> = {
  title: 'Header',
  component: HeaderComponent,
  tags: ['autodocs'],
  decorators: [
    moduleMetadata({
      imports: [SharedModule, RouterTestingModule],
    }),
  ],
};

export default meta;

type Story = StoryObj<HeaderComponent>;

export const DefaultHeader: Story = {};
