namespace Shopping.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient("ShoppingAppClient", client =>
            {
                // we need to read the api base address from configuration as the port will change when running through docker.
                // client.BaseAddress = new Uri("http://localhost:5000/");

                client.BaseAddress = new Uri(builder.Configuration["ShoppingApiUrl"]!);
                //client.BaseAddress = new Uri("http://shopping_api:8001/");
            });

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
