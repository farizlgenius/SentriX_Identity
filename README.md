# SentriX --- Identity Module

**SentriX-Identity** is a centralized authentication and authorization
service designed for microservice environments.\
It provides secure user management, role management, location-based
access, and supports **JWT** and **API Key** authentication.

------------------------------------------------------------------------

## ✨ Features

### 🔐 Authentication Methods

The service supports **dual authentication**:

1.  **JWT Bearer Token**
    -   Standard user authentication
    -   Token validation with issuer, audience, and signing key
    -   Expiration & lifetime validation
2.  **X-API-KEY**
    -   Designed for service-to-service communication
    -   API keys stored securely in database
    -   Supports multiple API keys
    -   Owner tracking & claim generation

------------------------------------------------------------------------

### 👤 Identity Management

The Identity Service is responsible for:

-   User registration & authentication
-   Role management
-   Location assignment per user
-   Claims generation
-   Secure token issuing

------------------------------------------------------------------------

## 🧱 Architecture Overview

This module is built using:

-   ASP.NET Core
-   JWT Authentication
-   Custom API Key Authentication Handler
-   MSSQL Database
-   Clean Architecture principles

```{=html}
<!-- -->
```
    Client → API Gateway → SentriX Identity → Database

------------------------------------------------------------------------

## 🔑 Authentication Flow

### JWT Flow

1.  User logs in

2.  Identity service validates credentials

3.  JWT token issued

4.  Client sends:

        Authorization: Bearer <token>

### API Key Flow

1.  Client sends:

        x-api-key: <api-key>

2.  API Key is validated from database

3.  Claims are generated dynamically

4.  Access granted

------------------------------------------------------------------------

## 🛡️ Authorization

The system supports **policy-based authorization**:

  Policy        Description
  ------------- -------------------------------------
  JwtOnly       Access allowed only via JWT
  ApiKeyOnly    Access allowed only via API Key
  JwtOrApiKey   Accepts both authentication methods

------------------------------------------------------------------------

## ⚠️ Custom Error Handling

Unified response format for **401 / 403**:

``` json
{
  "status": 401,
  "timestamp": "UTC Timestamp",
  "message": "Unauthorized access"
}
```

The service dynamically detects the failing scheme (JWT or API Key) and
returns the correct error message.

------------------------------------------------------------------------

## 📂 Project Structure

    SentriX-Identity
     ├── Identity.Api
     │   ├── Authentication
     │   ├── Helpers
     │   ├── Middleware
     │   └── Controllers
     │
     ├── Identity.Application
     │   ├── Services
     │   ├── DTOs
     │   └── Settings
     │
     ├── Identity.Infrastructure
     │   ├── Database
     │   └── Repositories

------------------------------------------------------------------------

## ⚙️ Configuration

### appsettings.json

``` json
"JwtSetting": {
  "Secret": "YOUR_SECRET_KEY",
  "Issuer": "SentriX",
  "Audience": "SentriXClients",
  "AccessTokenMinutes": 60
}
```

------------------------------------------------------------------------

## 🚀 Running the Project

### 1. Restore packages

    dotnet restore

### 2. Run database migration

    dotnet ef database update

### 3. Run service

    dotnet run

------------------------------------------------------------------------

## 📌 Usage Example

### Call secured endpoint with JWT

    GET /api/users
    Authorization: Bearer <token>

### Call secured endpoint with API Key

    GET /api/internal/service
    x-api-key: <api-key>

------------------------------------------------------------------------

## 🎯 Purpose

SentriX Identity acts as the **central trust authority** for the SentriX
ecosystem, ensuring:

-   Secure authentication
-   Scalable authorization
-   Consistent identity management across services

------------------------------------------------------------------------

## 📝 License

Internal Project --- SentriX Platform
