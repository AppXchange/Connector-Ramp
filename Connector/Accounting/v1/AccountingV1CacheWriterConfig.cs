namespace Connector.Accounting.v1;
using Connector.Accounting.v1.Account;
using Connector.Accounting.v1.Accounts;
using Connector.Accounting.v1.Connection;
using Connector.Accounting.v1.CustomFieldOptions;
using Connector.Accounting.v1.Field;
using Connector.Accounting.v1.FieldOptions;
using Connector.Accounting.v1.Fields;
using Connector.Accounting.v1.Sync;
using Connector.Accounting.v1.Vendor;
using Connector.Accounting.v1.Vendors;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Accounting V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class AccountingV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig FieldOptionsConfig { get; set; } = new();
    public CacheWriterObjectConfig CustomFieldOptionsConfig { get; set; } = new();
    public CacheWriterObjectConfig FieldsConfig { get; set; } = new();
    public CacheWriterObjectConfig FieldConfig { get; set; } = new();
    public CacheWriterObjectConfig AccountsConfig { get; set; } = new();
    public CacheWriterObjectConfig AccountConfig { get; set; } = new();
    public CacheWriterObjectConfig ConnectionConfig { get; set; } = new();
    public CacheWriterObjectConfig SyncConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorsConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorConfig { get; set; } = new();
}