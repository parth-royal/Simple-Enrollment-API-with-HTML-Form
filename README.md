## Simple Enrollment API with HTML Form

This code implements a simple API for managing enrollments using ASP.NET Core. It allows users to create new enrollments through an HTML form, store them in memory, and receive a JSON response containing the created enrollment data.

### Project Structure

The code uses minimal structure and can be run directly without a separate project setup. It includes the following components:

* **Program.cs:** The entry point of the application, containing the code for configuring the app, creating the middleware, and running the server.
* **Enrollment Class:** Defines the `Enrollment` record structure, representing the data for a single enrollment.

### Functionality

1. **API Endpoint:** The `/enrollments` endpoint handles POST requests to create new enrollments.
2. **HTML Form:**  The root path (`/`) serves a simple HTML form to input enrollment details (Student ID, Course ID, and Enrollment Date).
3. **Form Submission:**  When the form is submitted, it sends a POST request to `/enrollments`.
4. **Form Data Parsing:** The endpoint parses the form data from the POST request, validating the input to ensure it's in the correct format.
5. **Enrollment Creation:**  If the input is valid, a new `Enrollment` object is created with the parsed data.
6. **In-Memory Storage:**  The newly created enrollment is added to the `enrollments` list, which acts as an in-memory database.
7. **Response Generation:** The API returns a JSON representation of the created enrollment object with a `201 Created` status code. The `Location` header is set to the URL of the created enrollment resource.

### Running the Application

1. **Install .NET SDK:** Ensure you have the .NET SDK installed on your machine.
2. **Create a Project:** Create a new folder for the project and save the code in a file named `Program.cs`.
3. **Run the App:** Navigate to the project folder in your terminal and run `dotnet run`.

### Considerations

* **In-Memory Storage:** The `enrollments` list is only in memory and will be lost when the application restarts. To persist data, consider using a database such as SQLite or PostgreSQL.
* **Error Handling:** The code currently only returns a `400 Bad Request` status code for invalid input. You should add more detailed error handling and feedback to the user.
* **Security:**  The application lacks security measures like input validation and authorization. Implement these features to protect your API. 
* **UI Design:**  The HTML form is basic. Consider improving the user interface with better styling and design.
* **API Documentation:**  Consider using Swagger to generate API documentation.

This README provides a basic overview of the project. Further documentation for specific functionalities or additional features can be added as needed. 



# XEnrollmentAPI
