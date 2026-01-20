## Blog Api using .Net 10

### Overview

A RESTful API for managing blog posts, built with .NET 10. This project demonstrates modern API development practices including dependency injection, async/await patterns, and entity framework core.

### Features

- Create, read, update, and delete blog posts
- User authentication and authorization
- Pagination and filtering
- Comprehensive error handling

### Prerequisites

- .NET 10 SDK or later
- MySql or compatible database
- Visual Studio 2022 or VS Code
- Postman or similar API testing tool

### Getting Started

1. Clone the repository
2. Update connection string in `appsettings.json`
3. Run `dotnet ef database update` to apply migrations
4. Execute `dotnet run` to start the API
5. Access the API at `https://localhost:5001`

### API Endpoints

- `GET /api/blogs` - List all posts
- `POST /api/blogs` - Create a new post
- `GET /api/blogs/{id}` - Get post by ID
- `PUT /api/blogs/{id}` - Update a post
- `DELETE /api/blogs/{id}` - Delete a post

- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - User login

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
