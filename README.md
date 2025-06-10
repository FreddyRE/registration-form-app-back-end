# 🧠 Registration Form App – Backend

This is the **backend** for the Registration Form App, built using **C# (.NET Core)** and **Entity Framework Core with InMemory provider**. It handles form registration logic, validation, and persistence — all without relying on an external database.

---

# 📐 Setup instructions

```bash
1. Clone the repository
git clone https://github.com/your-username/registration-form-app-back-end.git

2. Navigate into the folder
cd registration-form-app-back-end

3. Restore dependencies
dotnet restore

4. Run the application
dotnet run
```
---


## 🚀 Features

- ✅ ASP.NET Core Web API
- ✅ EF Core InMemory for development
- ✅ DTOs and AutoMapper for data mapping
- ✅ Business rule validations (e.g. age must be 18+)
- ✅ Custom exceptions and centralized error handling
- ✅ Ready to swap in a real database later

---

## 🧠 Technologies Used

- ASP.NET Core 6+
- EF Core InMemory Provider
- AutoMapper
- Fluent error handling (ValidationException)
- C# 10 / .NET 6+

---

## 🧪 Example DTO

```csharp
public class RegistrationRequestDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string DateOfBirth { get; set; } // must be 18+
}

``` 
