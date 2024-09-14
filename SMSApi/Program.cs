using SMSApi.Application.Interfaces;
using SMSApi.Application.Services;
using SMSApi.Domain.Interfaces;
using SMSApi.Domain.Services;
using SMSApi.Infrastructure.Providers;
using SMSApi.Infrastructure.Factories;

var builder = WebApplication.CreateBuilder(args);

var smsProviderPercentages = new Dictionary<string, double>();
builder.Configuration.GetSection("SmsProviderPercentages").Bind(smsProviderPercentages);

builder.Services.AddHttpClient<ISmsProvider, MagtiSmsProvider>();
builder.Services.AddHttpClient<ISmsProvider, GeocellSmsProvider>();
builder.Services.AddHttpClient<ISmsProvider, TwilioSmsProvider>();

builder.Services.AddSingleton<RandomProviderSelector>();
builder.Services.AddSingleton<PercentProviderSelector>(sp =>
    new PercentProviderSelector(smsProviderPercentages)  
);


builder.Services.AddSingleton<ISmsProviderSelectorFactory, SmsProviderSelectorFactory>();

builder.Services.AddScoped<SMSApi.Domain.Services.SmsService>();

builder.Services.AddScoped<ISmsService, SMSApi.Application.Services.SmsService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMS API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
