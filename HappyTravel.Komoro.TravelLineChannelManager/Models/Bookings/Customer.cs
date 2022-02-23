namespace HappyTravel.Komoro.TravelLineChannelManager.Models.Bookings;

/// <summary>
/// Details of the person booking the room
/// </summary>
internal record Customer
{
    /// <summary>
    /// Customer name
    /// </summary>
    public string FirstName { get; init; } = string.Empty;

    /// <summary>
    /// Customer's last name
    /// </summary>
    public string LastName { get; init; } = string.Empty;

    /// <summary>
    /// Customer's patronymic
    /// </summary>
    public string MiddleName { get; init; } = string.Empty;

    /// <summary>
    /// Customer email address
    /// </summary>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// Customer phone
    /// </summary>
    public string Phone { get; init; } = string.Empty;
}
