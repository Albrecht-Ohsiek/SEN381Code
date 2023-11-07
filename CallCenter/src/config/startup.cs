using CallCenter.Repository;
using CallCenter.Services;

namespace CallCenter.Config
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            services.AddSingleton(configuration);

            DatabaseConfig databaseConfig = new DatabaseConfig();

            configuration.Bind("Database", databaseConfig);
            services.AddSingleton(databaseConfig);
            services.AddSingleton<DatabaseServices>();
            services.AddSingleton<LoginServices>();

            services.AddTransient<ICallRepository, CallRepository>();
            services.AddTransient<ICallReportRepository, CallReportRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IContractRepository, ContractRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeLoginRepository, EmployeeLoginRepository>();
            services.AddTransient<IRequestLogRepository, RequestLogRepository>();
            services.AddTransient<ITechnicianRepository, TechnicianRepository>();
            services.AddTransient<IWorkRepository, WorkRepository>();
            services.AddTransient<IWorkRequestRepository, WorkRequestRepository>();

            services.AddLogging();
            services.AddControllersWithViews();

            services.AddCors(options =>
            {
                options.AddPolicy("All Access", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}

