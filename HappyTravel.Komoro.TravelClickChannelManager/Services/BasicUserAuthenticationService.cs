using AspNetCore.Authentication.Basic;
using HappyTravel.Komoro.Common.Infrastructure.Options;
using HappyTravel.Komoro.TravelClickChannelManager.Models;
using Microsoft.Extensions.Options;

namespace HappyTravel.Komoro.TravelClickChannelManager.Services;

public class BasicUserAuthenticationService : IBasicUserAuthenticationService
{
	public BasicUserAuthenticationService(IOptions<TravelClickOptions> options)
	{
		_options = options.Value;
	}


	public async Task<IBasicUser?> AuthenticateAsync(string username, string password)
	{
		var isValid = (username == _options.Login && password == _options.Password);

		return isValid ? new BasicUser(username) : null;
	}


	private readonly TravelClickOptions _options;
}
