using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealTimeChatAppWithSignalR.DatabaseContx;
using RealTimeChatAppWithSignalR.Entities;
using RealTimeChatAppWithSignalR.HubContent;

var builder = WebApplication.CreateBuilder(args);



//DatabaseContext configuration added here!
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var datas = builder.Configuration;
    var ConnectionString = datas.GetConnectionString("Database");
    options.UseSqlite(ConnectionString);
});

//Identity Configuration added here!
builder.Services.AddIdentity<ApplicationUser ,IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();

//SignalR Configuration added here!
builder.Services.AddSignalR();

//Cors Configurations!

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        //Burda front kýsmýnýn portunu vermeliyiz!
        policy.WithOrigins("https://localhost:7022").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cors güvenlik baðlantýsýný ekleyelim! - SADECE WEB TARAYICILARI ÝÇÝN!
app.UseCors();

//added here!
app.MapHub<TypeSafeMessage>("/chatapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
