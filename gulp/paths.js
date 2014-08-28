module.exports = {
    js: [
        './app/**/*.js',
        './src/**/*.js',
        '!./**/libs/**',
        '!./**/vendor/**',
        '!./**/templates.js'
    ],

    src: {
        root: './src/UI/',
        templates: './src/UI/**/*.hbs',
        index: './src/UI/index.html',
        partials: './src/UI/**/*Partial.hbs',
        scripts: './src/UI/**/*.js',
        less: ['./src/UI/**/*.less'],
        content: './src/UI/Content/',
        exclude :{
            libs:'!./src/UI/JsLibraries/**'
        }
    },
    dest: {
        root: './_output/UI/',
        content: './_output/UI/Content/'
    }
};