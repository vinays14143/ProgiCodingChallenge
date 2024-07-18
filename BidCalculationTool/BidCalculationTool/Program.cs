using BidCalculationTool.Interface;
using BidCalculationTool.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //Dependency Injection for Total Bill Calculation and service fee calcualtio
        builder.Services.AddTransient<IBidCalculationTool, BidCalculationTool.Services.BidCalculationTool>();
        builder.Services.AddTransient<ICalculateTotalFee, CalculateTotalFee>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //TO fix Cors error origin.
        //Add the URL of your Vue.js app
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:8080") 
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors("AllowSpecificOrigin");

        app.Run();
    }
}