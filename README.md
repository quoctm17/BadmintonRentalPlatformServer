# ️🏸 Badminton Court Booking Platform - Backend

Welcome to the backend of the Badminton Court Booking Platform! This project is built using ASP.NET Core Web API. This README file provides an overview of the product, the technologies used, instructions for using GitHub, and important notes for cloning the project.

## 📚 Table of Contents
- [Overview](#overview)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## 🌟 Overview
The Badminton Court Booking Platform backend is designed to handle API requests for booking badminton courts, managing users, and handling authentication and authorization.

## 🛠 Technologies Used
- **Backend**: ASP.NET Core Web API
- **Database**: SQL Server
- **Authentication**: JWT (JSON Web Tokens)
- **Hosting**: Azure

## 🚀 Getting Started

### Prerequisites
- .NET 5.0 SDK or later
- SQL Server
- Git

### Installation
1. **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/badminton-court-booking-backend.git
    cd badminton-court-booking-backend
    ```

2. **Setup:**
    - Restore the .NET dependencies:
      ```bash
      dotnet restore
      ```
    - Update the `appsettings.json` file with your SQL Server connection string:
      ```json
      {
        "ConnectionStrings": {
          "DefaultConnection": "Your_SQL_Server_Connection_String"
        }
      }
      ```
    - Run the backend server:
      ```bash
      dotnet run
      ```

## 📖 Usage
1. The backend server will run at `http://localhost:5142`.
2. You can use tools like Postman to test the API endpoints.

## 📝 Contributing
We welcome contributions! Please follow these steps to contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature-name`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature-name`).
5. Create a new Pull Request.

## ⚠️ Important Notes
- Ensure that your development environment meets the prerequisites mentioned above.
- When cloning the project, update the `appsettings.json` file with your local configurations.
- For any issues or feature requests, please open an issue on GitHub.

## 📄 License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

---

Thank you for using the Badminton Court Booking Platform! If you have any questions, feel free to reach out to us.

Happy coding! 🎉
