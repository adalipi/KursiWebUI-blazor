namespace KursiWebUI.Data
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetStudentsAsync();

        Task<List<StudentDTO>> GetStudentetAuthAsync();
    }
}
