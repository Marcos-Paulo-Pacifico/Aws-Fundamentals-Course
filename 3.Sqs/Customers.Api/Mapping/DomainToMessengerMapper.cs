﻿using Customers.Api.Contracts.Messages;
using Customers.Api.Domain;

namespace Customers.Api.Mapping;

public static class DomainToMessengerMapper
{
    public static CustomerCreated ToCustomerCreatedMessage(this Customer customer)
    {
        return new CustomerCreated
        {
            Id = customer.Id,
            Email = customer.Email,
            FullName = customer.FullName,
            DateOfBirth = customer.DateOfBirth,
            GitHubUsername = customer.GitHubUsername
        };
    }
    
    public static CustomerUpdated ToCustomerUpdatedMessage(this Customer customer)
    {
        return new CustomerUpdated
        {
            Id = customer.Id,
            Email = customer.Email,
            FullName = customer.FullName,
            DateOfBirth = customer.DateOfBirth,
            GitHubUsername = customer.GitHubUsername
        };
    }
}