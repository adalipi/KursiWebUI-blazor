namespace KursiWebUI.Data
{
    public class StudentService : IStudentService
    {
        private readonly IApiService _apiService;

        public StudentService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<List<StudentDTO>> GetStudentsAsync() =>
            await _apiService.HttpGET<List<StudentDTO>>("Studenti/MerrStudentet");

        public async Task<List<StudentDTO>> GetStudentetAuthAsync() =>
            await _apiService.HttpGET<List<StudentDTO>>("Studenti/MerrStudentetAuth");
        
    }
}
