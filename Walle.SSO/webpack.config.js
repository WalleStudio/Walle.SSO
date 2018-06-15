var path = require('path')
const webpack = require('webpack')
<<<<<<< HEAD

module.exports = {
    entry: {
        app: './src/main.js'
=======
module.exports = {
    entry: {
        app: './src/app.js'
>>>>>>> f1caae70876329049f8cba9b178228d64483fa39
    },
    output: {
        path: path.resolve(__dirname, './wwwroot'),
        filename: '[name].js'
    },
    resolve: {
        extensions: ['.js', '.vue'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js',
            '@': path.resolve(__dirname, './src')
        }
    },
    module: {
        rules: [{
<<<<<<< HEAD
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    sourceMap: true,
                    loaders: {
                        scss: 'style-loader!css-loader!sass-loader',
                        sass: 'style-loader!css-loader!sass-loader?indentedSyntax',
                    },
                }
            },
            {
                test: /\.css$/,
                loader: "style-loader!css-loader"
            },
            {
                test: /\.less/,
                loader: 'style!css!autoprefixer!less'
            },
            {
                test: /\.(woff2?|eot|ttf|otf)(\?.*)?$/,
                loader: 'url-loader'
            },
            {
                test: /\.(png|jpe?g|gif|svg)(\?.*)?$/,
                loader: 'url-loader'
            },
=======
            test: /\.vue$/,
            loader: 'vue-loader',
            options: {
                sourceMap: true,
                loaders: {
                    scss: 'style-loader!css-loader!sass-loader',
                    sass: 'style-loader!css-loader!sass-loader?indentedSyntax',
                },
            }
        },
        {
            test: /\.css$/,
            loader: "style-loader!css-loader"
        },
        {
            test: /\.less/,
            loader: 'style!css!autoprefixer!less'
        },
        {
            test: /\.scss$/,
            loader: "style-loader!css-loader!sass-loader"
        },
        {
            test: /\.(woff2?|eot|ttf|otf)(\?.*)?$/,
            loader: 'url-loader'
        },
        {
            test: /\.(png|jpe?g|gif|svg)(\?.*)?$/,
            loader: 'url-loader'
        },
>>>>>>> f1caae70876329049f8cba9b178228d64483fa39
        ]
    },
    devtool: '#source-map'
}