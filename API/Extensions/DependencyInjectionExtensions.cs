/*
* Digital Excellence Copyright (C) 2020 Brend Smits
* 
* This program is free software: you can redistribute it and/or modify 
* it under the terms of the GNU Lesser General Public License as published 
* by the Free Software Foundation version 3 of the License.
* 
* This program is distributed in the hope that it will be useful, 
* but WITHOUT ANY WARRANTY; without even the implied warranty 
* of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
* See the GNU Lesser General Public License for more details.
* 
* You can find a copy of the GNU Lesser General Public License 
* along with this program, in the LICENSE.md file in the root project directory.
* If not, see https://www.gnu.org/licenses/lgpl-3.0.txt
*/

using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services.Services;
using Services.Sources;

namespace API.Extensions
{
    /// <summary>
    ///     DependencyInjectionExtensions
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        ///     Adds all the services and repositories.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The services.</returns>
        public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
        {
            services.AddScoped<DbContext, ApplicationDbContext>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IHighlightService, HighlightService>();
            services.AddScoped<IHighlightRepository, HighlightRepository>();

            services.AddScoped<ISearchService, SearchService>();

            services.AddScoped<IEmbedService, EmbedService>();
            services.AddScoped<IEmbedRepository, EmbedRepository>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IAuthorizationHandler, ScopeRequirementHandler>();

            services.AddScoped<IRestClientFactory, RestClientFactory>();

            services.AddScoped<ISourceManagerService, SourceManagerService>();
            services.AddScoped<IGitHubSource, GitHubSource>();
            services.AddScoped<IGitLabSource, GitLabSource>();

            return services;
        }
    }
}
