namespace WorkflowConsoleApp.Models;

internal sealed record OrderPayload(string Name, double TotalCost, int Quantity = 1);
internal sealed record InventoryRequest(string RequestId, string ItemName, int Quantity);
internal sealed record InventoryResult(bool Success, OrderPayload? OrderPayload);
internal sealed record ApprovalRequest(string RequestId, string ItemBeingPurchased, int Quantity, double Amount);
internal sealed record ApprovalResponse(string RequestId, bool IsApproved);
internal sealed record PaymentRequest(string RequestId, string ItemBeingPurchased, int Amount, double Currency);
internal sealed record OrderResult(bool Processed);