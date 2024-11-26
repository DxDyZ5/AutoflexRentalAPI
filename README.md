# **AutoflexRentalAPI**

Welcome to the **AutoflexRentalAPI**, a robust backend solution for managing vehicle rental operations. This API facilitates seamless management of vehicles, users, reservations, and contact messages, ensuring efficient and reliable service for car rental businesses.

---

## **Features**

- **Vehicle Management**  
  Add, update, delete, and list vehicles with details like brand, model, daily price, availability, and images.  
  Advanced filtering to search by brand, model, or daily price range.

- **User Management**  
  Securely manage user profiles with role-based access control.

- **Reservation System**  
  Create and manage reservations with real-time availability checks.

- **Contact Messaging**  
  Handle customer inquiries with a simple contact message system.

- **Scalable Design**  
  Built with a modular architecture to accommodate future enhancements.

---

## **Technologies Used**

- **.NET 8.0** - Modern and powerful framework for API development.  
- **Entity Framework Core** - For database management and interactions.  
- **SQL Server** - Relational database to store application data.  
- **Swagger/OpenAPI** - API documentation and testing made easy.  

---

## **Getting Started**

### **Prerequisites**

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Git](https://git-scm.com/)
- (Optional) [Postman](https://www.postman.com/) for API testing

### **Installation**

1. **Clone the Repository**  
   ```bash
   git clone https://github.com/DxDyZ5/AutoflexRentalAPI.git
   cd AutoflexRentalAPI
   ```

2. **Set Up the Database**  
   Update the connection string in `appsettings.json` to point to your SQL Server instance.

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=AutoflexRental;User Id=your_username;Password=your_password;"
   }
   ```

3. **Run Migrations**  
   Apply migrations to set up the database schema.
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**  
   Start the API.
   ```bash
   dotnet run
   ```

5. **Access Swagger UI**  
   Navigate to `http://localhost:5000/swagger` in your browser to explore and test the API.

---

## **Endpoints Overview**

### **Users**
- `GET /api/users` - Get a list of all users.
- `POST /api/users` - Add a new user.
- `PUT /api/users/{id}` - Update an existing user.
- `DELETE /api/users/{id}` - Delete a user.

### **Vehicles**
- `GET /api/vehicles` - Get a list of all vehicles.
- `POST /api/vehicles` - Add a new vehicle.
- `PUT /api/vehicles/{id}` - Update a vehicle.
- `DELETE /api/vehicles/{id}` - Delete a vehicle.
- `GET /api/vehicles/search` - Search vehicles by brand, model, or price range.

### **Reservations**
- `GET /api/reservations` - Get a list of all reservations.
- `POST /api/reservations` - Create a new reservation.

### **Contact Messages**
- `GET /api/contact-messages` - Retrieve all messages.
- `POST /api/contact-messages` - Submit a new message.

---

## **Project Structure**

```
AutoflexRentalAPI/
├── Controllers/           # API controllers
├── DTO/                   # Data transfer objects
├── Interfaces/            # Service interfaces
├── Models/                # Database models
├── Services/              # Business logic services
├── obj/                   # Build artifacts
├── Properties/            # Project settings
└── appsettings.json       # Configuration file
```

---

## **Contributing**

Contributions are welcome! Follow these steps to contribute:

1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature-name`).
3. Commit your changes (`git commit -m "Add feature"`).
4. Push to the branch (`git push origin feature-name`).
5. Create a pull request.

---

## **License**

This project is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute it as per the terms.

---

## **Contact**

For questions or support, feel free to contact:  
**Author**: DxDyZ5  
**Email**: [correo@yahoo.com](mailto:youremail@example.com)

--- 

Enjoy using **AutoflexRentalAPI** to power your car rental business! 🚗✨

