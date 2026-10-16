UlaMessenger.API

UlaMessenger.API is a RESTful backend API built with ASP.NET Core, designed to support messaging services, secure authentication, and communication between client applications and backend services.

Features

RESTful API — HTTP endpoints for application functionality.

JWT Authentication — Token-based authentication and authorization.

SMS Integration — Twilio integration for SMS messaging.

Entity Framework Core — Database access with SQL Server.

Layered Architecture — Separation of business logic, data access, entities, and API controllers.

Dependency Injection — Autofac integration for dependency management.

Swagger Documentation — Interactive API documentation and endpoint testing.

Exception Handling — Custom exception middleware for centralized error handling.

Tech Stack

C#

ASP.NET Core

Entity Framework Core

Microsoft SQL Server

JWT

Twilio

Autofac

Swagger / OpenAPI

Architecture

The solution follows a layered architecture to improve separation of concerns and maintainability.

UlaMessenger.API
├── Business       # Business logic and services
├── Core           # Shared utilities and infrastructure
├── DataAccess     # Database operations
├── Entities       # Domain entities and models
└── WebAPI         # API controllers and HTTP configuration

Getting Started

Prerequisites

.NET Core 3.0 SDK

Microsoft SQL Server

Visual Studio or another compatible IDE

Twilio account and credentials for SMS functionality

Installation

Clone the repository:

git clone https://github.com/erenkara1907/UlaMessenger.API.git

Navigate to the project directory:

cd UlaMessenger.API

Configure the database connection string and required application settings.

Configure JWT authentication settings and Twilio credentials using secure configuration or environment variables.

Restore dependencies:

dotnet restore

Run the application:

dotnet run --project WebAPI

API Documentation

Swagger is configured to provide interactive API documentation. Once the application is running, access the Swagger UI at:

https://localhost:<port>/swagger

Replace <port> with the port configured for your application.

Security

Keep database credentials, JWT signing keys, and Twilio credentials out of source control.

Use HTTPS for API communication.

Protect endpoints with appropriate authentication and authorization policies.

License

No license has been specified for this repository yet.
