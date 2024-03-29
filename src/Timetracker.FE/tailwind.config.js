/** @type {import('tailwindcss').Config} */
const colors = require("tailwindcss/colors");
module.exports = {
  content: ["./src/**/*.{html,ts}",],
  theme: {
    colors: {
      gray: {
        '50': '#f9fafb',
        '100': '#f3f4f6',
        '200': '#e5e7eb',
        '300': '#d1d5db',
        '400': '#9ca3af',
        '500': '#6b7280',
        '600': '#4b5563',
        '700': '#374151',
        '800': '#1f2937',
        '900': '#111827',
      },
      'spring-rain': {
        '50': '#f2f7f2',
        '100': '#e1ebe0',
        '200': '#b4ceb3',
        '300': '#99bc9a',
        '400': '#6d9a70',
        '500': '#4c7d51',
        '600': '#39623d',
        '700': '#2e4e33',
        '800': '#263f2a',
        '900': '#203423',
        '950': '#111d13',
      },
      'lavender': {
        '50': '#fdf6fd',
        '100': '#f9ecfb',
        '200': '#f2d8f6',
        '300': '#eab9ee',
        '400': '#db82e0',
        '500': '#cd63d2',
        '600': '#b243b6',
        '700': '#953596',
        '800': '#7b2d7b',
        '900': '#652a63',
        '950': '#41113f',
      },
      flamingo: {
        '50': '#fef2f2',
        '100': '#fee2e2',
        '200': '#fecaca',
        '300': '#fca5a5',
        '400': '#f87171',
        '500': '#ef4444',
        '600': '#dc2626',
        '700': '#b91c1c',
        '800': '#991b1b',
        '900': '#7f1d1d',
        '950': '#450a0a',
      },
      transparent: 'transparent',
      current: 'currentColor',
      white: '#ffffff',
      black: '#000000',
    },
    extend: {
      transitionProperty: {
        'visibility': 'visibility',
      }
    },
  },
  plugins: [],
}
