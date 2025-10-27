namespace PRM392_API.RequestModel
{
	//Request model from Android client when update profile
	public class LoginResult
	{
		public int? Id { get; set; }
		public string? Username { get; set; }
		public string? Email	 { get; set; }
		public string? Avatar { get; set; }
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }

	}
}
