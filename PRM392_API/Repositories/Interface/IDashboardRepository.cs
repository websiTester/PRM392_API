using PRM392_API.DTOs.Dashboard;

namespace PRM392_API.Repositories.Interface
{
    public interface IDashboardRepository
    {
        DashboardViewModel GetDashboard();
        List<UListViewModel> GetUserList();
        UListViewModel GetUserByID(int userid);
        bool UpdateUserStatus(int userid, bool status);
    }
}
