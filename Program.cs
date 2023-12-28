namespace ProducManagementWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Configure CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                policy =>
                {
                    policy.AllowAnyOrigin()// React uygulamanızın çalıştığı adres
    .AllowAnyHeader()
    .AllowAnyMethod();
                });
            });

            // Add Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Use CORS policy
            app.UseCors("MyAllowSpecificOrigins");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
