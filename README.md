# Online Appointment System

Online Appointment System is a comprehensive web application built to streamline appointment management between clients and therapists. The system features role-based access control, a structured server-side architecture, and user-friendly dashboards tailored for secretaries, clients, and therapists.

## Features

- **User Authentication:** Role-based access control ensures that each user has access to relevant features and data.
- **Secretary Dashboard:**
  - View and manage patients, therapists, and appointments.
- **Client Dashboard:**
  - View, cancel, and schedule appointments.
- **Therapist Dashboard:**
  - View appointments, filter by date.

## Installation

1. **Clone Repository:**
   ```
   git clone https://github.com/NechamiWa/Clinic-Online-Appointment-System.git
   ```
2. **Server-Side Setup:**
   - Navigate to the `Server` directory and set up the C# project. Install necessary dependencies.
   - Configure the connection string in `appsettings.json`.
   - Run the project to start the server.
3. **Client-Side Setup:**
   - Navigate to the `Client` directory and set up the React project. Install dependencies.
   - Start the development server.
4. **Database Setup:**
   - Execute SQL scripts provided in the `Database` directory to create tables and seed initial data.
   - Update connection string in the server-side project.

## Technologies Used

- **Server-Side:**
  - C#, ASP.NET Core, Entity Framework Core
- **Client-Side:**
  - React, JavaScript, HTML/CSS
- **Database:**
  - SQL Server

