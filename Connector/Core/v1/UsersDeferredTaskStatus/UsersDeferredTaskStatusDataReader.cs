using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Core.v1.UsersDeferredTaskStatus;

public class UsersDeferredTaskStatusDataReader : TypedAsyncDataReaderBase<UsersDeferredTaskStatusDataObject>
{
    private readonly ILogger<UsersDeferredTaskStatusDataReader> _logger;
    private int _currentPage = 0;

    public UsersDeferredTaskStatusDataReader(
        ILogger<UsersDeferredTaskStatusDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<UsersDeferredTaskStatusDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<UsersDeferredTaskStatusDataObject>>();
            // If the UsersDeferredTaskStatusDataObject does not have the same structure as the UsersDeferredTaskStatus response from the API, create a new class for it and replace UsersDeferredTaskStatusDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<UsersDeferredTaskStatusResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<UsersDeferredTaskStatusDataObject>(
                //    relativeUrl: "usersDeferredTaskStatus",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'UsersDeferredTaskStatusDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'UsersDeferredTaskStatusDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new UsersDeferredTaskStatusDataObject object, map the properties and return a UsersDeferredTaskStatusDataObject.

                // Example:
                //var resource = new UsersDeferredTaskStatusDataObject
                //{
                //// TODO: Map properties.      
                //};
                //yield return resource;
                yield return item;
            }

            // Handle pagination per API client design
            _currentPage++;
            if (_currentPage >= response.Data.TotalPages)
            {
                break;
            }
        }
    }
}