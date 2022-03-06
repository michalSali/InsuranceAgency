# Paramilitary Groups Insurance Agency: Blazor Server UI

Web UI written in Blazor Server with use of MudBlazor.

## File Structure

* `Authentication` - contains custom authentication provider used on frontend
    * `Utility` - contains utilities that can be used with claims to extract information about logged in user
* `Pages` - contains pages/components
    * `Administrator` - contains pages/components that administrator can access
    * `Client` - contains pages/components that client can access
    * `Director` - contains pages/components that director can access
    * `InsuranceAgent` - contains pages/components that insurance agent can access
    * `User` - contains pages/components that logged in user can access
    * `Login` - contains pages/components used for registration and login
* `Properties` - properties for Azure deployment
* `Shared` - shared pages
* `App.razor` - base app page
* `_Imports.razor` - shared imports
* `appsettings.json` - app settings config
* `Startup.cs` - startup file, used to configure services
* `Program.cs` - entry point, contains main


