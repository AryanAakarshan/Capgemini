using System;

class Tuples
{
    public static (bool IsValid, string Message) ValidateUser(string username)
    {
        if (string.IsNullOrEmpty(username))
            return (false, "Username is required");

        return (true, "Valid user");
    }
}
