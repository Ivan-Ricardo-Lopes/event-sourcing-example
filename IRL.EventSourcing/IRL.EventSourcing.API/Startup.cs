using IRL.EventSourcing.Application.FinanceAccounts.Commands.CreateAccount;
using IRL.EventSourcing.Application.FinanceAccounts.Commands.Deposit;
using IRL.EventSourcing.Application.FinanceAccounts.Commands.Withdraw;
using IRL.EventSourcing.Infra.EntityFramework.DbContext;
using IRL.EventSourcing.Infra.EntityFramework.Repositories;
using IRL.EventSourcing.Infra.MongoDb.Connection;
using IRL.EventSourcing.Infra.MongoDb.EventStore;
using IRL.EventSourcing.Infra.Repositories;
using IRL.EventSourcing.Infra.Stream;
using IRL.EventSourcing.Infra.Stream.Kafka;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace IRL.EventSourcing.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:SqlServer"));

            services.AddMediatR(AppDomain.CurrentDomain.Load("IRL.EventSourcing.API"));
            services.AddMediatR(AppDomain.CurrentDomain.Load("IRL.EventSourcing.Application"));

            services.AddSingleton<IMongoConnectionFactory>(new MongoConnectionFactory(
                Configuration.GetConnectionString("Mongo"),
                Configuration.GetSection("MongoDbName").Value));

            services.AddScoped<IEventStore, MongoEventStoreRepository>();
            services.AddScoped<IEventStream, KafkaProducer>();
            services.AddScoped<IFinanceAccountCodeRepository, FinanceAccountCodeRepositoryEF>();
            services.AddScoped<IFinanceAccountRepository, FinanceAccountRepositoryEF>();

            services.AddScoped<CreateAccountValidator>();
            services.AddScoped<WithdrawValidator>();
            services.AddScoped<DepositValidator>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IRL.EventSourcing.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IRL.EventSourcing.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}