namespace ClinicManagmentSystem.API.Data;

public class MailSettings
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string SenderEmail { get; set; } = string.Empty;
    public string SernderName { get; set; } = string.Empty;
    public string AuthKey { get; set; } = string.Empty;
}
