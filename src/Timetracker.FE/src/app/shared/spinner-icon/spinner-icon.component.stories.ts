import { SpinnerIconComponent } from './spinner-icon.component';
import { Meta, StoryObj } from '@storybook/angular';
import { SpinnerIconSize } from './spinner-icon-size';
import { SpinnerIconColor } from './spinner-icon-color';

const meta: Meta<SpinnerIconComponent> = {
  title: 'SpinnerIcon',
  component: SpinnerIconComponent,
  tags: ['autodocs'],
  render: (args: SpinnerIconComponent) => ({
    props: {
      ...args,
    },
  }),
  argTypes: {
    color: {
      control: 'select',
      options: [SpinnerIconColor.button, SpinnerIconColor.primary],
    },
  },
};

export default meta;

type Story = StoryObj<SpinnerIconComponent>;

export const Large: Story = {
  args: {
    size: SpinnerIconSize.large,
  },
};

export const Medium: Story = {
  args: {
    size: SpinnerIconSize.medium,
  },
};

export const Small: Story = {
  args: {
    size: SpinnerIconSize.small,
  },
};
