import { FormFieldComponent } from './form-field.component';
import {
  componentWrapperDecorator,
  Meta,
  moduleMetadata,
  StoryContext,
  StoryObj,
} from '@storybook/angular';
import { SharedModule } from '../shared.module';

const meta: Meta<FormFieldComponent> = {
  title: 'Form Fields',
  component: FormFieldComponent,
  tags: ['autodocs'],
  decorators: [
    moduleMetadata({
      imports: [SharedModule],
    }),
  ],
  render: (args: any) => ({
    props: {
      ...args,
    },
    template: `
      <app-form-field>
        <app-label>${args.label}</app-label>
        <input appInput type="text" [ngClass]="{'ng-invalid': ${!args.isValid}, 'ng-valid': ${
      args.isValid
    }}" [disabled]="disabled" [required]="required" />
        <app-error *ngIf="!isValid">${args.error}</app-error>
      </app-form-field>`,
  }),
  argTypes: {
    label: {
      control: 'text',
      defaultValue: 'label',
    },
    required: {
      control: 'boolean',
      defaultValue: false,
    },
    isValid: {
      control: 'boolean',
      defaultValue: true,
    },
    error: {
      control: 'text',
    },
    disabled: {
      control: 'boolean',
      defaultValue: false,
    },
  },
  args: {
    label: 'Label',
    required: false,
    isValid: true,
    error: 'Default validation error',
    disabled: false,
  },
};

export default meta;

type Story = StoryObj<FormFieldComponent>;

export const DefaultText: Story = {
  args: {
    label: 'Default text input',
  },
};

export const InvalidInput: Story = {
  args: {
    label: 'Invalid text input',
    isValid: false,
    error: 'This is a validation error.',
  },
};

export const ValidInput: Story = {
  args: {
    label: 'Valid text input',
    isValid: true,
    required: true,
  },
};

export const DisabledInput: Story = {
  args: {
    label: 'Disabled input',
    disabled: true,
  },
};
