namespace PRM392_API.Repositories.Interface
{
    public interface IClassRepository
    {
        Task<int[]> GetUserIdsByClassIdAsync(int classId);
    }
}
