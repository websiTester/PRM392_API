using PRM392_API.DTOs.Dashboard;

namespace PRM392_API.Services.Interface
{
    public interface IDashboardService
    {
        DashboardViewModel GetDashboard();
        List<UListViewModel> GetUserList();
        UListViewModel GetUserByID(int userid);
        bool UpdateUserStatus(int userid, bool status);
    }
}
