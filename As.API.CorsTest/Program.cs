var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options => {

	options.AddPolicy(name: "MyCorsPolicy", policy => {

		policy.AllowAnyOrigin(); //allows requests from any origin
		policy.WithOrigins("http://google.com"); //requests from specific origins. specify one or more origins as arguments

		policy.AllowAnyHeader(); //allows requests with any header
		policy.WithHeaders(); //allows requests with specific headers. specify one or more headers as arguments to this method

		policy.AllowAnyMethod(); //allows requests with any HTTP method (e.g., GET, POST, PUT, DELETE).

		policy.WithMethods("Get", "Put");  //equests with specific HTTP methods. You can specify one or more methods as arguments to this method.
	});

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("MyCorsPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
