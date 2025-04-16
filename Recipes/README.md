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

  ```
  - Grant type: Authorization code
  - Auth url: https://login.microsoftonline.com/3d9bc4b8-e320-4cca-83b0-a9a175b7b85e/oauth2/v2.0/authorize
  - Token url: https://login.microsoftonline.com/3d9bc4b8-e320-4cca-83b0-a9a175b7b85e/oauth2/v2.0/token
  - client id: f40066a9-b0a4-4ae3-8ef5-d453e31f80e6
  - secret: asv8Q~FNTF.OD2nu6XwyjJHLq53RBtEWl93CdcwV
  - scope: api://recipes/Recipes.Write
  ```

  Alternatively, comment out the Authorize tag on the POST action

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