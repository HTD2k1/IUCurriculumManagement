using CurriculumService.Models;
using CurriculumService.Services.Interfaces;
using Microsoft.AspNetCore.Routing.Tree;

namespace CurriculumService.Services
{
    public class SemesterCurriculumVerifierService: IVerifierService
    {
        public void Verify()
        {
            throw new NotImplementedException();
        }

        public bool ValidateNewCurriculum()
        {
            return true;
        }
    }
}
    