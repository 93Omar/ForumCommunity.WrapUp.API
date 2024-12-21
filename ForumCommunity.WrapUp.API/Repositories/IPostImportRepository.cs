using ForumCommunity.WrapUp.API.Models.Database;

namespace ForumCommunity.WrapUp.API.Repositories
{
    public interface IPostImportRepository
    {
        public Task<int> InitImportAsync(int userId, int totalPages, int totalRecords, ImportStatus importStatus = ImportStatus.InProgress);
        public Task UpdateImportStatusAsync(int importId, int lastProcessedPage);
        public Task FinishImportAsync(int importId, int lastProcessedPage);
    }
}
