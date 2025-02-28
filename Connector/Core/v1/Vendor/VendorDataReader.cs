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

namespace Connector.Core.v1.Vendor;

public class VendorDataReader : TypedAsyncDataReaderBase<VendorDataObject>
{
    private readonly ILogger<VendorDataReader> _logger;
    private int _currentPage = 0;

    public VendorDataReader(
        ILogger<VendorDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<VendorDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<VendorDataObject>>();
            // If the VendorDataObject does not have the same structure as the Vendor response from the API, create a new class for it and replace VendorDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<VendorResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<VendorDataObject>(
                //    relativeUrl: "vendors",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'VendorDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'VendorDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new VendorDataObject object, map the properties and return a VendorDataObject.

                // Example:
                //var resource = new VendorDataObject
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