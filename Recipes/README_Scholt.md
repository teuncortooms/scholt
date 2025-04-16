# Code Assessment
This Scholt Energy code assessment is to show your backend development skills. The objective is to write a JSON API backend for a recipes website. 

We will look at the following criteria:
-	Completeness: Did you extend beyond the given requirements, fulfilling the context of the business.
-	Code Organization, Readability and Maintainability: Is you code easy to read and well structured.
-	Architecture and Patterns: What kind of architecture do you use and show of patterns.
-	Best Practices: Do you utilize good programming practices (input validation, write unit tests, documentation, ...)? Did you show a good grasp of your language/framework?


## Company
The following describes the backstory of the company:

**Food Recipes Inc** is the ultimate food recipe website with the largest database of western foods. \
We are a community driven website to inspire chefs and hobby cooks to create delicious foods. \
A go-to place for foodies to create recipes and share them with others.

## Data model File

You can paste the following JSON into a file called `data.json`, and use it as your data source.

```json
{
  "recipes": [
    {
      "name": "scrambledEggs",
      "ingredients": [
        "1 tsp oil",
        "2 eggs",
        "salt"
      ],
      "instructions": [
        "Beat eggs with salt",
        "Heat oil in pan",
        "Add eggs to pan when hot",
        "Gather eggs into curds, remove when cooked",
        "Salt to taste and enjoy"
      ]
    },
    {
      "name": "garlicPasta",
      "ingredients": [
        "500mL water",
        "100g spaghetti",
        "25mL olive oil",
        "4 cloves garlic",
        "Salt"
      ],
      "instructions": [
        "Heat garlic in olive oil",
        "Boil water in pot",
        "Add pasta to boiling water",
        "Remove pasta from water and mix with garlic olive oil",
        "Salt to taste and enjoy"
      ]
    },
    {
      "name": "chai",
      "ingredients": [
        "400mL water",
        "100mL milk",
        "5g chai masala",
        "2 tea bags or 20 g loose tea leaves"
      ],
      "instructions": [
        "Heat water until 80 C",
        "Add milk, heat until 80 C",
        "Add tea leaves/tea bags, chai masala; mix and steep for 3-4 minutes",
        "Remove mixture from heat; strain and enjoy"
      ]
    }
  ]
}
```
## Part 1

Build a GET route that returns all recipe names.

```bash
A GET request to **http://localhost:[PORT]/recipes** returns:
**Response body (JSON):**
{
	"recipeNames":
		[
			"scrambledEggs",
			"garlicPasta",
			"chai"
		]
}
**Status: 200**
```

## Part 2

Build a GET route that takes a recipe name as a **string** param. Return the ingredients and the number of steps in the recipe as JSON.

```bash
A GET request to http://localhost:[PORT]/recipes/details/garlicPasta returns:
**If recipe exists:** 
**Response body (JSON):**
{
	"details":
		{
			"ingredients": [
				"500mL water",
				"100g spaghetti",
				"25mL olive oil",
				"4 cloves garlic",
				"Salt"
			],
			"numSteps":5
		}
}
**Status: 200
```

## Part 3

Add a POST route that can add additional recipes in the existing format to the backend with support for the above routes.

```bash
A POST request to **http://localhost:[PORT]/recipes** with body 
{
	"name": "butteredBagel", 
		"ingredients": [
			"1 bagel", 
			"butter"
		], 
	"instructions": [
		"cut the bagel", 
		"spread butter on bagel"
	] 
} 
returns:
**Response body: None**
**Status:** 201
```

## Part 4

Add a PUT route that can update existing recipes.

```bash
A PUT request to **http://localhost:[PORT]/recipes** with body 
{
	"name": "butteredBagel", 
		"ingredients": [
			"1 bagel", 
			"2 tbsp butter"
		], 
	"instructions": [
		"cut the bagel", 
		"spread butter on bagel"
	] 
} returns:
**Response body: None**
**Status:** 204
```

## Part 5

Feel free to extend more API endpoints to fulfill the business needs, be creative. But stay in the context of the `data.json` don't extend the data model.