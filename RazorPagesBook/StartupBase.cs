namespace RazorPagesBook
{
    public class StartupBase
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<RazorPagesBookContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RazorPagesBookContext")));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Books/Index", "");
            });
        }
    }
}