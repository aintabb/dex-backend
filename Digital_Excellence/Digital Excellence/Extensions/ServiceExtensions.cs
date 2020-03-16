﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Models.Defaults;

namespace Digital_Excellence.Extensions
{
	/// <summary>
	/// ServicesExtensions
	/// </summary>
	public static class ServicesExtensions
	{
		/// <summary>
		/// Adds the policies.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns></returns>
		public static IServiceCollection AddPolicies(this IServiceCollection services)
		{
			services.Configure<AuthorizationOptions>(o =>
			{
				FieldInfo[] fields = typeof(Defaults.Scopes).GetFields();

				foreach (FieldInfo field in fields)
				{
					o.AddPolicy(field.Name, policy =>
					{
						policy.RequireClaim("scope", field.GetRawConstantValue().ToString().Split(' '));
					});
				}
			});

			return services;
		}
	}
}