# Mini Bank (NBE)

A web-based core banking management system built with ASP.NET Web Forms and Entity Framework. It models the day-to-day operations of a bank branch — customer onboarding, account creation, deposits, withdrawals, and transfers — enforced through a **maker-checker approval workflow**, the standard dual-control pattern used in real banking systems to prevent a single employee from creating or approving a financial action alone.

## Features

- **Customer management** — create, edit, and look up customers (CIF, national ID, contact details).
- **Account management** — open accounts, assign currency and branch, track balances.
- **Transactions** — deposit, withdraw, and transfer funds between accounts, with multi-currency support via a currency lookup/rate table.
- **Maker-checker workflow** — every sensitive action (new customer, new account, edits) is created by a "maker" and must be reviewed and approved or rejected by a separate "checker" before it takes effect.
- **Role-based access control** — session-based roles (e.g. maker, checker, customer) gate which pages and controls a user can reach.
- **Concurrency locking** — records being reviewed are locked to the reviewing user (`workingID`) so two checkers can't act on the same request at once.
- **Audit logging** — account, customer, and transaction actions are written to dedicated log tables (`log_accounts`, `log_customers`, `Transactions_log`, `SingleSideTransactions_log`).
- **Secure authentication** — passwords are hashed with SHA-256 before storage; includes a change-password flow.

## Tech Stack

| Layer | Technology |
|---|---|
| UI | ASP.NET Web Forms (.aspx / .ascx user controls) |
| Language | C# (.NET Framework 4.7.2) |
| Data access | Entity Framework 6 (Database First, `.edmx`) |
| Database | Microsoft SQL Server |
| Frontend | jQuery, custom CSS |

## Project Structure

```
├── Controls/                 # Reusable ASP.NET user controls (maker menu, checker menu,
│                              #   deposit/withdraw/transfer, validate accounts/customers)
├── *.aspx / *.aspx.cs        # Pages (Home, DepositMoney, WithdrawMoney, TransfereMoney,
│                              #   EditAccounts, EditCustomers, ValidateAccounts, etc.)
├── ACCOUNT.cs, CUSTOMER.cs,  # Entity Framework model classes generated from the DB schema
│   USER.cs, ...
├── NBEDatabase.edmx          # Entity Framework Database-First model
├── hasher.cs                 # SHA-256 password hashing utility
├── Styles/                   # Site CSS
└── Web.config                # Connection strings & app settings
```

## Getting Started

### Prerequisites
- Visual Studio 2019+ (or later) with ASP.NET / .NET Framework workload
- .NET Framework 4.7.2
- Microsoft SQL Server (local or remote instance)

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/Mario-Nader/mini-Bank.git
   ```
2. Open `NBE.sln` in Visual Studio.
3. Restore NuGet packages (Entity Framework, jQuery, etc.) if not restored automatically.
4. Create a SQL Server database named `mini_bank` matching the schema described in `NBEDatabase.edmx`.
5. Update the connection strings in `Web.config` (`DBconnection` and `mini_bankEntities`) to point to your SQL Server instance and credentials.
6. Build and run the project (F5) — IIS Express will host the site locally.

## Security Note

This is a learning/portfolio project. The sample `Web.config` in this repo contains placeholder database credentials for local development only — replace them with your own before deploying, and never commit real credentials to source control.

