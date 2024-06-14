# ️🏸 Badminton Court Booking Platform

Welcome to the Badminton Court Booking Platform! This project is built using ASP.NET Core Web API for the backend and Next.js Framework for the frontend. This README file provides an overview of the product, the technologies used, instructions for using GitHub, and important notes for cloning the project.

## 📚 Table of Contents
- [Overview](#overview)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## 🌟 Overview
The Badminton Court Booking Platform is designed to streamline the process of booking badminton courts. Users can view available courts, book them, and manage their bookings all through an intuitive web interface.

## 🛠 Technologies Used
- **Backend**: ASP.NET Core Web API
- **Frontend**: Next.js
- **Database**: SQL Server
- **Authentication**: JWT (JSON Web Tokens)
- **Hosting**: Azure

## 🚀 Getting Started

### Prerequisites
- .NET 5.0 SDK or later
- Node.js 14.x or later
- SQL Server
- Git

### Installation
1. **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/badminton-court-booking.git
    cd badminton-court-booking
    ```

2. **Backend Setup:**
    - Navigate to the backend directory:
      ```bash
      cd backend
      ```
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

3. **Frontend Setup:**
    - Navigate to the frontend directory:
      ```bash
      cd frontend
      ```
    - Install the Node.js dependencies:
      ```bash
      npm install
      ```
    - Create a `.env.local` file and add your backend API URL:
      ```env
      NEXT_PUBLIC_API_URL=http://localhost:5000
      ```
    - Run the frontend server:
      ```bash
      npm run dev
      ```

## 📖 Usage
1. Open your browser and navigate to `http://localhost:3000`.
2. Register a new account or log in with existing credentials.
3. View available badminton courts and book your preferred time slots.
4. Manage your bookings from your user dashboard.

## 📝 Contributing
We welcome contributions! Please follow these steps to contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature-name`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature-name`).
5. Create a new Pull Request.

## ⚠️ Important Notes
- Ensure that your development environment meets the prerequisites mentioned above.
- When cloning the project, update the `appsettings.json` and `.env.local` files with your local configurations.
- For any issues or feature requests, please open an issue on GitHub.

## 📄 License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

---

Thank you for using the Badminton Court Booking Platform! If you have any questions, feel free to reach out to us.

Happy coding! 🎉
