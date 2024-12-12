# Butterfly Calculator Web API

The Butterfly Calculator is a simple Web API for performing basic maths operations like addition, subtraction, multiplication, and division. This project demonstrates modern software development approaches and technologies while keeping things clear and maintainable.

This project is being used by **Butterfly.Healthcare** to evaluate the technical skills of candidates during the recruitment process.

---

## Features

- Supports core maths operations (`add`, `subtract`, `multiply`, `divide`).
- Clean code principles with separation of responsibilities.
- Structured logging using Serilog.
- Input validation with helpful error messages.
- Robust exception handling for a smoother user experience.
- Follows RESTful API design principles.
- Includes unit tests for core business logic.

---

## Technologies and Practices

### Technologies Used

1. **ASP.NET Core 9/3.1**
   - Lightweight, cross-platform framework for web APIs.
   - API endpoint defined using `ControllerBase`.

2. **Entity Mapping**:
   - AutoMapper for clean and efficient model mapping.

3. **Logging**:
   - Serilog for structured logging and flexible output.

4. **Dependency Injection**:
   - Built-in DI for adding services like `ICalculationService` and `ILogger`.

5. **Exception Handling**:
   - Handles errors gracefully using try-catch blocks.

6. **Validation**:
   - Checks input parameters and provides user-friendly feedback.

7. **Unit Testing**:
   - XUnit is used to test key functionality of the application.

---

### Best Practices Used

- **Clear Responsibilities**:
  - Validation logic is separate from business logic (`ValidateParameters` method).
  - The controller is responsible for routing and calling services.

- **Structured Logging**:
  - Log messages include details like method names, inputs, and errors for easy debugging.

- **Error Handling**:
  - Provides meaningful error messages for invalid inputs or unexpected issues.

- **Async Programming**:
  - Uses `async/await` to handle requests efficiently.

- **Test-Driven Development**:
  - Core logic is covered with unit tests to ensure reliability and reduce regression.

---

## Getting Started

Follow these steps to set up and run the project on your local machine.

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) or your favourite code editor.
- Command-line interface (CLI) for running the app.

---

### Steps to Run

1. **Clone the Repository**:
   ``git clone https://github.com/yourusername/Butterfly.Calculator.git
   cd Butterfly.Calculator``

2. **Restore Dependencies:**
    ``dotnet restore``

3. **Build the Project:**
   ``dotnet build``

4. **Run the Application:**
    ``dotnet run --project Butterfly.Calculator.WebApi``

5. **Access the API:**:
    Open your browser or a tool like Postman and use:
    
    https://localhost:5001/calculation/calculate?addend1=10&addend2=5&operation=add

---

## Unit Testing

The project includes unit tests to ensure the accuracy and reliability of its core functionality. These tests validate:

- Correct results for all mathematical operations (add, subtract, multiply, divide).
- Validation errors for invalid inputs (e.g., division by zero, invalid operations).
- Edge cases to confirm robustness.

### Testing Framework
XUnit: A popular testing framework for .NET applications.

**Navigate to the Test Directory:**
    ``cd Butterfly.Calculator.Tests``

**Run the unit tests:**
    ``dotnet test``
    
Test results will be displayed in the terminal, showing whether all test cases passed.

