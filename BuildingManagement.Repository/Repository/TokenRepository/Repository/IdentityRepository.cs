﻿using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BuildingManagement.Entity;

namespace BuildingManagement.Repository.Repository.TokenRepository.Repository;
public class IdentityRepository(
UserManager<User> userManager,
RoleManager<UserRole> roleManager,
SignInManager<User> signInManager) : IIdentityRepository
{
    public UserManager<User> UserManager { get; set; } = userManager;
    public RoleManager<UserRole> RoleManager { get; set; } = roleManager;
    public SignInManager<User> SignInManager { get; set; } = signInManager;
    public Task<IdentityResult> AddClaimAsync(User user, Claim claim)
    {
        return userManager.AddClaimAsync(user,
        claim);
    }
    public Task<IdentityResult> CreateUser(User user, string password)
    {

        return userManager.CreateAsync(user, password);
    }
    public async Task<bool> RoleExistsAsync(UserRole userRole)
    {
        return await roleManager.RoleExistsAsync(userRole.Name!);
    }
    public async Task<User?> FindByIdAsync(string userId)
    {
        return await userManager.FindByIdAsync(userId);
    }
    public async Task<IdentityResult> AddToRoleAsync(User user, string userRolName)
    {
        return await userManager.AddToRoleAsync(user, userRolName);
    }
    public async Task<IdentityResult> CreateRoleAsync(UserRole userRole)
    {
        return await roleManager.CreateAsync(userRole);
    }
    public async Task<IdentityResult> DeleteUserAsync(string email)
    {
        var user = await UserManager.FindByEmailAsync(email);

        if(user != null) return await UserManager.DeleteAsync(user);

        return IdentityResult.Failed(new IdentityError { Description = "User not found." });
    }
    public async Task<IdentityResult> UpdateUserAsync(User user)
    {
        var existingUser = await UserManager.FindByEmailAsync(user.Email!);

        if (existingUser == null) return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        existingUser.UserName = user.UserName;
        existingUser.Email = user.Email;
        existingUser.Name = user.Name;
        existingUser.Surname = user.Surname;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.TcNo = user.TcNo;

        return await UserManager.UpdateAsync(existingUser);
    }
}
