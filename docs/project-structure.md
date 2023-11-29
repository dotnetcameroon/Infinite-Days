# Project Structure

Welcome to the Infinite Days Challenge! This document outlines the structure of the project to guide you through the implementation of the required features.

## Overview

Here is what the solution looks like:
``` md
|__ docs
|__ src
|  |__ app
|  |__ lib
|  |__ models
|  |__ ui
|__ tests
```
We will dive into the `src` folder, because the `tests` and `docs` ones are pretty simple to understand.

The project is organized into the following components:

- **app:** Defines the core business logic of our system. Here is where our services and business rules and interfaces relly.
- **lib:** For each of the interfaces defined in the `app` project, the corresponding implementations are hidden in the `lib` project
- **models:** Define models for `Product` and `Order`.
- **ui:** defines how the user finally interacts with our system. It could be a web page, controllers or anything else, but in our case it is a simple Console application.

The dependency injection is already set up, and you can start working on those different projects without worrying on how to wire up things together.
## Guidelines

In order to fulfill this challenge, you must implement all missing features. Here is how:
- After carefully analyzed the code base, find all `TODO` instructions in the project and implement the defined feature.
- Test the features by running the pre-written tests.
> Note: Most of the code you have to write is in the `app`, `models` and `lib` projects.

## Additional Features

The current application partially implements the following features:

- Make an order
- View all proceeded orders
- View all available products.

For this to be a viable product, you have two missing features to implement from scratch:

- Create a product
- Delete a product

    Following the same structure and code organization used for the other features.

Write Unit Tests of the features you added. Good luck!!
