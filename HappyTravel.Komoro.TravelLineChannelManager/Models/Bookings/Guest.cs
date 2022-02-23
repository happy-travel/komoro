namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Guest data
/// </summary>
internal record Guest
{
    /// <summary>
    /// Guest name
    /// </summary>
    public string FirstName { get; init; } = string.Empty;

    /// <summary>
    /// Guest's last name
    /// </summary>
    public string LastName { get; init; } = string.Empty;

    /// <summary>
    /// Guest's patronymic
    /// </summary>
    public string MiddleName { get; init; } = string.Empty;

    /// <summary>
    /// Guest email address
    /// </summary>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// Guest phone
    /// </summary>
    public string Phone { get; init; } = string.Empty;

    /// <summary>
    /// Characteristics of the guest (adult / child). Accepted values: true, false
    /// </summary>
    public bool IsChild { get; init; }

    /// <summary>
    /// Child's age. Passed if IsChild: true.
    /// </summary>
    public int? Age { get; init; }
}
