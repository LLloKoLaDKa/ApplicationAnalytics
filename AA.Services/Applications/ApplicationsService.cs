using AA.Domain.Applications;
using AA.Domain.Results;
using AA.EntitiesCore.Repositories.Applications;
using System;

namespace AA.Services.Applications
{
    public class ApplicationsService
    {
        private readonly ApplicationsRepository _applicationsRepository;

        public ApplicationsService()
        {
            _applicationsRepository = new();
        }

        public Result SaveApp(ApplicationBlank blank)
        {
            if (blank.Id is null) blank.Id = Guid.NewGuid();
            if (String.IsNullOrWhiteSpace(blank.Name)) return Result.Fail("Укажите название приложения");

            _applicationsRepository.SaveApp(blank);

            return Result.Success();
        }

        public Int32 GetCountForUser(Guid userId)
        {
            return _applicationsRepository.GetCountForUser(userId);
        }

        public Application[] GetApplications(Guid userId)
        {
            return _applicationsRepository.GetApplications(userId);
        }

        public Result DeleteApp(Guid applicationId)
        {
            _applicationsRepository.DeleteApp(applicationId);
            return Result.Success();
        }
    }
}
