# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

Blazor WebAssembly (net8.0) front end for an Incident Tracker, consuming a backend API whose Swagger UI is at `https://localhost:7147/swagger/index.html`. There is no server-side project in this repo — it is a standalone WASM client, run via `wwwroot/index.html` + `_framework/blazor.webassembly.js`.

## Commands

Run from the repo root (`IncidentTrackerUI.sln` / `IncidentTrackerUI.csproj` are the same directory as this file).

```
dotnet restore   # restores from nuget.org only, see NuGet.Config
dotnet build
dotnet run       # serves via the https or http launch profile (see below)
dotnet watch     # hot-reload dev loop
```

There are no test projects yet.

### NuGet source
`NuGet.Config` at the repo root uses `<clear />` + `nuget.org` only. This intentionally overrides the machine-wide NuGet config (which also points at a company Nexus feed) so this personal project always restores from nuget.org regardless of machine.

### Launch profiles
`Properties/launchSettings.json` defines `http` (`http://localhost:5201`) and `https` (`https://localhost:7127`) profiles. Neither port matches the backend API port (7147) — the API is a separate process that must be running independently for data calls to succeed.

## Architecture

### Backend connectivity
Two `HttpClient` registrations are configured in `Program.cs`:
- A default scoped `HttpClient` whose base address is this WASM app's own origin (`builder.HostEnvironment.BaseAddress`) — used for same-origin/static requests (e.g. `wwwroot/appsettings.json`).
- A **keyed** scoped `HttpClient` registered under the key `"Api"`, base address taken from `ApiBaseUrl` in `wwwroot/appsettings.json` (defaults to `https://localhost:7147/` if missing). Inject it in a component/service with:
  ```csharp
  [Inject, FromKeyedServices("Api")] HttpClient Api { get; set; }
  ```
  Use this client for all calls to the backend Swagger API. Change the API's address via `wwwroot/appsettings.json`, not by editing `Program.cs`.

### Routing & layout
Standard Blazor WASM router setup: `App.razor` → `Router` → `MainLayout` (`Layout/MainLayout.razor`), which renders a left sidebar (`Layout/NavMenu.razor`) plus `@Body`. Page components live flat under `Pages/` and declare their own `@page "/route"`.

### Sidebar navigation contract
`NavMenu.razor` is the single source of truth for the app's primary sections, in a fixed order: **Assets → Incidents → Work Orders → Teams → Users**. Each entry maps 1:1 to a page under `Pages/` (`Assets.razor` → `/assets`, `Incidents.razor` → `/incidents`, `WorkOrders.razor` → `/work-orders`, `Teams.razor` → `/teams`, `Users.razor` → `/users`) and to a hand-authored SVG icon class in `Layout/NavMenu.razor.css` (`bi-<section>-nav-menu`, following the same data-URI pattern as the default `bi-house-door-fill-nav-menu` etc.). `Home.razor` (route `/`) is the landing/intro page and is deliberately not in the sidebar.

When adding a new top-level section, update all three in lockstep: the `NavLink` in `NavMenu.razor`, the icon rule in `NavMenu.razor.css`, and the page under `Pages/`.

### Page maturity
Every non-home page under `Pages/` is currently a placeholder (`@page` route + title + a Bootstrap `alert-info` "Welcome to X section" block). These are intended to grow into full CRUD screens with paginated tables backed by the `"Api"` keyed `HttpClient` — when building those out, follow the existing placeholder's route/title conventions rather than introducing new patterns.

### UI library
Bootstrap is vendored locally under `wwwroot/css/bootstrap/` and linked directly in `wwwroot/index.html` — there is no npm/webpack build step. Use standard Bootstrap classes/components; don't add a package manager or bundler for styling.
