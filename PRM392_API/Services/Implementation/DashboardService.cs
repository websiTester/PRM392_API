using PRM392_API.DTOs.Dashboard;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;

namespace PRM392_API.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;
        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public DashboardViewModel GetDashboard()
        {
            return _repository.GetDashboard();
        }

        public UListViewModel GetUserByID(int userid)
        {
            return _repository.GetUserByID(userid);
        }

        public List<UListViewModel> GetUserList()
        {
            return _repository.GetUserList();
        }

        public bool UpdateUserStatus(int userid, bool status)
        {
           return _repository.UpdateUserStatus(userid, status);
        }
    }
}
