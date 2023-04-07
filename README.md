![FullStack Labs](/assets/FSL-logo-portrait.png)

# HeyURL! Code Challenge

Challenge for FullStack Labs. Please setup your environment following the `Getting Started`
section before starting the challenge.

## Getting Started

1. Install [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) or the [dotnet 5.0.7 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

2. Clone repository

3. Open the .sln file in Visual Studio 2019 and run the project, or start the application using the dotnet cli:

```sh
$ cd hey-url-challenge-code-dotnet
$ dotnet watch run
```

8. Open your browser

[https://localhost:5001/](https://localhost:5001/)

## Requirements
1. Implement actions to create a short URL based on a given full URL
2. If URL is not valid, the application returns an error message to the user
3. We want to be able to provide basic click metrics to our users for each URL they generate.
   a. Every time that someone clicks a short URL, it should record that click
   b. the record should include the user platform and browser detected from the user agent
4. We want to create a metrics panel for the user to view the stats for every short URL.
   a. The user should be able to see total clicks per day on the current month
   b. An additional chart with a breakdown of browsers and platforms
5. If someone tries to visit a invalid short URL then it should return a 404 page
6. Business logic and requirements should be tested with NUnit
7. Provide EF migrations that can generate a SQL database schema compatible with the models

# Spec for generating short URLs

- It MUST have 5 characters in length e.g. NELNT
- It MUST generate only upper case letters
- It MUST NOT generate special characters
- It MUST NOT generate whitespace
- It MUST be unique
- `ShortUrl` field should store only the generated code

## Challenge

See [CHALLENGE.md](./CHALLENGE.md)
