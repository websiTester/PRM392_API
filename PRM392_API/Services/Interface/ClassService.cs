using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Implementation;

namespace PRM392_API.Services.Interface
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<int[]> GetUserIdsByClassIdAsync(int classId)
        {
            return await _classRepository.GetUserIdsByClassIdAsync(classId);
        }
    }
}
