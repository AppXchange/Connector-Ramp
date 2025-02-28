# RAMP Connector for AppXchange

## Overview

The RAMP Connector integrates the **RAMP API** with **AppXchange** to enable seamless interactions with RAMP's Accounting, Core, and other related modules. This connector facilitates data management and transactions for various RAMP services such as accounting fields, bank accounts, reimbursements, vendors, limits, cards, transactions, and more. 

This **RAMP Connector** enables users to create, update, retrieve, delete, and manage essential data objects and actions as part of their financial and accounting operations.

## Table of Contents

- [Connector Setup](#connector-setup)
- [Authentication](#authentication)
- [Modules](#modules)
  - [Module 1: Accounting](#module-1-accounting)
  - [Module 2: Core](#module-2-core)
- [Actions](#actions)
- [Data Objects](#data-objects)
- [API Endpoints](#api-endpoints)
- [Additional Resources](#additional-resources)

## Connector Setup

1. Navigate to the project directory:
    ```bash
    cd desktop/connectors
    mkdir connector-ramp
    cd connector-ramp
    xchange connector new --name RAMP
    cd connector
    ```

2. Initialize the AppXchange client:
    ```bash
    xchange client new --type Http --auth-type OAuth2CodeFlow
    ```

## Authentication

Authentication for the RAMP API is performed using the **OAuth 2.0 Authorization Code Flow**.

- [OAuth Guide](https://docs.ramp.com/developer-api/v1/guides/oauth)
- [Create Token](https://docs.ramp.com/developer-api/v1/api/authorization#post-developer-v1-token)
- [Revoke/Refresh Tokens](https://docs.ramp.com/developer-api/v1/api/authorization#post-developer-v1-token-revoke)

## Modules

### Module 1: Accounting

The **Accounting Module** provides the necessary endpoints and data objects for handling accounting-related tasks, including creating fields, updating accounts, managing GL accounts, vendors, and performing synchronization.

#### Key Data Objects:
- **FieldOptions**
- **Fields**
- **Accounts**
- **Account**
- **Connection**
- **Sync**
- **Vendors**
- **Vendor**
  
#### Key Actions:
- **Create Field Options**
- **Update/Upload/Delete Accounts**
- **Register/Delete Connections**
- **Post Sync Status**
- **Upload/Update/Delete Vendors**

### Module 2: Core

The **Core Module** offers endpoints and data objects that support basic financial operations like handling cards, bills, cashbacks, limits, transactions, users, and more.

#### Key Data Objects:
- **Bills**
- **CardPrograms**
- **Cards**
- **Cashbacks**
- **Departments**
- **Transactions**
- **Transfers**
- **Users**
- **Vendors**

#### Key Actions:
- **Create Bill**
- **Create/Update/Terminate Cards**
- **Create/Update Limits**
- **Upload Transactions/Receipts**
- **Update User Details**
- **Manage Vendor Accounts**

## Actions

- **Authentication Actions**: Handle token creation, revocation, and refresh.
- **Accounting Actions**: Upload field options, update GL accounts, and vendor management.
- **Core Actions**: Create bills, manage cards, and handle transactions.

## Data Objects

The following data objects are available for interaction:

- **Accounting Module**:
    - `FieldOptions`, `Fields`, `Accounts`, `Vendor`
    - Used for managing fields, account types, and vendor records.

- **Core Module**:
    - `Bills`, `Cards`, `Cashbacks`, `Departments`, `Transactions`, etc.
    - Used for managing transactional data, cards, cashbacks, and bills.

## API Endpoints

### Example API Calls:
- **Authentication API**: `POST /developer/v1/token`
- **Accounting**: 
  - `GET /developer/v1/accounting/fields`
  - `POST /developer/v1/accounting/fields`
- **Core**: 
  - `GET /developer/v1/cards`
  - `POST /developer/v1/cards`

For detailed API documentation, visit the [RAMP Developer API Docs](https://docs.ramp.com/developer-api).

## Additional Resources

- [AppXchange Documentation](https://docs.appxchange.trimble.com/)
- [AppXchange Connector Docs](https://trimble-xchange.github.io/connector-docs/)
