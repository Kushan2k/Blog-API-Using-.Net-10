## Blog Api using .Net 10

### Overview

A RESTful API for managing blog posts, built with .NET 10. This project demonstrates modern API development practices including dependency injection, async/await patterns, and entity framework core.

### Features

- Create, read, update, and delete blog posts
- Comment management
- User authentication and authorization
- Pagination and filtering
- Comprehensive error handling

### Prerequisites

- .NET 10 SDK or later
- SQL Server or compatible database
- Visual Studio 2022 or VS Code

### Getting Started

1. Clone the repository
2. Update connection string in `appsettings.json`
3. Run `dotnet ef database update` to apply migrations
4. Execute `dotnet run` to start the API
5. Access the API at `https://localhost:5001`

### API Endpoints

- `GET /api/posts` - List all posts
- `POST /api/posts` - Create a new post
- `GET /api/posts/{id}` - Get post by ID
- `PUT /api/posts/{id}` - Update a post
- `DELETE /api/posts/{id}` - Delete a post

### Project Structure

```
src/
├── Controllers/
├── Models/
├── Services/
└── Data/
```

### License

MIT
