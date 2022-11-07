const PROXY_CONFIG = [
  {
    context: [
      "/pubs",
      "/reviews",
    ],
    target: "https://localhost:7141",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
