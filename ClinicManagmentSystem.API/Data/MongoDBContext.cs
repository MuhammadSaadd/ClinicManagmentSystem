﻿namespace ClinicManagmentSystem.API.Data;

public class MongoDBContext
{
    public string MongoDbConnection { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}
