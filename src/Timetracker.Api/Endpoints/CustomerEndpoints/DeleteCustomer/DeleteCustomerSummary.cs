// <copyright file="DeleteCustomerSummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteCustomer;

public class DeleteCustomerSummary : Summary<DeleteCustomerEndpoint>
{
    public DeleteCustomerSummary()
    {
        Summary = "Delete a customer";
        Description = "Use this endpoint to delete a customer";
        ExampleRequest = new DeleteCustomerRequest(Guid.NewGuid());
        Response(200, "Customer deleted");
        Response(400, "Bad request");
        Response(401, "Unauthorized");
        Response(404, "Customer not found");
    }
}