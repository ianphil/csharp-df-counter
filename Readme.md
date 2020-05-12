# CSharp Durable Functions Counter Starter Template

This is an implementation of the documentation for [.Net Durable Entities](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-dotnet-entities#accessing-entities-through-interfaces).

## Setup

**Dependencies**
 - VSCode
 - VSCode extensions: Azure Functions, CSharp
 - Azure Function Core Tools
 - Dotnet 3.1
 - Storage emulator (Windows) or Storage Account in Azure (Mac)
 - Postman

**Local Settings**

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```

> Note: If you change `AzureWebJobsStorage` to use storage account connection string in Azure, update `.gitignore` so that `local.settings.json` is not checked in as it contains secrets.