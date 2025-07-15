# Internal Resource Booking App

A streamlined internal web-based system that allows employees to "book shared resources" such as meeting rooms, company vehicles, and specialized equipment. Designed to minimize double bookings and improve scheduling transparency within the organization.


## Features

### Resource Management
- Add, view, update, and delete resources
- Resource details: name, location, capacity, description, availability
- Server-side validation for input fields

### Booking Management
- View existing bookings
- Create new bookings for specific time slots
- Prevent double-booking through conflict validation
- View upcoming bookings per resource

### Booking Validation
- Robust conflict detection logic to prevent overlapping time slots
- Validation for start and end time rules
- User-friendly error messages when conflicts occur



## Tech Stack

### Backend
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server / LocalDB
- Server-side validation using Data Annotations

### Frontend
- Razor Views (CSHTML)
- Bootstrap 5
- Clean and responsive layout with navigation, footer, and booking views


## Prerequisites

- Visual Studio 2022
- .NET SDK 6.0 or later
- SQL Server Express or LocalDB
- EF Core Tools (installed via NuGet)



## Getting Started

### Clone the Repository

```bash
git clone https://github.com/yourusername/internal-booking-app.git
```

### Open in Visual Studio

- Open the solution file: `Internal_Booking_App.sln`



### Configure the Database

Edit your `appsettings.json`:

--Connection String Format--

"ConnectionStrings": {
  "DefaultConnection": "Server=your_server_name;Database=your_db_name;User Id=your_username;Password=your_password;Trusted_Connection=True;TrustServerCertificate=True"
}

```json e.g
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-70NCK74\\SQLEXPRESS;Database=InternalBookingDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```



### Apply Migrations

Open Package Manager Console in Visual Studio:

```powershell
Update-Database
```

This will create and seed the database using the current EF Core migrations.



### Run the Application

- Press F5 or Ctrl + F5 in Visual Studio


## Booking Logic (Conflict Prevention)

The system uses robust logic to prevent overlapping bookings. It checks if the requested resource is already booked within the desired time range:

```csharp
b.ResourceId == booking.ResourceId &&
b.EndTime > booking.StartTime &&
b.StartTime < booking.EndTime
```

If a conflict is found, the booking is rejected with a clear message to the user.


## Testing the App

- Navigate to `/Resource` to manage resources
- Navigate to `/Booking` to manage bookings
- Try creating bookings that overlap and confirm conflict validation works
- Edit and delete resources as needed



## Project Structure


Internal_Booking_App/
│
├── Controllers/
│   ├── ResourceController.cs
│   └── BookingController.cs
│
├── Models/
│   ├── Resource.cs
│   └── Booking.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Views/
│   ├── Resource/...
│   ├── Booking/...
│   └── Shared/_Layout.cshtml
│
├── wwwroot/
│   └── css/site.css
│
├── appsettings.json
└── Program.cs


## Optional Enhancements

If time permits:
- [ ] Edit and cancel existing bookings
- [ ] Dashboard view showing today’s bookings
- [ ] Search or filter for resources/bookings
- [ ] Add seeding to populate test data


## License

This project is provided for educational and internal demo purposes.


## Author

Sifiso Nkosi  
Junior ASP.NET Core Developer | Passionate about building clean, intuitive web systems.
