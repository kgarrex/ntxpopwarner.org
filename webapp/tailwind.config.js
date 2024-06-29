/** @type {import('tailwindcss').Config} */
module.exports = {
  content: {
    files: [
      './Pages/**/*.cshtml',
      './Views/*.cshtml',
      './Views/*.cshtml.cs',
      './Views/**/*.cshtml',
      './Views/**/*.cshtml.cs',
      './wwwroot/**/*.{html,js}'
    ]
  },
  theme: {
    container : {
      center: true,
    },
    extend: {
      color: {
        'downriver'    :'#092256',
        'eden'         :'#105852',
        'malachite'    :'#0bda51',
        'forest-green' :'#228B22',
        'concrete'     :'#f2f2f2'
      }
    },
  },
  plugins: [
    require('@tailwindcss/forms')
  ]
}
