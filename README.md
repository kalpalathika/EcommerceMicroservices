# E-commerce Microservices Platform

A distributed e-commerce application built with .NET 9.0 microservices architecture, featuring independent services for authentication, products, shopping cart, orders, coupons, and email notifications.

## Architecture

![Architecture Diagram](./Ecommerce%20Microservices%20Architecture.png)

## Services

- **Auth API** - User authentication and authorization with ASP.NET Core Identity
- **Product API** - Product catalog management
- **Shopping Cart API** - Shopping cart operations
- **Order API** - Order processing and management
- **Coupon API** - Discount coupon management
- **Email API** - Email notifications
- **Web Frontend** - ASP.NET Core MVC application

## Tech Stack

- **.NET 9.0** - Framework
- **Entity Framework Core** - ORM with SQL Server
- **Azure Service Bus** - Async messaging between services
- **AutoMapper** - Object mapping
- **Swagger** - API documentation
- **ASP.NET Core Identity** - Authentication & authorization

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server
- Azure Service Bus (or connection string)

### Run All Services

```bash
# Run all services
python start-services.py

# Run with hot reload
python start-services.py --watch
```

### Run Individual Services

```bash
cd Services/Ecommerce.Services.AuthAPI
dotnet run
```

## Project Structure

```
Services/                        # Microservices
  - Ecommerce.Services.AuthAPI
  - Ecommerce.Services.ProductAPI
  - Ecommerce.Services.ShoppingCartAPI
  - Ecommerce.Services.OrderAPI
  - Ecommerce.Services.CouponAPI
  - Ecommerce.Services.EmailAPI
FrontEnd/
  - Ecommerce.Web                # Web application
Integration/
  - Ecommerce.MessageBus         # Shared messaging library
start-services.py                # Service launcher script
```

## Configuration

Each service requires its own `appsettings.json` with:
- Database connection strings
- Azure Service Bus connection string
- JWT settings (for Auth API)
- Service-specific configurations
