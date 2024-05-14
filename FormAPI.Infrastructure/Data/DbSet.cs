using FormAPI.Models.Entities;
using Microsoft.Azure.Cosmos;
using Serilog;

namespace FormAPI.Infrastructure.Data
{
	public class DbSet<T> where T : class
	{
		private readonly DataContext _db;
		private readonly Container container;
		public Container Container { get; set; }
	
		public DbSet()
		{
		
		}

	

		public async Task<T> GetItem(string id)
		{
			var items = await GetItemCategory(id, "id");
			return items.FirstOrDefault();
		}

		public async Task<List<T>> GetItemCategory(string categoryId, string categoryName)
		{
			var containerName = typeof(T).Name;
			var items = await GetAllItems($"SELECT * FROM {containerName} f WHERE f.{categoryName}=\"{categoryId}\"");
			return items;
		}

		public async Task<List<T>> GetAllItems(string? query = "SELECT * FROM c")
		{
			
			var queryDefinition = new QueryDefinition(query);
			var items = new List<T>();
			try
			{
				using (var iterator = Container.GetItemQueryIterator<T>(queryDefinition))
				{
					while (iterator.HasMoreResults)
					{
						FeedResponse<T> response = await iterator.ReadNextAsync();
						items.AddRange(response);
					}
				}
			}
			catch (CosmosException ex)
			{
				Log.Fatal(ex, ex.Message);
			
			}

			return items;
		}

		public async Task<bool> DeleteOneItem(string id)
		{
			var Entity = await GetItem(id);
			if (Entity == null) throw new Exception("Item to be deleted not found");
			var baseObject = Entity as BaseEntity;
			var partitionKeyValue = baseObject.partitionKeyPath;
			PartitionKey partitionKey = new PartitionKey(partitionKeyValue);

			try
			{
				await Container.DeleteItemAsync<dynamic>(baseObject.id, partitionKey);

				return true;
			}
			catch (CosmosException ex)
			{
				Log.Fatal(ex, ex.Message);

				return false;
			}
		}
		public async Task<bool> UpsertItem(T Entity)
		{

			var baseObject = Entity as BaseEntity;
			var partitionKeyValue = baseObject.partitionKeyPath;


			var partitionKey = new PartitionKey(partitionKeyValue);
			ItemResponse<T> item;
			try
			{
				item = await Container.UpsertItemAsync<T>(Entity, partitionKey);
				return true;
			}
			catch (CosmosException ex)
			{
				Log.Fatal(ex, ex.Message);

				return false;
			}
		}



	}

}
