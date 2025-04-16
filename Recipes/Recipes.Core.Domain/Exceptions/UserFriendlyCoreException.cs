namespace Recipes.Core.Domain.Exceptions;

[Serializable]
public class UserFriendlyCoreException : CoreException
{
    public UserFriendlyCoreException(string message) : base(message)
    {
    }

    public UserFriendlyCoreException(string message, Exception innerException) : base(message, innerException)
    {
    }
}