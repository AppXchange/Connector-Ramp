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

namespace Connector.Core.v1.Limits;

public class LimitsDataReader : TypedAsyncDataReaderBase<LimitsDataObject>
{
    private readonly ILogger<LimitsDataReader> _logger;
    private int _currentPage = 0;

    public LimitsDataReader(
        ILogger<LimitsDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<LimitsDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<LimitsDataObject>>();
            // If the LimitsDataObject does not have the same structure as the Limits response from the API, create a new class for it and replace LimitsDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<LimitsResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<LimitsDataObject>(
                //    relativeUrl: "limits",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'LimitsDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'LimitsDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new LimitsDataObject object, map the properties and return a LimitsDataObject.

                // Example:
                //var resource = new LimitsDataObject
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