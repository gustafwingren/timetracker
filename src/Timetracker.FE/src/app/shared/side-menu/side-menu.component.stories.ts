import { SideMenuComponent } from './side-menu.component';
import { Meta, moduleMetadata, StoryObj } from '@storybook/angular';
import { RouterTestingModule } from '@angular/router/testing';

const meta: Meta<SideMenuComponent> = {
  title: 'Sidemenu',
  component: SideMenuComponent,
  tags: ['autodocs'],
  decorators: [
    moduleMetadata({
      imports: [RouterTestingModule],
    }),
  ],
  render: (args: SideMenuComponent) => ({
    props: {
      ...args,
    },
    template: `<div class="relative flex min-h-screen">
      <app-side-menu></app-side-menu>
      <div class="h-screen flex-1 space-y-8 overflow-y-auto bg-gray-100 pb-12">
      </div>
    </div>`,
  }),
  argTypes: {
    expanded: {
      control: 'boolean',
      defaultValue: true,
    },
  },
};

export default meta;

type Story = StoryObj<SideMenuComponent>;

export const ExpandedSideMenu: Story = {};
