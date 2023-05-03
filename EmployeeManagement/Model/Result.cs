namespace EmployeeManagement.Model
{
    public class Result
    {
        public bool Success { get; set; } = false;
        public InternalEmployee Employee { get; set; }
    }
}