using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using ImpulsoTeste.Marcilio.Roles;
using ImpulsoTeste.Marcilio.Roles.Dto;
using System.Collections.Generic;

using ImpulsoTeste.Marcilio.Users;
using ImpulsoTeste.Marcilio.Users.Dto;
using ImpulsoTeste.Marcilio.Authorization.Users;
using ImpulsoTeste.Marcilio.Authorization.Roles;

namespace ImpulsoTeste.Marcilio.Tests.Roles
{
    public class RolesAppService_Tests : MarcilioTestBase
    {
        private readonly IRoleAppService _roleAppService;
        private readonly IUserAppService _userAppService;

        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;

        public RolesAppService_Tests()
        {
            _roleAppService = Resolve<IRoleAppService>();
            _userAppService = Resolve<IUserAppService>();
            _roleManager = Resolve<RoleManager>();
            _userManager = Resolve<UserManager>();
        }



        /// <summary>
        /// Desafio tecnico 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetRoles_Test()
        {
            // Act
            var output = await _roleAppService.GetAllAsync(new PagedRoleResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        /// <summary>
        /// Desafio tecnico 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateRole_Test()
        {


            // Act
            var permissions = new List<string>();
            permissions.Add("permission1");
            permissions.Add("permission2");

            await _roleAppService.CreateAsync(

                    new CreateRoleDto
                    {
                        Description = "Master Operator",
                        DisplayName = "Operators",
                        GrantedPermissions = permissions,
                        Name = "Operators",
                        NormalizedName = "System Operators"

                    });

            await UsingDbContextAsync(async context =>

            {
                var operatorRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Operators");
                operatorRole.ShouldNotBeNull();
            });
        }

        /// <summary>
        /// Desafio tecnico 
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task UpdateRole_Test()
        {

            // Act
            await UsingDbContextAsync(async context =>
            {
                var permissions = new List<string>();
                permissions.Add("permission1");
                permissions.Add("permission2");

                var role = await _roleAppService.CreateAsync(

                    new CreateRoleDto
                    {
                        Description = "Master Operator 2",
                        DisplayName = "Operators_2",
                        GrantedPermissions = permissions,
                        Name = "Operators_2",
                        NormalizedName = "System Operators 2"

                    });




            });

            await UsingDbContextAsync(async context =>
            {

                var operatorRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Operators_2");
                var role2 = new RoleDto();

                var permissions2 = new List<string>();
                permissions2.Add("permission3");
                permissions2.Add("permission4");

                role2.Description = operatorRole.Description;
                role2.DisplayName = operatorRole.DisplayName;
                role2.Name = "Operator Update";
                role2.NormalizedName = "Systema Operators Update";
                role2.GrantedPermissions = permissions2;
                role2.Id = operatorRole.Id;

                await _roleAppService.UpdateAsync(role2);


            });


            await UsingDbContextAsync(async context =>

            {

                var operatorRoleUpdate = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Operator Update");
                operatorRoleUpdate.ShouldNotBeNull();
            });


        }



        /// <summary>
        /// Desafio Tecnico
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteRole_Test()
        {


            // Act
            await UsingDbContextAsync(async context =>
            {
                var permissions = new List<string>();
                permissions.Add("permission1");
                permissions.Add("permission2");

                var role = await _roleAppService.CreateAsync(

                    new CreateRoleDto
                    {
                        Description = "Master Operator 2",
                        DisplayName = "Operators_2",
                        GrantedPermissions = permissions,
                        Name = "Operators_2",
                        NormalizedName = "System Operators 2"

                    });

                await _roleAppService.DeleteAsync(role);


            });


            await UsingDbContextAsync(async context =>

            {
                var operatorRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Operators_2");
                operatorRole.ShouldNotBeNull();
            });


        }

        /// <summary>
        /// Desafio Tecnico
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Be_Remove_Users_From_Role()
        {
            await _userAppService.CreateAsync(
              new CreateUserDto
              {
                  EmailAddress = "john@volosoft.com",
                  IsActive = true,
                  Name = "John",
                  Surname = "Nash",
                  Password = "123qwe",
                  UserName = "john.nash"

              });


            // Act
            var permissions = new List<string>();
            permissions.Add("permission1");
            permissions.Add("permission2");

            await _roleAppService.CreateAsync(

                    new CreateRoleDto
                    {
                        Description = "Master Operator",
                        DisplayName = "Operators",
                        GrantedPermissions = permissions,
                        Name = "Operators",
                        NormalizedName = "Operators"

                    });
            var user = await _userManager.FindByEmailAsync("john@volosoft.com");

            await _userManager.AddToRoleAsync(user, "Operators");

            await UsingDbContextAsync(async context =>
            {
               

                var role = _roleManager.GetRoleByName("Operators");
                var users = await _userManager.GetUsersInRoleAsync("Operators");


                foreach (var userSearch in users)
                {
                    await _userManager.RemoveFromRoleAsync(userSearch, role.NormalizedName);
                };


                var usersAfter = await _userManager.GetUsersInRoleAsync("Operators");

                bool ret = false;

                foreach (var userSearchAfter in usersAfter)
                {
                    if (userSearchAfter.Name == "John") ret = true;

                };

                Assert.False(ret);

            });


        }

    }



}
