namespace Connector.Accounting.v1.Account.Delete;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Action object that will represent an action in the Xchange system. This will contain an input object type,
/// an output object type, and a Action failure type (this will default to <see cref="StandardActionFailure"/>
/// but that can be overridden with your own preferred type). These objects will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[Description("DeleteAccountAction Action description goes here")]
public class DeleteAccountAction : IStandardAction<DeleteAccountActionInput, DeleteAccountActionOutput>
{
    public DeleteAccountActionInput ActionInput { get; set; } = new();
    public DeleteAccountActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class DeleteAccountActionInput
{

}

public class DeleteAccountActionOutput
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}
