namespace Connector.Accounting.v1;
using Connector.Accounting.v1.Account;
using Connector.Accounting.v1.Account.Delete;
using Connector.Accounting.v1.Account.Update;
using Connector.Accounting.v1.Accounts;
using Connector.Accounting.v1.Accounts.Upload;
using Connector.Accounting.v1.Connection;
using Connector.Accounting.v1.Connection.Delete;
using Connector.Accounting.v1.Connection.Register;
using Connector.Accounting.v1.Field;
using Connector.Accounting.v1.Field.Delete;
using Connector.Accounting.v1.Field.Update;
using Connector.Accounting.v1.FieldOptions;
using Connector.Accounting.v1.FieldOptions.Delete;
using Connector.Accounting.v1.FieldOptions.Update;
using Connector.Accounting.v1.FieldOptions.Upload;
using Connector.Accounting.v1.Fields;
using Connector.Accounting.v1.Fields.Create;
using Connector.Accounting.v1.Sync;
using Connector.Accounting.v1.Sync.PostStatus;
using Connector.Accounting.v1.Vendors;
using Connector.Accounting.v1.Vendors.Delete;
using Connector.Accounting.v1.Vendors.Update;
using Connector.Accounting.v1.Vendors.Upload;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class AccountingV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<AccountingV1ActionProcessorConfig>
{
    public override string ModuleId => "accounting-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<AccountingV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<AccountingV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<AccountingV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<AccountingV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<AccountingV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<UploadFieldOptionsHandler>();
        serviceCollection.AddScoped<UpdateFieldOptionsHandler>();
        serviceCollection.AddScoped<DeleteFieldOptionsHandler>();
        serviceCollection.AddScoped<CreateFieldsHandler>();
        serviceCollection.AddScoped<UpdateFieldHandler>();
        serviceCollection.AddScoped<DeleteFieldHandler>();
        serviceCollection.AddScoped<UploadAccountsHandler>();
        serviceCollection.AddScoped<UpdateAccountHandler>();
        serviceCollection.AddScoped<DeleteAccountHandler>();
        serviceCollection.AddScoped<RegisterConnectionHandler>();
        serviceCollection.AddScoped<DeleteConnectionHandler>();
        serviceCollection.AddScoped<PostStatusSyncHandler>();
        serviceCollection.AddScoped<UploadVendorsHandler>();
        serviceCollection.AddScoped<UpdateVendorsHandler>();
        serviceCollection.AddScoped<DeleteVendorsHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, AccountingV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<UploadFieldOptionsHandler, FieldOptionsDataObject>(ModuleId, "field-options", "upload", config.UploadFieldOptionsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateFieldOptionsHandler, FieldOptionsDataObject>(ModuleId, "field-options", "update", config.UpdateFieldOptionsConfig);
        service.RegisterHandlerForDataObjectAction<DeleteFieldOptionsHandler, FieldOptionsDataObject>(ModuleId, "field-options", "delete", config.DeleteFieldOptionsConfig);
        service.RegisterHandlerForDataObjectAction<CreateFieldsHandler, FieldsDataObject>(ModuleId, "fields", "create", config.CreateFieldsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateFieldHandler, FieldDataObject>(ModuleId, "field", "update", config.UpdateFieldConfig);
        service.RegisterHandlerForDataObjectAction<DeleteFieldHandler, FieldDataObject>(ModuleId, "field", "delete", config.DeleteFieldConfig);
        service.RegisterHandlerForDataObjectAction<UploadAccountsHandler, AccountsDataObject>(ModuleId, "accounts", "upload", config.UploadAccountsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateAccountHandler, AccountDataObject>(ModuleId, "account", "update", config.UpdateAccountConfig);
        service.RegisterHandlerForDataObjectAction<DeleteAccountHandler, AccountDataObject>(ModuleId, "account", "delete", config.DeleteAccountConfig);
        service.RegisterHandlerForDataObjectAction<RegisterConnectionHandler, ConnectionDataObject>(ModuleId, "connection", "register", config.RegisterConnectionConfig);
        service.RegisterHandlerForDataObjectAction<DeleteConnectionHandler, ConnectionDataObject>(ModuleId, "connection", "delete", config.DeleteConnectionConfig);
        service.RegisterHandlerForDataObjectAction<PostStatusSyncHandler, SyncDataObject>(ModuleId, "sync", "post-status", config.PostStatusSyncConfig);
        service.RegisterHandlerForDataObjectAction<UploadVendorsHandler, VendorsDataObject>(ModuleId, "vendors", "upload", config.UploadVendorsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateVendorsHandler, VendorsDataObject>(ModuleId, "vendors", "update", config.UpdateVendorsConfig);
        service.RegisterHandlerForDataObjectAction<DeleteVendorsHandler, VendorsDataObject>(ModuleId, "vendors", "delete", config.DeleteVendorsConfig);
    }
}