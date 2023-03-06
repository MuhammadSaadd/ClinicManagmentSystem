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


    public async Task<List<Prescription>> GetAsync() =>
        await _prescriptionCollection.Find(_ => true).ToListAsync();

    public async Task<Prescription?> GetAsync(string id) =>
        await _prescriptionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Prescription prescription) =>
        await _prescriptionCollection.InsertOneAsync(prescription);

    public async Task UpdateAsync(string id, Prescription prescription) =>
        await _prescriptionCollection.ReplaceOneAsync(x => x.Id == id, prescription);

    public async Task DeleteAsync(string id) =>
        await _prescriptionCollection.DeleteOneAsync(x => x.Id == id);
}
