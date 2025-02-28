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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class AccountingV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<AccountingV1CacheWriterConfig>
{
    public override string ModuleId => "accounting-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<AccountingV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<AccountingV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<AccountingV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<AccountingV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<AccountingV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<FieldOptionsDataReader>();
        serviceCollection.AddSingleton<CustomFieldOptionsDataReader>();
        serviceCollection.AddSingleton<FieldsDataReader>();
        serviceCollection.AddSingleton<FieldDataReader>();
        serviceCollection.AddSingleton<AccountsDataReader>();
        serviceCollection.AddSingleton<AccountDataReader>();
        serviceCollection.AddSingleton<ConnectionDataReader>();
        serviceCollection.AddSingleton<SyncDataReader>();
        serviceCollection.AddSingleton<VendorsDataReader>();
        serviceCollection.AddSingleton<VendorDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<FieldOptionsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CustomFieldOptionsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<FieldsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<FieldDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AccountsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AccountDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ConnectionDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SyncDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, AccountingV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<FieldOptionsDataReader, FieldOptionsDataObject>(ModuleId, config.FieldOptionsConfig, dataReaderSettings);
        service.RegisterDataReader<CustomFieldOptionsDataReader, CustomFieldOptionsDataObject>(ModuleId, config.CustomFieldOptionsConfig, dataReaderSettings);
        service.RegisterDataReader<FieldsDataReader, FieldsDataObject>(ModuleId, config.FieldsConfig, dataReaderSettings);
        service.RegisterDataReader<FieldDataReader, FieldDataObject>(ModuleId, config.FieldConfig, dataReaderSettings);
        service.RegisterDataReader<AccountsDataReader, AccountsDataObject>(ModuleId, config.AccountsConfig, dataReaderSettings);
        service.RegisterDataReader<AccountDataReader, AccountDataObject>(ModuleId, config.AccountConfig, dataReaderSettings);
        service.RegisterDataReader<ConnectionDataReader, ConnectionDataObject>(ModuleId, config.ConnectionConfig, dataReaderSettings);
        service.RegisterDataReader<SyncDataReader, SyncDataObject>(ModuleId, config.SyncConfig, dataReaderSettings);
        service.RegisterDataReader<VendorsDataReader, VendorsDataObject>(ModuleId, config.VendorsConfig, dataReaderSettings);
        service.RegisterDataReader<VendorDataReader, VendorDataObject>(ModuleId, config.VendorConfig, dataReaderSettings);
    }
}