# 🌦️ Blazor Weather App

This is a full-stack **Weather Web Application** built using **Blazor Server**, **.NET 8**, **Entity Framework Core**, and **MySQL**. It replicates features similar to the Windows Weather App, with a strong focus on clean architecture, authentication, and role-based authorization.

---

## 🚀 Features

- ✅ **User Authentication**
  - Register and login functionality.
  - Password hashing using BCrypt.
  - Session managed with `AuthenticationStateProvider`.

- 🔐 **Role-based Authorization**
  - Two user roles: `Simple` and `SuperUser`.
  - Only `SuperUser` can save up to 5 favorite cities.

- 🌍 **City Search & Weather**
  - Search any city and get the **current weather** and **5-day forecast**.
  - Data fetched using [OpenWeatherMap API](https://openweathermap.org/api).

- ⭐ **Favorite Cities Dashboard**
  - `SuperUsers` can save and remove up to 5 favorite cities.
  - All users can view their own favorites.

- 📧 **Forgot & Reset Password**
  - Forgot password flow with email reset link.
  - SendGrid is used to send reset password emails.

- 🎨 **Tailwind CSS UI**
  - Mobile-friendly and responsive.
  - Custom login layout with background image and top bar.

---

## 🧰 Tech Stack

| Category      | Technology                          |
|---------------|--------------------------------------|
| Frontend      | Blazor Server                        |
| Backend       | .NET 8, C#, Entity Framework Core    |
| Styling       | Tailwind CSS                         |
| Authentication| Custom AuthenticationStateProvider  |
| Database      | MySQL                                |
| Email Service | SendGrid API                         |
| Weather API   | OpenWeatherMap API                   |

---

## ⚙️ Setup Instructions

### 1. 🔧 Prerequisites

- .NET SDK 8
- MySQL Server (local or remote)
- Visual Studio or VS Code
- Git installed

### 2. 🔑 Add Your API Keys

- Create `appsettings.json` (do **not** commit this to GitHub):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=weatherappdb;user=root;password=yourpassword;"
  },
  "OpenWeatherMap": {
    "ApiKey": "your_openweather_api_key"
  },
  "SendGrid": {
    "ApiKey": "your_sendgrid_api_key"
  }
}