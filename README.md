# Incident Tracker UI

Blazor WebAssembly (`net8.0`) front end for an Incident Tracker. It is a standalone WASM
client with **no server-side project** — it runs entirely in the browser and talks to a
separate backend API (Swagger UI at `https://localhost:7147/swagger/index.html`).

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- The backend API running independently on its own port (default `https://localhost:7147/`).
  The UI's own launch ports do **not** match the API port — the API is a separate process.

## Getting started

Run all commands from the repo root (same directory as `IncidentTrackerUI.sln`):

```bash
dotnet restore   # restores from nuget.org only (see NuGet.Config)
dotnet build
dotnet run       # serves the app (see launch profiles below)
dotnet watch     # hot-reload dev loop
```

There are no test projects yet.

### Launch profiles

`Properties/launchSettings.json` defines:

| Profile | URL |
| ------- | --- |
| `http`  | `http://localhost:5201` |
| `https` | `https://localhost:7127` |

### NuGet source

`NuGet.Config` uses `<clear />` + `nuget.org` only, intentionally overriding any
machine-wide NuGet config so this project always restores from nuget.org.

## Configuration

Set the backend API address in `wwwroot/appsettings.json` (not in `Program.cs`):

```json
{
  "ApiBaseUrl": "https://localhost:7147/"
}
```

If `ApiBaseUrl` is missing it defaults to `https://localhost:7147/`.

## Architecture

### HttpClients

`Program.cs` registers two scoped `HttpClient`s:

- **Default** — base address is the app's own origin; use it for same-origin/static
  requests (e.g. loading `wwwroot/appsettings.json`).
- **Keyed `"Api"`** — base address from `ApiBaseUrl`; use it for **all** backend API calls.

  ```csharp
  [Inject, FromKeyedServices("Api")] HttpClient Api { get; set; }
  ```

### Routing & layout

Standard Blazor WASM setup: `App.razor` → `Router` → `MainLayout` (`Layout/MainLayout.razor`),
which renders the sidebar (`Layout/NavMenu.razor`) plus `@Body`. Page components live flat
under `Pages/` and declare their own `@page "/route"`.

### Sidebar navigation contract

`NavMenu.razor` is the single source of truth for the primary sections, in fixed order:

**Assets → Incidents → Work Orders → Teams → Users**

Each entry maps 1:1 to a page under `Pages/` and to an SVG icon class in
`Layout/NavMenu.razor.css` (`bi-<section>-nav-menu`). `Home.razor` (route `/`) is the
landing page and is deliberately not in the sidebar.

When adding a top-level section, update all three in lockstep: the `NavLink` in
`NavMenu.razor`, the icon rule in `NavMenu.razor.css`, and the page under `Pages/`.

### Page maturity

Every non-home page under `Pages/` is currently a placeholder (route + title + a
Bootstrap `alert-info` block). They are intended to grow into full CRUD screens with
paginated tables backed by the `"Api"` keyed `HttpClient`, following the existing
route/title conventions.

### UI library

Bootstrap is vendored locally under `wwwroot/css/bootstrap/` and linked from
`wwwroot/index.html`. There is no npm/webpack build step — use standard Bootstrap
classes and don't add a package manager or bundler for styling.
