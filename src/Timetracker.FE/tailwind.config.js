/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}",],
  theme: {
    colors: {
      'nandor': {
        '50': '#f6f7f7',
        '100': '#e3e4e4',
        '200': '#c7c8c8',
        '300': '#a3a5a4',
        '400': '#7f8280',
        '500': '#656766',
        '600': '#565857',
        '700': '#424343',
        '800': '#373838',
        '900': '#303131',
        '950': '#191a1a',
      },
      'eggplant': {
        '50': '#f9f6f8',
        '100': '#f4eff2',
        '200': '#ebdfe7',
        '300': '#dcc5d3',
        '400': '#c5a1b7',
        '500': '#b1839d',
        '600': '#9a6882',
        '700': '#82546a',
        '800': '#734b5e',
        '900': '#5d3e4d',
        '950': '#36212b',
      },
      'swirl': {
        '50': '#f8f6f4',
        '100': '#eeebe6',
        '200': '#dbd3c9',
        '300': '#c7baaa',
        '400': '#af9b88',
        '500': '#9f8470',
        '600': '#927564',
        '700': '#7a6054',
        '800': '#645048',
        '900': '#52423c',
        '950': '#2b221f',
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
    },
    extend: {},
  },
  plugins: [],
}
