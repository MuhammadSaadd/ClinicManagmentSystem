namespace ClinicManagmentSystem.API.Enumerations;

public static class AddShiftResult
{
    public enum Results
    {
        Success,
        DoctorNotFound,
        ClinicNotFound,
        ClinicNotAvailable,
        ShiftOverlap,
        UnknownError
    }
}
