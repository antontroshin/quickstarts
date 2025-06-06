using Dapr.Workflow;
using ExternalEvents;
using ExternalEvents.Activities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDaprWorkflow(options =>
{
    options.RegisterWorkflow<ExternalEventsWorkflow>();
    options.RegisterActivity<RequestApproval>();
    options.RegisterActivity<ProcessOrder>();
    options.RegisterActivity<SendNotification>();
});
var app = builder.Build();

app.MapPost("/start", async (
    Order order,
    DaprWorkflowClient workflowClient) =>
{
    Console.WriteLine($"Received order: {order}.");

    var instanceId = await workflowClient.ScheduleNewWorkflowAsync(
        name: nameof(ExternalEventsWorkflow),
        instanceId: order.Id,
        input: order);

    return Results.Accepted(instanceId);
});

app.Run();

internal sealed record Order(string Id, string Description, int Quantity, double TotalPrice);
