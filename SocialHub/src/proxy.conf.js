const PROXY_CONFIG = [
	{
		"/api": {
			"target": "http://localhost:44319",
			"secure": false,
			"logLevel": "debug"
		}
	}

]

module.exports = PROXY_CONFIG;
