using PRM392_API.DTOs.Dashboard;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly PRM392Context _context;
        public DashboardRepository(PRM392Context context)
        {
            _context = context;
        }
        public DashboardViewModel GetDashboard()
        {
            int tTeacher = _context.Users.Where(u => u.RoleId == 1).Count();
            int tStudent = _context.Users.Where(u => u.RoleId ==2).Count();
            int tClass = _context.Classes.Count();
            int tCourse =_context.Courses.Count();
            return new DashboardViewModel
            {
                TotalClasses = tClass,
                TotalStudents = tStudent,
                TotalCourses = tCourse,
                TotalTeachers = tTeacher,
            };
        }

        public UListViewModel GetUserByID(int userid)
        {
            var user = _context.Users.Where( u =>u.UserId == userid).FirstOrDefault();
            return  new UListViewModel
            {
                UserId = user.UserId,
                FullName = $"{user.FirstName} {user.LastName}".Trim(),
                Email = user.Email,
                IsActive = user.isActive,
                Avatar = user.Avatar,
                RoleName = GetRoleName(user.RoleId)
            };
        }

        public List<UListViewModel> GetUserList()
        {
            var users = _context.Users.Where(u => u.RoleId != 3).OrderByDescending(u => u.isActive).ToList();   // query DB trước

            return users
                .Select(u => new UListViewModel
                {
                    UserId = u.UserId,
                    FullName = $"{u.FirstName} {u.LastName}".Trim(),
                    Email = u.Email,
                    IsActive = u.isActive,   // hoặc u.IsActive
                    Avatar = u.Avatar,
                    RoleName = GetRoleName(u.RoleId)
                })
                .ToList();
        }

        public bool UpdateUserStatus(int userid, bool status)
        {
            var user = _context.Users.Where(u => u.UserId == userid).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            user.isActive = status;
            _context.SaveChanges();
            return true;
        }

        private string GetRoleName(int? roleId)
        {
            return roleId switch
            {
                2 => "Giảng viên",
                1 => "Học viên",
                3 => "Admin",
                _ => "Khác"
            };
        }
    }
}
