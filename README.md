# Module - In-App Purchases

Unity IAP implementation of `IIAPService` from Core-Infra.

## Dependency
This module **requires** `com.studio.core-infra` to be present in the host project.  
Do NOT add Core-Infra as a Git Submodule inside this repository.  
The host Game project is responsible for supplying both packages.

## Provides
- `UnityIAPService` — Concrete `IIAPService` using Unity Purchasing
