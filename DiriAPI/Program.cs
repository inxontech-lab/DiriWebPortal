using DataAccess.Repository;
using DiriAPI.Auth;
using DiriAPI.Services;
using DiriAPI.Services.ConferenceSchemaService;
using DiriAPI.Services.Homepage;
using DiriAPI.Services.JournalSchemaService;
using DiriAPI.Services.MasterSchemaServices;
using DiriAPI.Services.PublicationSchema;
using Domain.DBModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DiriWebPortalContext>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<IDiriContextDataRepo, DiriContextDataRepo>();
builder.Services.AddScoped<HomePageService>();
builder.Services.AddScoped<HomePageSchemaService>();
builder.Services.AddScoped<ContactU>();
builder.Services.AddScoped<MasterInfoService>();
builder.Services.AddScoped<AboutUsPageService>();
builder.Services.AddScoped<ManagingTrusteeDataService>();
builder.Services.AddScoped<CountryServices>();
builder.Services.AddScoped<UniversityInstituteServices>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<OccupationalDesignationService>();
builder.Services.AddScoped<ExecCommitteeDesignationService>();
builder.Services.AddScoped<ConferencePlatformService>();
builder.Services.AddScoped<ConfCommitteeDesignationService>();
builder.Services.AddScoped<ConferenceMasterService>();
builder.Services.AddScoped<PublicationsSchemaService>();
builder.Services.AddScoped<JournalSchemaService>();
builder.Services.AddScoped<RoleMasterService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<UserRolesService>();
builder.Services.AddScoped<UserWithRolesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<ApiKeyAuthMiddleware>();
app.MapControllers();
app.Run();
