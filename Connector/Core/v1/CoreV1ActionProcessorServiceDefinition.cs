namespace Connector.Core.v1;
using Connector.Core.v1.Bill;
using Connector.Core.v1.Bill.Create;
using Connector.Core.v1.Bill.Delete;
using Connector.Core.v1.Bill.Update;
using Connector.Core.v1.Card;
using Connector.Core.v1.Card.Suspend;
using Connector.Core.v1.Card.Terminate;
using Connector.Core.v1.Card.Unlock;
using Connector.Core.v1.Card.Update;
using Connector.Core.v1.CardProgram;
using Connector.Core.v1.CardProgram.Create;
using Connector.Core.v1.Department;
using Connector.Core.v1.Department.Create;
using Connector.Core.v1.Department.Update;
using Connector.Core.v1.Lead;
using Connector.Core.v1.Lead.Create;
using Connector.Core.v1.Limit;
using Connector.Core.v1.Limit.Create;
using Connector.Core.v1.Limit.Suspend;
using Connector.Core.v1.Limit.Terminate;
using Connector.Core.v1.Limit.Unsuspend;
using Connector.Core.v1.Limit.Update;
using Connector.Core.v1.Location;
using Connector.Core.v1.Location.Create;
using Connector.Core.v1.Location.Update;
using Connector.Core.v1.MemosTransaction;
using Connector.Core.v1.MemosTransaction.Upload;
using Connector.Core.v1.PhysicalCard;
using Connector.Core.v1.PhysicalCard.Create;
using Connector.Core.v1.Receipt;
using Connector.Core.v1.Receipt.Upload;
using Connector.Core.v1.SharedLimit;
using Connector.Core.v1.SharedLimit.AddUsers;
using Connector.Core.v1.SharedLimit.RemoveUsers;
using Connector.Core.v1.SpendProgram;
using Connector.Core.v1.SpendProgram.Create;
using Connector.Core.v1.User;
using Connector.Core.v1.User.Deactivate;
using Connector.Core.v1.User.Reactivate;
using Connector.Core.v1.User.Update;
using Connector.Core.v1.UserInvite;
using Connector.Core.v1.UserInvite.Create;
using Connector.Core.v1.Vendor;
using Connector.Core.v1.Vendor.Create;
using Connector.Core.v1.Vendor.Delete;
using Connector.Core.v1.Vendor.Update;
using Connector.Core.v1.VirtualCard;
using Connector.Core.v1.VirtualCard.Create;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class CoreV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<CoreV1ActionProcessorConfig>
{
    public override string ModuleId => "core-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<CoreV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<CoreV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<CoreV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<CoreV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<CoreV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateBillHandler>();
        serviceCollection.AddScoped<UpdateBillHandler>();
        serviceCollection.AddScoped<DeleteBillHandler>();
        serviceCollection.AddScoped<CreateCardProgramHandler>();
        serviceCollection.AddScoped<UpdateCardHandler>();
        serviceCollection.AddScoped<SuspendCardHandler>();
        serviceCollection.AddScoped<TerminateCardHandler>();
        serviceCollection.AddScoped<UnlockCardHandler>();
        serviceCollection.AddScoped<CreatePhysicalCardHandler>();
        serviceCollection.AddScoped<CreateVirtualCardHandler>();
        serviceCollection.AddScoped<CreateDepartmentHandler>();
        serviceCollection.AddScoped<UpdateDepartmentHandler>();
        serviceCollection.AddScoped<CreateLeadHandler>();
        serviceCollection.AddScoped<CreateLimitHandler>();
        serviceCollection.AddScoped<UpdateLimitHandler>();
        serviceCollection.AddScoped<TerminateLimitHandler>();
        serviceCollection.AddScoped<SuspendLimitHandler>();
        serviceCollection.AddScoped<UnsuspendLimitHandler>();
        serviceCollection.AddScoped<AddUsersSharedLimitHandler>();
        serviceCollection.AddScoped<RemoveUsersSharedLimitHandler>();
        serviceCollection.AddScoped<CreateLocationHandler>();
        serviceCollection.AddScoped<UpdateLocationHandler>();
        serviceCollection.AddScoped<UploadMemosTransactionHandler>();
        serviceCollection.AddScoped<UploadReceiptHandler>();
        serviceCollection.AddScoped<CreateSpendProgramHandler>();
        serviceCollection.AddScoped<UpdateUserHandler>();
        serviceCollection.AddScoped<DeactivateUserHandler>();
        serviceCollection.AddScoped<ReactivateUserHandler>();
        serviceCollection.AddScoped<CreateUserInviteHandler>();
        serviceCollection.AddScoped<UpdateVendorHandler>();
        serviceCollection.AddScoped<DeleteVendorHandler>();
        serviceCollection.AddScoped<CreateVendorHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, CoreV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateBillHandler, BillDataObject>(ModuleId, "bill", "create", config.CreateBillConfig);
        service.RegisterHandlerForDataObjectAction<UpdateBillHandler, BillDataObject>(ModuleId, "bill", "update", config.UpdateBillConfig);
        service.RegisterHandlerForDataObjectAction<DeleteBillHandler, BillDataObject>(ModuleId, "bill", "delete", config.DeleteBillConfig);
        service.RegisterHandlerForDataObjectAction<CreateCardProgramHandler, CardProgramDataObject>(ModuleId, "card-program", "create", config.CreateCardProgramConfig);
        service.RegisterHandlerForDataObjectAction<UpdateCardHandler, CardDataObject>(ModuleId, "card", "update", config.UpdateCardConfig);
        service.RegisterHandlerForDataObjectAction<SuspendCardHandler, CardDataObject>(ModuleId, "card", "suspend", config.SuspendCardConfig);
        service.RegisterHandlerForDataObjectAction<TerminateCardHandler, CardDataObject>(ModuleId, "card", "terminate", config.TerminateCardConfig);
        service.RegisterHandlerForDataObjectAction<UnlockCardHandler, CardDataObject>(ModuleId, "card", "unlock", config.UnlockCardConfig);
        service.RegisterHandlerForDataObjectAction<CreatePhysicalCardHandler, PhysicalCardDataObject>(ModuleId, "physical-card", "create", config.CreatePhysicalCardConfig);
        service.RegisterHandlerForDataObjectAction<CreateVirtualCardHandler, VirtualCardDataObject>(ModuleId, "virtual-card", "create", config.CreateVirtualCardConfig);
        service.RegisterHandlerForDataObjectAction<CreateDepartmentHandler, DepartmentDataObject>(ModuleId, "department", "create", config.CreateDepartmentConfig);
        service.RegisterHandlerForDataObjectAction<UpdateDepartmentHandler, DepartmentDataObject>(ModuleId, "department", "update", config.UpdateDepartmentConfig);
        service.RegisterHandlerForDataObjectAction<CreateLeadHandler, LeadDataObject>(ModuleId, "lead", "create", config.CreateLeadConfig);
        service.RegisterHandlerForDataObjectAction<CreateLimitHandler, LimitDataObject>(ModuleId, "limit", "create", config.CreateLimitConfig);
        service.RegisterHandlerForDataObjectAction<UpdateLimitHandler, LimitDataObject>(ModuleId, "limit", "update", config.UpdateLimitConfig);
        service.RegisterHandlerForDataObjectAction<TerminateLimitHandler, LimitDataObject>(ModuleId, "limit", "terminate", config.TerminateLimitConfig);
        service.RegisterHandlerForDataObjectAction<SuspendLimitHandler, LimitDataObject>(ModuleId, "limit", "suspend", config.SuspendLimitConfig);
        service.RegisterHandlerForDataObjectAction<UnsuspendLimitHandler, LimitDataObject>(ModuleId, "limit", "unsuspend", config.UnsuspendLimitConfig);
        service.RegisterHandlerForDataObjectAction<AddUsersSharedLimitHandler, SharedLimitDataObject>(ModuleId, "shared-limit", "add-users", config.AddUsersSharedLimitConfig);
        service.RegisterHandlerForDataObjectAction<RemoveUsersSharedLimitHandler, SharedLimitDataObject>(ModuleId, "shared-limit", "remove-users", config.RemoveUsersSharedLimitConfig);
        service.RegisterHandlerForDataObjectAction<CreateLocationHandler, LocationDataObject>(ModuleId, "location", "create", config.CreateLocationConfig);
        service.RegisterHandlerForDataObjectAction<UpdateLocationHandler, LocationDataObject>(ModuleId, "location", "update", config.UpdateLocationConfig);
        service.RegisterHandlerForDataObjectAction<UploadMemosTransactionHandler, MemosTransactionDataObject>(ModuleId, "memos-transaction", "upload", config.UploadMemosTransactionConfig);
        service.RegisterHandlerForDataObjectAction<UploadReceiptHandler, ReceiptDataObject>(ModuleId, "receipt", "upload", config.UploadReceiptConfig);
        service.RegisterHandlerForDataObjectAction<CreateSpendProgramHandler, SpendProgramDataObject>(ModuleId, "spend-program", "create", config.CreateSpendProgramConfig);
        service.RegisterHandlerForDataObjectAction<UpdateUserHandler, UserDataObject>(ModuleId, "user", "update", config.UpdateUserConfig);
        service.RegisterHandlerForDataObjectAction<DeactivateUserHandler, UserDataObject>(ModuleId, "user", "deactivate", config.DeactivateUserConfig);
        service.RegisterHandlerForDataObjectAction<ReactivateUserHandler, UserDataObject>(ModuleId, "user", "reactivate", config.ReactivateUserConfig);
        service.RegisterHandlerForDataObjectAction<CreateUserInviteHandler, UserInviteDataObject>(ModuleId, "user-invite", "create", config.CreateUserInviteConfig);
        service.RegisterHandlerForDataObjectAction<UpdateVendorHandler, VendorDataObject>(ModuleId, "vendor", "update", config.UpdateVendorConfig);
        service.RegisterHandlerForDataObjectAction<DeleteVendorHandler, VendorDataObject>(ModuleId, "vendor", "delete", config.DeleteVendorConfig);
        service.RegisterHandlerForDataObjectAction<CreateVendorHandler, VendorDataObject>(ModuleId, "vendor", "create", config.CreateVendorConfig);
    }
}