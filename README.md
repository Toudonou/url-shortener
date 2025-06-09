# URL Shortener

A simple URL shortener service built with ASP.NET Core, Entity Framework Core, PostgreSQL, and Docker.

## Features

### Frontend
- Paste any long URL and get a short version instantly
- Copy the shortened URL to your clipboard with one click
- Popup modal for sharing your new short link

### Backend
- Shorten long URLs to unique 8-character codes
- Redirect short URLs to original long URLs
- Track usage count for each short URL
- RESTful API with Swagger documentation
- Dockerized for easy deployment


## Prerequisites

- HTML, CSS, JavaScript (Vanilla)
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [PostgreSQL](https://www.postgresql.org/) (used via Docker)

## Getting Started

### 1. Clone the repository

```sh
git clone https://github.com/Toudonou/url-shortener
cd url-shortener
```

### 2. Configure Environment Variables

Edit the `.env` file to set your database credentials and connection string. Default values are provided.

### 3. Build and Run with Docker Compose

```sh
docker compose up --build
```

- The backend API will be available at `http://localhost:5122` (HTTP) and `https://localhost:7072` (HTTPS).
- PostgreSQL will be available at `localhost:5460`.

### 4. API Documentation

Once running, access Swagger UI at:

- [http://localhost:5122/swagger](http://localhost:5122/swagger)

## API Endpoints

- `POST /shorten/` — Shorten a long URL
- `GET /r/{shortUrl}` — Redirect to the original URL
- `GET /urls/` — List all shortened URLs
- `GET /health/` — Health check

## Project Structure

- `UrlShortenerFront/` — Frontend application (HTML, CSS, JS)
- `UrlShortenerBack/` — ASP.NET Core backend
- `compose.yaml` — Docker Compose configuration
- `.env` — Environment variables for Docker and the app

## Development

To run locally without Docker:

1. Ensure PostgreSQL is running and matches `.env` settings.
2. From `UrlShortenerBack/`:

```sh
dotnet ef database update
dotnet run
```

## Author

- [Toudonou](https://github.com/Toudonou)

## Useful Links
- [How to Build a URL Shortener With .NET](https://www.milanjovanovic.tech/blog/how-to-build-a-url-shortener-with-dotnet)
- [Url Shortener UI](https://www.behance.net/gallery/197738155/URL-Shortener?tracking_source=search_projects|url+shortener+ui+design&l=8)

## License

This project is open source, under the MIT License [see](LICENSE).