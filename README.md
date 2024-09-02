# MicroServices

This project is a microservices-based architecture implemented using .NET 8 and Entity Framework Core. The solution consists of three micro-services: UserService, ProductService, and OrderService. MainService handle interactions between these services using HTTP APIs where each is responsible for its own domain.

## Services

### MainService

- **Description**: Orchestrates operations across `UserService`, `ProductService`, and `OrderService`.
- **Endpoints**:
  - `POST /api/main/orders/{id}` - Retrieve order details by ID, including user and product names.

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
  - `GET /api/orders/{id}` - Retrieve an order by ID.
  - `POST /api/orders` - Create a new order.

## Configuration

Each service has its own database context and is configured to use Entity Framework Core for data access. The services are set up to communicate with each other through HTTP requests.

### MainService

- **Port:** 7133
- **DTOs:** `UserDto`, `ProductDto`, `OrderDto`
- **Dependencies:** Requires `UserService`, `ProductService` and `OrderService` to be running.
  - **Note**: `MainService` simplifies the interaction with the microservices by providing a unified interface.

### UserService

- **Port:** 7188
- **Database Context:** `UserContext`
- **Models:** `User`

### ProductService

- **Port:** 7197
- **Database Context:** `ProductContext`
- **Models:** `Product`

### OrderService

- **Port:** 7138
- **Database Context:** `OrderContext`
- **Models:** `Order`

## Swagger

Each service includes Swagger for testing. You can access these at the following URLs:

- MainService: `https://localhost:7133/swagger`
- UserService: `https://localhost:7188/swagger`
- ProductService: `https://localhost:7197/swagger`
- OrderService: `https://localhost:7138/swagger`
