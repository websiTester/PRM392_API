using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.RequestModel;
using PRM392_API.Services.Interface;
using PRM392_API.ViewModels.ClassDetails;

namespace PRM392_API.Services.Implementation
{
    public class ClassDetailService : IClassDetailService
    {
        private readonly IClassDetailRepository _classRepo;
        private readonly IAssignmentRepository _assignmentRepo;
        private readonly IGroupRepository _groupRepo;

        public ClassDetailService(IClassDetailRepository classRepo, IAssignmentRepository assignmentRepo, IGroupRepository groupRepo)
        {
            _classRepo = classRepo;
            _assignmentRepo = assignmentRepo;
            _groupRepo = groupRepo;
        }

        private ClassMemberViewModel MapUserToMemberModel(User user)
        {
            if (user == null) return null;
            return new ClassMemberViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Avatar = user.Avatar,
                RoleId = user.RoleId ?? 2
            };
        }
        public async Task<bool> AddStudentToGroupAsync(int groupId, int studentId)
        {
            var group = await _groupRepo.GetGroupByIdAsync(groupId);
            if (group == null) return false;

            var existingGroup = await _groupRepo.GetStudentGroupInClassAsync(group.ClassId ?? 0, studentId);
            if (existingGroup != null)
            {
                return false;
            }

            await _groupRepo.AddStudentToGroupAsync(groupId, studentId);
            return true;
        }

        public async Task<AssignmentViewModel> CreateAssignmentAsync(int classId, CreateAssignmentRequest request)
        {
            var newAssignment = new Assignment
            {
                ClassId = classId,
                Title = request.Title,
                Description = request.Description,
                Deadline = request.Deadline,
                IsGroupAssignment = request.IsGroupAssignment
            };

            var created = await _assignmentRepo.CreateAssignmentAsync(newAssignment);

            return new AssignmentViewModel
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
                Deadline = created.Deadline,
                IsGroupAssignment = created.IsGroupAssignment ?? false
            };
        }

        public async Task<GroupViewModel> CreateGroupAsync(int classId, CreateGroupRequest request)
        {
            var newGroup = new Group
            {
                ClassId = classId,
                GroupName = request.GroupName
            };

            var created = await _groupRepo.CreateGroupAsync(newGroup);

            return new GroupViewModel
            {
                GroupId = created.GroupId,
                GroupName = created.GroupName,
                Leader = null,
                Members = new List<ClassMemberViewModel>()
            };
        }

        public async Task<bool> DeleteAssignmentAsync(int assignmentId)
        {
            await _assignmentRepo.DeleteAssignmentAsync(assignmentId);
            return true;
        }

        public async Task<bool> DeleteGroupAsync(int groupId)
        {
            await _groupRepo.DeleteGroupAsync(groupId);
            return true;
        }

        public async Task<ClassDetailStudentViewModel> GetClassDetailForStudentAsync(int classId, int studentId)
        {
            var aClass = await _classRepo.GetClassByIdAsync(classId);
            if (aClass == null) return null;

            var assignments = await _assignmentRepo.GetAssignmentsByClassIdAsync(classId);

            var groups = await _groupRepo.GetGroupsByClassIdWithMembersAsync(classId);

            var currentGroup = await _groupRepo.GetStudentGroupInClassAsync(classId, studentId);

            var vm = new ClassDetailStudentViewModel
            {
                ClassId = aClass.ClassId,
                ClassName = aClass.ClassName,
                ClassCode = aClass.ClassCode,
                Teacher = MapUserToMemberModel(aClass.Teacher),
                CurrentUserGroupId = currentGroup?.GroupId,

                Assignments = assignments.Select(a => new AssignmentViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Deadline = a.Deadline,
                    IsGroupAssignment = a.IsGroupAssignment ?? false
                }).ToList(),

                Groups = groups.Select(g => new GroupViewModel
                {
                    GroupId = g.GroupId,
                    GroupName = g.GroupName,
                    Leader = MapUserToMemberModel(g.Leader),
                    Members = g.StudentGroups.Select(sg => MapUserToMemberModel(sg.Student)).ToList()
                }).ToList()
            };

            return vm;
        }

        public async Task<ClassDetailTeacherViewModel> GetClassDetailForTeacherAsync(int classId, int teacherId)
        {
            var aClass = await _classRepo.GetClassByIdAsync(classId);
            if (aClass == null) return null;

            var assignments = await _assignmentRepo.GetAssignmentsByClassIdAsync(classId);

            var groups = await _groupRepo.GetGroupsByClassIdWithMembersAsync(classId);

            var students = await _classRepo.GetStudentsByClassIdAsync(classId);

            var vm = new ClassDetailTeacherViewModel
            {
                ClassId = aClass.ClassId,
                ClassName = aClass.ClassName,
                ClassCode = aClass.ClassCode,
                Teacher = MapUserToMemberModel(aClass.Teacher),

                AllStudents = students.Select(MapUserToMemberModel).ToList(),

                Assignments = assignments.Select(a => new AssignmentViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Deadline = a.Deadline,
                    IsGroupAssignment = a.IsGroupAssignment ?? false
                }).ToList(),

                Groups = groups.Select(g => new GroupViewModel
                {
                    GroupId = g.GroupId,
                    GroupName = g.GroupName,
                    Leader = MapUserToMemberModel(g.Leader),
                    Members = g.StudentGroups.Select(sg => MapUserToMemberModel(sg.Student)).ToList()
                }).ToList()
            };

            return vm;
        }

        public async Task<bool> IsUserTeacherOfClassAsync(int classId, int userId)
        {
            return await _classRepo.IsUserTeacherOfClassAsync(classId, userId);
        }

        public async Task<bool> JoinGroupAsync(int groupId, int studentId)
        {
            return await AddStudentToGroupAsync(groupId, studentId);
        }

        public async Task<bool> LeaveGroupAsync(int groupId, int studentId)
        {
            return await RemoveStudentFromGroupAsync(groupId, studentId);
        }

        public async Task<bool> RemoveStudentFromGroupAsync(int groupId, int studentId)
        {
            await _groupRepo.RemoveStudentFromGroupAsync(groupId, studentId);
            return true;
        }

        public async Task<bool> UpdateAssignmentAsync(int assignmentId, CreateAssignmentRequest request)
        {
            var assignment = await _assignmentRepo.GetAssignmentByIdAsync(assignmentId);
            if (assignment == null) return false;

            assignment.Title = request.Title;
            assignment.Description = request.Description;
            assignment.Deadline = request.Deadline;
            assignment.IsGroupAssignment = request.IsGroupAssignment;

            await _assignmentRepo.UpdateAssignmentAsync(assignment);
            return true;
        }
    }
}
