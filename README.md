# RAMP Connector for AppXchange

## Overview

The **RAMP Connector** enables seamless integration between RAMP's financial services platform and Trimble AppXchange. This connector facilitates data management and transactions across RAMP's comprehensive API endpoints, supporting accounting operations, card management, expense tracking, and vendor relationships.

## Prerequisites

1. **RAMP API Access**: Valid OAuth2 credentials for RAMP's API
2. **.NET SDK**: .NET 7 or 8 installed
3. **AppXchange CLI**: Install using `dotnet tool install Trimble.Xchange.Connector.CLI --global`
4. **C# Development Skills**: Intermediate level required
5. **API Understanding**: Familiarity with RAMP's API structure and endpoints

## Authentication

The connector uses OAuth 2.0 Authorization Code Flow for authentication. Key endpoints:

- **Token Creation**: POST `/developer/v1/token`
- **Token Refresh**: POST `/developer/v1/token/refresh`
- **Token Revocation**: POST `/developer/v1/token/revoke`

## Modules

### 1. Accounting Module (`accounting-1`)

Manages financial and accounting operations through various endpoints.

#### Data Objects:
- **FieldOptions**: Custom field configurations
- **Fields**: Accounting field definitions
- **Accounts**: GL account management
- **Connection**: Third-party system connections
- **Sync**: Synchronization status tracking
- **Vendors**: Vendor management

#### Key Actions:
- **FieldOptions**:
  - Upload: Create new field options
  - Update: Modify existing options
  - Delete: Remove field options
  
- **Fields**:
  - Create: Add new accounting fields
  - Update: Modify field properties
  - Delete: Remove fields
  
- **Accounts**:
  - Upload: Batch create accounts
  - Update: Modify account details
  - Delete: Remove accounts
  
- **Connection**:
  - Register: Create new connection
  - Delete: Remove connection
  
- **Sync**:
  - PostStatus: Update sync status
  
- **Vendors**:
  - Upload: Create vendors
  - Update: Modify vendor details
  - Delete: Remove vendors

### 2. Core Module (`core-1`)

Handles essential business operations and card management.

#### Data Objects:
- **BankAccount**: Banking information
- **Bills**: Payment tracking
- **Business**: Company information
- **Cards**: Card management
- **Cashbacks**: Reward tracking
- **Departments**: Organizational structure
- **Limits**: Spending controls
- **Locations**: Physical addresses
- **Merchants**: Vendor details
- **Receipts**: Transaction documentation
- **Transactions**: Financial records
- **Users**: User management
- **Vendors**: Vendor relationships

#### Key Actions:
- **Bills**:
  - Create: Generate new bills
  - Update: Modify bill details
  - Delete: Remove bills

- **Cards**:
  - Create: Issue new cards (virtual/physical)
  - Update: Modify card details
  - Suspend: Temporarily disable cards
  - Terminate: Permanently disable cards
  - Unlock: Reactivate suspended cards

- **Limits**:
  - Create: Set spending limits
  - Update: Modify limits
  - Terminate: Remove limits
  - Suspend/Unsuspend: Toggle limit status
  - AddUsers/RemoveUsers: Manage shared limits

- **Users**:
  - Create: Invite new users
  - Update: Modify user details
  - Deactivate/Reactivate: Manage user status

## API Structure

### Base URLs:
- Production: `https://api.ramp.com/developer/v1`
- Authentication: `https://auth.ramp.com/oauth2`

### Common Endpoints:

#### Accounting Module:
```
GET    /accounting/field-options
POST   /accounting/field-options
PATCH  /accounting/field-options/{id}
DELETE /accounting/field-options/{id}
GET    /accounting/fields
POST   /accounting/fields
GET    /accounting/accounts
POST   /accounting/accounts
```

#### Core Module:
```
GET    /cards
POST   /cards/deferred-virtual
POST   /cards/deferred-physical
PATCH  /cards/{id}
GET    /transactions
GET    /users
PATCH  /users/{id}
GET    /vendors
POST   /vendors
```

## Development

### Project Structure
```
connector-ramp/
├── Connector/
│   ├── App/
│   │   ├── accounting/
│   │   └── core/
│   ├── Client/
│   ├── Connections/
│   ├── Connector.csproj
│   └── settings.json
└── Connector.sln
```

### Getting Started

1. Clone the repository
2. Install dependencies:
   ```bash
   dotnet restore
   ```
3. Configure OAuth credentials in `test-settings.json`
4. Build the project:
   ```bash
   dotnet build
   ```

## Testing

1. Initialize test settings:
   ```bash
   xchange test init
   ```
2. Configure test credentials in `test-settings.json`
3. Run local tests:
   ```bash
   dotnet test
   ```

## Additional Resources

- [RAMP API Documentation](https://docs.ramp.com/developer-api)
- [AppXchange Connector Docs](https://trimble-xchange.github.io/connector-docs/)
- [OAuth 2.0 Guide](https://docs.ramp.com/developer-api/v1/guides/oauth)

## Support

For connector-specific issues, contact [xchange_build@trimble.com](mailto:xchange_build@trimble.com).
For RAMP API questions, refer to their [developer support](https://docs.ramp.com/developer-api).

