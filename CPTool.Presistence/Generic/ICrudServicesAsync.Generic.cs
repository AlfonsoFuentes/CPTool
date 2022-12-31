﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

namespace GenericServices
{
    /// <summary>
    /// This is the interface for the async form of CrudServices where you define the DbContext to be used in the CrudServices
    /// Useful if you have multiple DbContext (known as database bounded contexts) 
    /// </summary>
    public interface ICrudServicesAsync<TContext> : ICrudServicesAsync where TContext : DbContext {}
}