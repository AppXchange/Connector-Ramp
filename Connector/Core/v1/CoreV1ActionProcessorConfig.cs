namespace Connector.Core.v1;
using Connector.Core.v1.Bill.Create;
using Connector.Core.v1.Bill.Delete;
using Connector.Core.v1.Bill.Update;
using Connector.Core.v1.Card.Suspend;
using Connector.Core.v1.Card.Terminate;
using Connector.Core.v1.Card.Unlock;
using Connector.Core.v1.Card.Update;
using Connector.Core.v1.CardProgram.Create;
using Connector.Core.v1.Department.Create;
using Connector.Core.v1.Department.Update;
using Connector.Core.v1.Lead.Create;
using Connector.Core.v1.Limit.Create;
using Connector.Core.v1.Limit.Suspend;
using Connector.Core.v1.Limit.Terminate;
using Connector.Core.v1.Limit.Unsuspend;
using Connector.Core.v1.Limit.Update;
using Connector.Core.v1.Location.Create;
using Connector.Core.v1.Location.Update;
using Connector.Core.v1.MemosTransaction.Upload;
using Connector.Core.v1.PhysicalCard.Create;
using Connector.Core.v1.Receipt.Upload;
using Connector.Core.v1.SharedLimit.AddUsers;
using Connector.Core.v1.SharedLimit.RemoveUsers;
using Connector.Core.v1.SpendProgram.Create;
using Connector.Core.v1.User.Deactivate;
using Connector.Core.v1.User.Reactivate;
using Connector.Core.v1.User.Update;
using Connector.Core.v1.UserInvite.Create;
using Connector.Core.v1.Vendor.Create;
using Connector.Core.v1.Vendor.Delete;
using Connector.Core.v1.Vendor.Update;
using Connector.Core.v1.VirtualCard.Create;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Core V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class CoreV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateBillConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateBillConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteBillConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCardProgramConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCardConfig { get; set; } = new();
    public DefaultActionHandlerConfig SuspendCardConfig { get; set; } = new();
    public DefaultActionHandlerConfig TerminateCardConfig { get; set; } = new();
    public DefaultActionHandlerConfig UnlockCardConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePhysicalCardConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateVirtualCardConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateDepartmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateDepartmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateLeadConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateLimitConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateLimitConfig { get; set; } = new();
    public DefaultActionHandlerConfig TerminateLimitConfig { get; set; } = new();
    public DefaultActionHandlerConfig SuspendLimitConfig { get; set; } = new();
    public DefaultActionHandlerConfig UnsuspendLimitConfig { get; set; } = new();
    public DefaultActionHandlerConfig AddUsersSharedLimitConfig { get; set; } = new();
    public DefaultActionHandlerConfig RemoveUsersSharedLimitConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateLocationConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateLocationConfig { get; set; } = new();
    public DefaultActionHandlerConfig UploadMemosTransactionConfig { get; set; } = new();
    public DefaultActionHandlerConfig UploadReceiptConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateSpendProgramConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateUserConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeactivateUserConfig { get; set; } = new();
    public DefaultActionHandlerConfig ReactivateUserConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateUserInviteConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateVendorConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteVendorConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateVendorConfig { get; set; } = new();
}