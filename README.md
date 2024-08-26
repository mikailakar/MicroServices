# MicroServices

This project is a microservices-based architecture implemented using .NET 8 and Entity Framework Core. The solution consists of three services: UserService, ProductService, and OrderService. Each service is responsible for its own domain and communicates with the others using HTTP APIs.

## Services

### UserService

- **Endpoints:**
  - `GET /api/users` - Retrieve all users.
  - `GET /api/users/{id}` - Retrieve a user by ID.
  - `POST /api/users` - Add a new user.

### ProductService

- **Endpoints:**
  - `GET /api/products` - Retrieve all products.
  - `GET /api/products/{id}` - Retrieve a product by ID.
  - `POST /api/products` - Add a new product.

### OrderService

- **Endpoints:**
  - `GET /api/orders` - Retrieve all orders.
  - `POST /api/orders` - Create a new order.
  - `GET /api/orders/{orderId}` - Retrieve order details, including user and product names.
    - **Details**: Reaches UserService and ProductService. Uses `GET /api/users/{id}` and `GET /api/products/{id}` from these services to retrieve user and product information.

## Configuration

Each service has its own database context and is configured to use Entity Framework Core for data access. The services are set up to communicate with each other through HTTP requests.

### User Service

- **Port:** 7188
- **Database Context:** `UserContext`
- **Models:** `User`

### Product Service

- **Port:** 7197
- **Database Context:** `ProductContext`
- **Models:** `Product`

### Order Service

- **Port:** 7138
- **Database Context:** `OrderContext`
- **Models:** `Order`
- **DTOs:** `UserDto`, `ProductDto`
- **Dependencies:** Requires User Service and Product Service to be running.

Ensure that each service is running on its specified port. The OrderService requires both the UserService and ProductService to be available to retrieve user and product names.

## Swagger

Each service includes Swagger UI for API documentation and testing. Access Swagger UI at the following URLs:

- User Service: `https://localhost:7188/swagger`
- Product Service: `https://localhost:7197/swagger`
- Order Service: `https://localhost:7138/swagger`

## Contact

If you have any questions or suggestions, feel free to reach out:

- **Email**: mikailakr42@gmail.com
- **GitHub**: [mikailakar](https://github.com/mikailakar)
