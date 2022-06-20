﻿using System.Security.Cryptography;
using System.Text;
using Core.Models;

namespace Core.Helper;

public class PasswordService
{
    public static Password CreateNewPassword(string clearTextPassword)
    {
        var password = new Password();
        using var hmac = new HMACSHA512();
        password.PasswordSalt = hmac.Key;
        password.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(clearTextPassword));
        return password;
    }

    public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
    }

    public static string CreateRandomPassword()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrst+$?!&0123456789";
        return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}