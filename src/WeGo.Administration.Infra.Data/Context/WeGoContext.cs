using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeGo.Administration.Domain.Interfaces.Context;

namespace WeGo.Administration.Infra.Data.Context
{
    public class WeGoContext : IWeGoContext
    {
        private readonly List<Func<Task>> commands;
        private readonly IConfiguration configuration;

        /// <inheritdoc/>
        public WeGoContext(IConfiguration configuration)
        {
            this.configuration = configuration;

            commands = new List<Func<Task>>();
        }

        /// <inheritdoc/>
        public MongoClient MongoClient { get; set; }

        /// <inheritdoc/>
        public IClientSessionHandle Session { get; set; }

        /// <inheritdoc/>
        private IMongoDatabase Database { get; set; }

        /// <inheritdoc/>
        public void AddCommand(Func<Task> func)
        {
            commands.Add(func);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();
            return Database.GetCollection<T>(name);
        }

        /// <inheritdoc/>
        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return commands.Count;
        }

        /// <inheritdoc/>
        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            // Configure mongo (You can inject the config, just to simplify)
            MongoClient = new MongoClient(configuration["MongoConnection:ConnectionString"]);

            Database = MongoClient.GetDatabase(configuration["MongoConnection:Database"]);
        }
    }
}