namespace PRM392_API.ViewModels.ClassDetails
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public ClassMemberViewModel Leader { get; set; }
        public List<ClassMemberViewModel> Members { get; set; }
    }
}
