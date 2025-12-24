const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: {
        site: "./webpack.app.ts"
    },
    output: {
        filename: "app.js",
        path: path.resolve(__dirname, "wwwroot", "core"),
        clean: true
    },
    devtool: "source-map",
    mode: "development",
    watch: true,
    resolve: {
        extensions: [".ts"]
    },
    stats: {
        modules: true,
        modulesSpace: 999
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: ["ts-loader"],
                exclude: /node_modules/
            },
            {
                test: /\.s?css$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader
                    },
                    {
                        loader: "css-loader"
                    },
                    {
                        loader: "sass-loader",
                        options: {
                            sassOptions: {
                                silenceDeprecations: [
                                    "color-functions",
                                    "global-builtin",
                                    "import"
                                ]
                            }
                        }
                    }
                ]
            },
            {
                test: /\.(png|svg|jpg|jpeg|gif)$/,
                type: "asset/resource"
            },
            {
                test: /\.(woff|woff2|eot|ttf|otf)$/,
                type: "asset/resource"
            }
        ]
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: "app.css"
        })
    ]
};
