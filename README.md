# Wikipedia MCP Server in ASP.NET core 

https://www.mediawiki.org/wiki/API:REST_API

A Wikipedia MCP server just as a fun side-project wrapping the core functionality of the wikipedia REST API.
The idea: Making the huge dataset from Wikipedia available to any LLM with just a few requests 

## Technologies:
- C#
- .NET 10
- ASP.NET Core 
- ModelContextProtcol Library (https://github.com/modelcontextprotocol/csharp-sdk)
  
## Read-only features:
- Searching for pages based on keywords (Endpoint: /search/page)
- Searching for titles (Endpoint: /search/title)
- Retrieve pages JSON object without HTML (Endpoint: /page/$name/bare)
- Retrieve pages JSON object with HTML (Endpoint: /page/$name/with_html)
- Retrieve pages in plain HTML (Endpoint: /page/$name/html)
- Retrieve pages media files (Endpoint: /page/$name/links/media)
- Retrieve pages history (Endpoint: /page/$name/history)
  
## Create/Update features (POST/PUT):
- Requirement: OAuth2.0 flow for authorized access to Create/Update endpoints (https://www.mediawiki.org/wiki/Extension:OAuth)
- Create a user sandbox page (/page)
- Update a user sandbox page (/page)