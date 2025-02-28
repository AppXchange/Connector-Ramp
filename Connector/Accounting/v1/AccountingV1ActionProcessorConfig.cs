namespace Connector.Accounting.v1;
using Connector.Accounting.v1.Account.Delete;
using Connector.Accounting.v1.Account.Update;
using Connector.Accounting.v1.Accounts.Upload;
using Connector.Accounting.v1.Connection.Delete;
using Connector.Accounting.v1.Connection.Register;
using Connector.Accounting.v1.Field.Delete;
using Connector.Accounting.v1.Field.Update;
using Connector.Accounting.v1.FieldOptions.Delete;
using Connector.Accounting.v1.FieldOptions.Update;
using Connector.Accounting.v1.FieldOptions.Upload;
using Connector.Accounting.v1.Fields.Create;
using Connector.Accounting.v1.Sync.PostStatus;
using Connector.Accounting.v1.Vendors.Delete;
using Connector.Accounting.v1.Vendors.Update;
using Connector.Accounting.v1.Vendors.Upload;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Accounting V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class AccountingV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig UploadFieldOptionsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateFieldOptionsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteFieldOptionsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateFieldsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateFieldConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteFieldConfig { get; set; } = new();
    public DefaultActionHandlerConfig UploadAccountsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateAccountConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteAccountConfig { get; set; } = new();
    public DefaultActionHandlerConfig RegisterConnectionConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteConnectionConfig { get; set; } = new();
    public DefaultActionHandlerConfig PostStatusSyncConfig { get; set; } = new();
    public DefaultActionHandlerConfig UploadVendorsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateVendorsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteVendorsConfig { get; set; } = new();
}