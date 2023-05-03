using BOCApplication.Data;
using BOCApplication.Repositoy.CreateTableService;
using BOCApplication.Repositoy.DataTabService;
using BOCApplication.Repositoy.FieldsService;
using BOCApplication.Repositoy.FormBuilderService;
using BOCApplication.Repositoy.ProcessService;
using BOCApplication.Repositoy.SectionsService;
using BOCApplication.Repositoy.SubTabsService;
using BOCApplication.Repositoy.TabsService;
using BOCApplication.Repositoy.Tokenhandler;
using BOCApplication.Repositoy.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TokenHandler = BOCApplication.Repositoy.Tokenhandler.TokenHandler;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository......

builder.Services.AddScoped<IProcessRepository, ProcessRepository>();
builder.Services.AddScoped<ITabsRepository, TabsRepository>();
builder.Services.AddScoped<ISubTabsRepository, SubTabsRepository>();
builder.Services.AddScoped<IFieldsRepository, FieldsRepository>();
builder.Services.AddScoped<IFormBuilderRepository, FormBuilderRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<IDataTabRepository, DataTabRepository>();
builder.Services.AddScoped<ICreateTableRepository, CreateTableRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenhandler, TokenHandler>();

//Jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
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

app.Run();
