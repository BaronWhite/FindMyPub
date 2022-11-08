const PROXY_CONFIG = [
  {
    context: [
      "/pubs",
      "/reviews",
    ],
    target: "http://localhost:5141",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
