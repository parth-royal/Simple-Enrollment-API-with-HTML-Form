// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // In-memory storage for enrollments
// var enrollments = new List<Enrollment>();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.MapPost("/enrollments", async (HttpContext context) =>
// {
//     // Parse form data
//     var form = await context.Request.ReadFormAsync();
//     if (!int.TryParse(form["StudentId"], out var studentId) || 
//         !int.TryParse(form["CourseId"], out var courseId) ||
//         !DateTime.TryParse(form["EnrollmentDate"], out var enrollmentDate))
//     {
//         context.Response.StatusCode = 400; // Bad request
//         return;
//     }

//     // Create enrollment
//     var enrollment = new Enrollment
//     {
//         StudentId = studentId,
//         CourseId = courseId,
//         EnrollmentDate = enrollmentDate
//     };

//     enrollments.Add(enrollment);

//     // Return success response with created enrollment data
//     context.Response.StatusCode = 201; // Created
//     context.Response.Headers.Add("Location", $"/enrollments/{enrollments.IndexOf(enrollment)}");
//     await context.Response.WriteAsJsonAsync(enrollment);
// });

// app.Run();

// record Enrollment
// {
//     public int StudentId { get; init; }
//     public int CourseId { get; init; }
//     public DateTime EnrollmentDate { get; init; }
// }

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In-memory storage for enrollments
var enrollments = new List<Enrollment>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Serve the index.html file
app.UseStaticFiles();

app.MapGet("/", (HttpContext context) =>
{
    return context.Response.WriteAsync("<!DOCTYPE html>\n" +
                                        "<html>\n" +
                                        "<head>\n" +
                                        "    <title>Enrollment Form</title>\n" +
                                        "</head>\n" +
                                        "<body>\n" +
                                        "    <h1>Add New Enrollment</h1>\n" +
                                        "    <form action=\"/enrollments\" method=\"post\">\n" +
                                        "        <label for=\"studentId\">Student ID:</label>\n" +
                                        "        <input type=\"number\" id=\"studentId\" name=\"StudentId\" required><br><br>\n" +
                                        "        <label for=\"courseId\">Course ID:</label>\n" +
                                        "        <input type=\"number\" id=\"courseId\" name=\"CourseId\" required><br><br>\n" +
                                        "        <label for=\"enrollmentDate\">Enrollment Date:</label>\n" +
                                        "        <input type=\"date\" id=\"enrollmentDate\" name=\"EnrollmentDate\" required><br><br>\n" +
                                        "        <button type=\"submit\">Submit</button>\n" +
                                        "    </form>\n" +
                                        "</body>\n" +
                                        "</html>");
});

app.MapPost("/enrollments", async (HttpContext context) =>
{
    // Parse form data
    var form = await context.Request.ReadFormAsync();
    if (!int.TryParse(form["StudentId"], out var studentId) ||
        !int.TryParse(form["CourseId"], out var courseId) ||
        !DateTime.TryParse(form["EnrollmentDate"], out var enrollmentDate))
    {
        context.Response.StatusCode = 400; // Bad request
        return;
    }

    // Create enrollment
    var enrollment = new Enrollment
    {
        StudentId = studentId,
        CourseId = courseId,
        EnrollmentDate = enrollmentDate
    };

    enrollments.Add(enrollment);

    // Return success response with created enrollment data
    context.Response.StatusCode = 201; // Created
    context.Response.Headers.Add("Location", $"/enrollments/{enrollments.IndexOf(enrollment)}");
    await context.Response.WriteAsJsonAsync(enrollment);
});

app.Run();

record Enrollment
{
    public int StudentId { get; init; }
    public int CourseId { get; init; }
    public DateTime EnrollmentDate { get; init; }
}