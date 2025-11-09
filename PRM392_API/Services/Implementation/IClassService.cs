namespace PRM392_API.Services.Implementation
{
    public interface IClassService
    {
        Task<int[]> GetUserIdsByClassIdAsync(int classId);
    }
}
