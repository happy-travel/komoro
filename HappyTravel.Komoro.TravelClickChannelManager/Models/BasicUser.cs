using AspNetCore.Authentication.Basic;
using System.Security.Claims;

namespace HappyTravel.Komoro.TravelClickChannelManager.Models;

public class BasicUser : IBasicUser
{
	public BasicUser(string userName, List<Claim>? claims = null)
	{
		UserName = userName;
		Claims = claims ?? new List<Claim>();
	}


	public string UserName { get; }
	public IReadOnlyCollection<Claim> Claims { get; }
}
