namespace Connector.Core.v1;
using Connector.Core.v1.BankAccount;
using Connector.Core.v1.Bill;
using Connector.Core.v1.Bills;
using Connector.Core.v1.Business;
using Connector.Core.v1.BusinessBalance;
using Connector.Core.v1.Card;
using Connector.Core.v1.CardProgram;
using Connector.Core.v1.CardPrograms;
using Connector.Core.v1.Cards;
using Connector.Core.v1.CardsDeferredTaskStatus;
using Connector.Core.v1.Cashback;
using Connector.Core.v1.Cashbacks;
using Connector.Core.v1.Department;
using Connector.Core.v1.Departments;
using Connector.Core.v1.Entities;
using Connector.Core.v1.Entity;
using Connector.Core.v1.Lead;
using Connector.Core.v1.Limit;
using Connector.Core.v1.Limits;
using Connector.Core.v1.LimitsDeferredTaskStatus;
using Connector.Core.v1.Location;
using Connector.Core.v1.Locations;
using Connector.Core.v1.Memos;
using Connector.Core.v1.MemosTransaction;
using Connector.Core.v1.Merchants;
using Connector.Core.v1.PhysicalCard;
using Connector.Core.v1.Receipt;
using Connector.Core.v1.Receipts;
using Connector.Core.v1.Reimbursement;
using Connector.Core.v1.Reimbursements;
using Connector.Core.v1.SharedLimit;
using Connector.Core.v1.SpendProgram;
using Connector.Core.v1.SpendPrograms;
using Connector.Core.v1.Statement;
using Connector.Core.v1.Statements;
using Connector.Core.v1.Transaction;
using Connector.Core.v1.Transactions;
using Connector.Core.v1.Transfer;
using Connector.Core.v1.Transfers;
using Connector.Core.v1.User;
using Connector.Core.v1.UserInvite;
using Connector.Core.v1.Users;
using Connector.Core.v1.UsersDeferredTaskStatus;
using Connector.Core.v1.Vendor;
using Connector.Core.v1.VendorBankAccount;
using Connector.Core.v1.VendorBankAccounts;
using Connector.Core.v1.VendorContact;
using Connector.Core.v1.VendorContacts;
using Connector.Core.v1.Vendors;
using Connector.Core.v1.VirtualCard;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Core V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class CoreV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig BankAccountConfig { get; set; } = new();
    public CacheWriterObjectConfig BillsConfig { get; set; } = new();
    public CacheWriterObjectConfig BillConfig { get; set; } = new();
    public CacheWriterObjectConfig BusinessConfig { get; set; } = new();
    public CacheWriterObjectConfig BusinessBalanceConfig { get; set; } = new();
    public CacheWriterObjectConfig CardProgramsConfig { get; set; } = new();
    public CacheWriterObjectConfig CardProgramConfig { get; set; } = new();
    public CacheWriterObjectConfig CardsConfig { get; set; } = new();
    public CacheWriterObjectConfig CardConfig { get; set; } = new();
    public CacheWriterObjectConfig CardsDeferredTaskStatusConfig { get; set; } = new();
    public CacheWriterObjectConfig PhysicalCardConfig { get; set; } = new();
    public CacheWriterObjectConfig VirtualCardConfig { get; set; } = new();
    public CacheWriterObjectConfig CashbacksConfig { get; set; } = new();
    public CacheWriterObjectConfig CashbackConfig { get; set; } = new();
    public CacheWriterObjectConfig DepartmentsConfig { get; set; } = new();
    public CacheWriterObjectConfig DepartmentConfig { get; set; } = new();
    public CacheWriterObjectConfig EntitiesConfig { get; set; } = new();
    public CacheWriterObjectConfig EntityConfig { get; set; } = new();
    public CacheWriterObjectConfig LeadConfig { get; set; } = new();
    public CacheWriterObjectConfig LimitsConfig { get; set; } = new();
    public CacheWriterObjectConfig LimitConfig { get; set; } = new();
    public CacheWriterObjectConfig LimitsDeferredTaskStatusConfig { get; set; } = new();
    public CacheWriterObjectConfig SharedLimitConfig { get; set; } = new();
    public CacheWriterObjectConfig LocationsConfig { get; set; } = new();
    public CacheWriterObjectConfig LocationConfig { get; set; } = new();
    public CacheWriterObjectConfig MemosConfig { get; set; } = new();
    public CacheWriterObjectConfig MemosTransactionConfig { get; set; } = new();
    public CacheWriterObjectConfig MerchantsConfig { get; set; } = new();
    public CacheWriterObjectConfig ReceiptsConfig { get; set; } = new();
    public CacheWriterObjectConfig ReceiptConfig { get; set; } = new();
    public CacheWriterObjectConfig ReimbursementsConfig { get; set; } = new();
    public CacheWriterObjectConfig ReimbursementConfig { get; set; } = new();
    public CacheWriterObjectConfig SpendProgramsConfig { get; set; } = new();
    public CacheWriterObjectConfig SpendProgramConfig { get; set; } = new();
    public CacheWriterObjectConfig StatementsConfig { get; set; } = new();
    public CacheWriterObjectConfig StatementConfig { get; set; } = new();
    public CacheWriterObjectConfig TransactionsConfig { get; set; } = new();
    public CacheWriterObjectConfig TransactionConfig { get; set; } = new();
    public CacheWriterObjectConfig TransfersConfig { get; set; } = new();
    public CacheWriterObjectConfig TransferConfig { get; set; } = new();
    public CacheWriterObjectConfig UsersConfig { get; set; } = new();
    public CacheWriterObjectConfig UserConfig { get; set; } = new();
    public CacheWriterObjectConfig UserInviteConfig { get; set; } = new();
    public CacheWriterObjectConfig UsersDeferredTaskStatusConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorsConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorBankAccountsConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorBankAccountConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorContactsConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorContactConfig { get; set; } = new();
}