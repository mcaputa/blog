const path = require('path');
var webpack = require('webpack');

const ExtractTextPlugin = require("extract-text-webpack-plugin");
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');

module.exports = {
    context: __dirname + "/wwwroot",
    entry: './dest/app.js',
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'wwwroot/dest')
    },
    //mode: 'development',
    watch:true,
    module: {
        rules: [
            { test: /bootstrap\/js\//, loader: 'imports?jQuery=jquery' },
            {
                test: /\.css$/,
                include: [
                    path.resolve(__dirname, "not_exist_path")
                ],
                loader: "style!css"
            },
            {
                test: /\.css$/,
                use: [ 'style-loader', 'css-loader' ]
            },
            {
                test: /\.(scss)$/,
                use: [
                    {
                        loader: 'style-loader'
                    },
                    {
                        loader: 'css-loader'
                    },
                    {
                        loader: 'postcss-loader',
                        options: {
                            plugins: function () {
                                return [
                                    require('autoprefixer')
                                ];
                            }
                        }
                    },
                    {
                        loader: 'sass-loader'
                    }
                ]
            },
            {
                test: /.(ttf|otf|eot|svg|woff(2)?)(\?[a-z0-9]+)?$/,
                use: [{
                    loader: 'url-loader?limit=100000',
                    options: {
                        name: '[name].[ext]',
                        outputPath: 'fonts/',    // where the fonts will go
                        publicPath: '../wwwroot/dest/fonts/'       // override the default path
                    }
                }]
            }
        ]
    },
    plugins: [
        new webpack.ProvidePlugin({
            'jQuery': 'jquery',
            '$': 'jquery'
        }),
        new ExtractTextPlugin({
            filename: 'bundle.css',
            allChunks: true
        }),
        new UglifyJsPlugin()
    ]
};