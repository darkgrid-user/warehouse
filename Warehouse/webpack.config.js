const path = require("path");

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
        extensions: [".ts", ".js"],
        extensionAlias: { ".js": [".js", ".ts"] }
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
                        loader: "style-loader"
                    },
                    {
                        loader: "css-loader"
                    },
                    {
                        loader: "sass-loader",
                        options: {
                            sassOptions: {
                                silenceDeprecations: [
                                    "mixed-decls",
                                    "color-functions",
                                    "global-builtin",
                                    "import"
                                ]
                            }
                        }
                    }
                ],
            },
            {
                test: /\.(png|svg|jpg|jpeg|gif)$/,
                type: "asset/resource",
            },
            {
                test: /\.(woff|woff2|eot|ttf|otf)$/,
                type: "asset/resource",
            }
        ]
    }
};
