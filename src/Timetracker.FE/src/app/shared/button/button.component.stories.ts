import { ButtonComponent } from './button.component';
import { Meta, moduleMetadata, StoryObj } from '@storybook/angular';
import { ButtonColor } from './button-color';

const meta: Meta<ButtonComponent> = {
  title: 'Button',
  component: ButtonComponent,
  tags: ['autodocs'],
  decorators: [
    moduleMetadata({
      imports: [],
    }),
  ],
  render: (args: ButtonComponent) => ({
    props: {
      ...args,
    },
    template: `<button app-button [color]="${args.color}" [loading]="${args.loading}">Button</button>`,
  }),
  argTypes: {
    color: {
      control: {
        type: 'select',
        labels: Object.values(ButtonColor).filter(
          value => typeof value === 'string'
        ),
      },
      options: Object.keys(ButtonColor)
        .filter(key => !isNaN(parseInt(key)))
        .map(key => parseInt(key)),
    },
    loading: {
      control: 'boolean',
      defaultValue: false,
    },
  },
};

export default meta;

type Story = StoryObj<ButtonComponent>;

export const Default: Story = {
  args: {
    color: ButtonColor.Default,
  },
};

export const Accent: Story = {
  args: {
    color: ButtonColor.Accent,
  },
};

export const Danger: Story = {
  args: {
    color: ButtonColor.Danger,
  },
};

export const Loading: Story = {
  args: {
    color: ButtonColor.Default,
    loading: true,
  },
};
