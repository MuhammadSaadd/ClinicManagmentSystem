using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClinicManagmentSystem.API.Business.Services;

public class PrescriptionServices : IPrescriptionServices
{
	private readonly IMongoCollection<Prescription> _prescriptionCollection;

	public PrescriptionServices(IOptions<MongoDBContext> context)
	{
		var mongoClient = new MongoClient(context.Value.MongoDbConnection);
        
        var mongoDb = mongoClient.GetDatabase(context.Value.DatabaseName);
        
        _prescriptionCollection = mongoDb.GetCollection<Prescription>(
                context.Value.CollectionName);
    }

}
