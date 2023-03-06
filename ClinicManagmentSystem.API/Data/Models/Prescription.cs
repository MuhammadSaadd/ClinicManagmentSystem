using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClinicManagmentSystem.API.Data.Models;

public class Prescription
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public Guid PhysicianId { get; set; }
    public Guid PatientId { get; set; }
    public string Prescriptions { get; set; } = string.Empty;
}
