using KursiWebUI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace KursiWebUI.Pages
{
    [Authorize]
    public partial class FaqjaMbyllur : ComponentBase
    {
        [Inject]
        private IStudentService _studentService { get; set; }
        public string Tekst { get; set; } = "Tungat arjan";

        IQueryable<StudentDTO> people;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();


            var students = await _studentService.GetStudentetAuthAsync();
            people = students.AsQueryable();
        }



    }
}
