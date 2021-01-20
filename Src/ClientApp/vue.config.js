const path = require("path");
const fs = require("fs");

module.exports = env = {
  "transpileDependencies": [
    "vuetify"
  ],
  configureWebpack: config => {
    if (process.env.NODE_ENV !== 'production') {
      config.devServer = {
        hotOnly: false,
        port: 8080,
        host: '0.0.0.0',
        public: "https://localhost:8085",
        https: {
          key: fs.readFileSync(path.relative(__dirname, 'key.pem')),
          cert: fs.readFileSync(path.relative(__dirname, 'cert.pem')),
        },
      }
    }
  }
}