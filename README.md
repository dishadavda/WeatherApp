# 🌦️ Weather App (Blazor Server)

This is a weather forecast web application built using **Blazor Server**. It allows authenticated users to search for city weather data and view a 5-day forecast using the **OpenWeatherMap API**. Users are assigned roles: `Simple` and `Super`. Only **Super** users can save up to 5 favorite cities and manage them from the dashboard.

---

## 📦 Tech Stack Used

| Area             | Technology / Tool                             |
| ---------------- | --------------------------------------------- |
| Frontend         | Blazor Server (C# + Razor Components)         |
| Styling          | Tailwind CSS                                  |
| Backend          | .NET 8, ASP.NET Core                          |
| Database         | MySQL                                         |
| Auth             | ASP.NET Core Identity                         |
| API              | [OpenWeatherMap](https://openweathermap.org/) |
| Email (Optional) | SendGrid for email confirmation               |
| State & Storage  | `AuthenticationStateProvider`, `LocalStorage` |

---

## ⚙️ Setup Instructions

### ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- MySQL installed and running
- [Node.js](https://nodejs.org/en) (for Tailwind CLI if needed)
- Visual Studio 2022 or VS Code

---

### 🔐 1. Configure `appsettings.json`

Create a new `appsettings.json` (DO NOT PUSH THIS TO GITHUB):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=root;password=yourpassword;database=WeatherAppDb;"
  },
  "OpenWeatherMap": {
    "ApiKey": "your_open_weather_api_key"
  },
  "SendGrid": {
    "ApiKey": "your_sendgrid_api_key"
  }
}
```

---

### 🛠️ 2. Database Setup

1. Run EF Core migrations:

   ```bash
   dotnet ef database update
   ```

2. Ensure roles are seeded:

   - `Simple`
   - `Super`

(These are created during Identity seeding in `Startup.cs` or `Program.cs`.)

---

### ▶️ 3. Run the App

In the project root:

```bash
dotnet run
```

App will be available at: [https://localhost:5001](https://localhost:5001)

---

## 👥 Roles and Permissions

| Role   | Permissions                                   |
| ------ | --------------------------------------------- |
| Simple | Can search weather for any city               |
| Super  | Can search weather AND save 5 favorite cities |

---

## 📌 Features

- 🔐 Login / Register with Identity Roles
- 🔍 Weather Search for Any City
- 📊 5-Day Forecast
- ⭐ Save Favorite Cities (Super Users Only, Max 5)
- 📜 Role-based access control
- 📂 Responsive, Tailwind-Styled UI

---

## 📌 Assumptions & Limitations

### ✅ Assumptions:

- Only `Super` users should save cities to favorites.
- Favorite cities are limited to **5 per user**.
- Email confirmation using SendGrid is optional.

### ⚠️ Known Limitations:

- No frontend validation for role-based features (relies on backend enforcement).
- Weather icons/images are hardcoded instead of dynamic from API.
- No rate limiting or caching on API calls.

---

## 🚀 Future Improvements

- Add role management UI in the admin panel.
- Better error and success notifications with dismissable alerts.
- Replace image URLs with weather icons from the OpenWeather API.
- Add responsive loading skeletons or spinners.
- Auto-refresh token/session timeout handling.
- Use Redis for caching frequently searched cities.

---

## 🧑‍💻 Author

👩‍💻 [Disha Rakholiya](https://github.com/dishadavda)

---

## 🛡️ License

MIT License

