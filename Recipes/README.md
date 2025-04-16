# Recipes

```
Another ABP solution is available as a POC. See its README.
```

## Instructions

- Run Recipes.AppHost to start all components of the application including the database. It will open the Aspire Dashboard. Note: Docker Desktop needs to be running first.
- Swagger here: https://localhost:7050/swagger
- Api specs here: https://localhost:7050/openapi/v1.json

## Issues

- OAuth2 authentication does not work in Swagger (yet), but does in e.g. Postman. 

- My personal Azure tenant enforces MFA, which makes it harder to create a test user
- 
  ```
  - Grant type: Authorization code
  - Auth url: https://login.microsoftonline.com/3d9bc4b8-e320-4cca-83b0-a9a175b7b85e/oauth2/v2.0/authorize
  - Token url: https://login.microsoftonline.com/3d9bc4b8-e320-4cca-83b0-a9a175b7b85e/oauth2/v2.0/token
  - client id: f40066a9-b0a4-4ae3-8ef5-d453e31f80e6
  - secret: asv8Q~FNTF.OD2nu6XwyjJHLq53RBtEWl93CdcwV
  - scope: api://recipes/Recipes.Write
  ```

  Alternatively, use this access token

  ```
  eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSIsImtpZCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSJ9.eyJhdWQiOiJhcGk6Ly9yZWNpcGVzIiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvM2Q5YmM0YjgtZTMyMC00Y2NhLTgzYjAtYTlhMTc1YjdiODVlLyIsImlhdCI6MTc0NDgwNzMyMCwibmJmIjoxNzQ0ODA3MzIwLCJleHAiOjE3NDQ4MTE5OTUsImFjciI6IjEiLCJhaW8iOiJBYlFBUy84WkFBQUExUEJWZzBRYWJleHd0aWJGT1N0TU9JNlBPZXpRV3hqY21wTWJnYVZ4NDBLdE9yQkxXRDRuYzY2cDQwSWgrM1JCYTl6RTZ0L01QWG02SmV2aDFXYVQzZ2p6MHgyN3JqSWY1Y3pVU3RxZ0h6TXhlM2xFbDZyUXdKNFBxL2NpcXV3eUkxWmFOeU9aWC9DL0JUWUszcXJ6eXhVeTlYSkl1ckNXZ3BnRTYxNEFWV3Y4dER1dmptQ2ZubVBNaHJ6WEY4R1lmUHN1bHZMUk9NSlNiKzlvVGkyUmkxcnFOY0h3RVBIYWN6Y3ZXd2JhRzdrPSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiJmNDAwNjZhOS1iMGE0LTRhZTMtOGVmNS1kNDUzZTMxZjgwZTYiLCJhcHBpZGFjciI6IjEiLCJlbWFpbCI6InRldW5jb3J0b29tc0BnbWFpbC5jb20iLCJmYW1pbHlfbmFtZSI6IkNvcnRvb21zIiwiZ2l2ZW5fbmFtZSI6IlRldW4iLCJpZHAiOiJsaXZlLmNvbSIsImlwYWRkciI6IjE4NS44Mi4xOTQuMTIyIiwibmFtZSI6IlRldW4gQ29ydG9vbXMiLCJvaWQiOiIwYmI2NmM1YS00YzViLTRhMWYtOWExNi0zODE2Mjg0YTg3YTgiLCJyaCI6IjEuQVU0QXVNU2JQU0RqeWt5RHNLbWhkYmU0WGh3NF9EbGNPa3hGZ2RGeXAxSXhMM2xPQUtoT0FBLiIsInNjcCI6IlJlY2lwZXMuV3JpdGUiLCJzaWQiOiIwMDNkZmI0OS1lY2E3LWVmMjAtZGFmZi05ZjdhMTc2MzlmMDkiLCJzdWIiOiJBN2N4Q2NaaHFyV09hYUhjWEVmS3JFQWNhc3RUTGpFVEt4R2UzRUFhTldFIiwidGlkIjoiM2Q5YmM0YjgtZTMyMC00Y2NhLTgzYjAtYTlhMTc1YjdiODVlIiwidW5pcXVlX25hbWUiOiJsaXZlLmNvbSN0ZXVuY29ydG9vbXNAZ21haWwuY29tIiwidXRpIjoiVjFSbG56S04wRVdubHNNcHdGekxBQSIsInZlciI6IjEuMCJ9.N5bvo2mhtxemv5xzxzX8LBscbrN4zmqDtMeTHekqKXNHsgPuKqWKPOiPmEaYZUYWnRG_p57ivU44tlySkJCDxgCsbSmqinVt8kpTgz52ZMwdMjA4NnKlZ07aev2c74dRtIMV6lRglusgngiQqmQz71Oe8bAhuVOjscRRgCBGra8oTFQN8LcNxHPaEnD0b5fXoQz2Pesq8auVDqLib7-YvA77ZuIT6OjikQ579fO5cU0ZMmAmIDX4L4EREhJxcYfJduf7lT0aqqj2l3kv98xxnzpS9DpLcWoqdc4zDb3E7lwF4TY5DajKX47LDPyH8ZeBqKo6FqHxLxRiWd3fFL5X6Q
  ```

- PUT route not implemented

## Requirements

> Build a GET route that returns all recipe names.

Done

> Build a GET route that takes a recipe name as a string param. Return the ingredients and the number of steps in the recipe as JSON.

Done

> Add a POST route that can add additional recipes in the existing format to the backend with support for the above routes.

Done

> Add a PUT route that can update existing recipes.

Not done

## Components

### Aspire
Aspire is like Docker Compose, but easier.

### Seq logging
Open Seq on the Aspire Dashboard to see (structured) logs.

### Database
The connection string is generated and can be found in the Aspire Dashboard, in the environment vars of the Recipes app (in the panel that opens when you click the api). The string will look like this:

```
Server=127.0.0.1,50688;User ID=sa;Password=Pd6jWYZzC4RjH2Gqa8AwRq;TrustServerCertificate=true;Initial Catalog=Recipes-Teun;Integrated Security=false
```

### Migrator
I've used the .json as the initial source. The migrator app migrates the database and then seeds the initial data from the json file.

### MediatR
The MediatR library provides decoupling, ASP-independent pipelines, CQRS and vertical slicing. Most of it, I find, is overkill. I mostly like the vertical slicing and the expressive, use case-centric project structure it promotes (see Core.Application).

### Controllers
Controllers are lean. A filter does exception handling and model validation.