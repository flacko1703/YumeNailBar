namespace YumeNailBar.Infrastructure;

public class DbInitializer
{
    public static void Initialize(RegistrationInfoDbContext registrationInfoDbContext)
    {
        registrationInfoDbContext.Database.EnsureCreated();
    }
}