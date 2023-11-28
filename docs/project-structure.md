# Project Structure

Welcome to the E-commerce Order Processing System Challenge! This document outlines the structure of the project to guide you through the implementation of the required features.

## Overview

Here is what the solution looks like:
``` md
|_ src
| |_ app
| |_ lib
| |_ models
| |_ ui
|_ tests
```
We will dive into the `src` folder, because the `tests` one is pretty simple to understand.

The project is organized into the following components:

- **app:** Defines the core business logic of our system. Here is where our services and business rules and interfaces rely.
- **lib:** For each of the interfaces defined in the `app` project, the corresponding implementations are hidden in the `lib` project
- **models:** Define models for `Product` and `Order`.
- **ui:** defines how the user finally interacts with our system. It could be a web page, controllers or anything else, but in our case it is a simple Console application.

## Guidelines

In order to fullfil this challenge, you must implement all missing features. Here is how:
- After carefully analyzed the code base, find all `TODO` instructions in the project and implement the defined feature.
- Test the features by running the pre-written tests.
> Note: Most of the code you have to write is in the `app`, `models` and `lib` projects.

## Additional Resources

The current application implements the following features:

- Make an order
- View all proceeded orders
- View all available products.

You can additionally showcase your skills by implementing the missing features like:

- Create a product
- Delete a product

Following the same structure and code organization used for the other features.

Write tests of the features you added. Good luck!!
