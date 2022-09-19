namespace Bookstore.Application.Interfaces
{
    public interface IStorageService
    {
        string GetUserProfilePath();
        Task<string> GetBookStoragePath(Guid Id);
    }
}
