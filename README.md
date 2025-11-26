# Web API Consumer

A C# console application that consumes REST APIs from GitHub and Zippopotam to fetch and display .NET Foundation repository information and postal code data.

## About

This project demonstrates how to work with REST APIs in C#. It fetches data from two different APIs, deserializes JSON responses, and displays formatted information in the console.

## Features

- Fetches .NET Foundation repositories from GitHub API
- Displays repository name, homepage, URL, description, watchers, and last push date
- Fetches postal code information for Montvale, NJ from Zippopotam API
- Formats numbers with spaces (100 000) and dates (YYYY-MM-DD HH:MM:SS)

## Technologies

- C# / .NET 10.0
- HttpClient for REST API calls
- System.Text.Json for JSON deserialization

## How to Run

```bash
git clone <your-repo-url>
cd Konsumera-web-API
dotnet run
```

## APIs Used

- [GitHub API](https://api.github.com/orgs/dotnet/repos) - .NET Foundation repositories
- [Zippopotam API](https://api.zippopotam.us/us/nj/montvale) - Postal code data

## What I Learned

- Making HTTP requests with HttpClient
- Deserializing JSON to C# objects
- Using JsonPropertyName attributes for JSON mapping
- Async/await for asynchronous operations
- Formatting numbers and dates in C#

**Author:** Djan Karis Lomongo Freolo 

**Course:** KYHA_DSO25

**Published Date:** 26-11-2025
