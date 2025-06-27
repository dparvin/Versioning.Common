# Versioning.Common

**Versioning.Common** provides a simple, centralized way to manage version numbers across multiple .NET projects using MSBuild. It works both for local development and automated CI builds (e.g., Azure DevOps, GitHub Actions).

## ✨ Features

- Automatically sets:
  - `Version`
  - `AssemblyVersion`
  - `FileVersion`
  - `InformationalVersion`
- Supports CI/CD overrides with MSBuild properties (`BaseVersion`, `BuildMetadata`, `BuildIdentifier`)
- Auto-imports `.props` and `.targets` (no manual imports)
- Logs version info during build (optional)

## 📦 Usage

### 1. Add the Package

```xml
<PackageReference Include="Versioning.Common" Version="1.0.0" />
```

No manual import needed — MSBuild handles it.

### 2. Set Base Version (Optional)

In your .csproj (optional — for local development):

```xml
<PropertyGroup>
  <BaseVersion>2.0.0</BaseVersion>
</PropertyGroup>
```

In CI:

```bash
msbuild /p:BaseVersion=2.0.0 /p:BuildMetadata=beta1 /p:BuildIdentifier=build.20250614.shaabc123
```

To silence logging in local builds:

```xml
<PropertyGroup>
  <LogVersionInfo>false</LogVersionInfo>
</PropertyGroup>
```

### 💡 Example Build Output

```text
================== Versioning Info ==================
  ➤ BaseVersion: 2.0.0
  ➤ VersionRevision: 0
  ➤ BuildMetadata: beta1
  ➤ BuildIdentifier: build.20250614.shaabc123
  ➤ AssemblyVersion: 2.0.0.0
  ➤ FileVersion: 2.0.0.0
  ➤ Version (NuGet): 2.0.0-beta1
  ➤ InformationalVersion: 2.0.0-beta1+build.20250614.shaabc123
=====================================================
🎯 TFM: net35 | Lang: VB
📄 Generating assembly version file: obj\Debug\net35\Versioning_Common_GeneratedAssemblyInfo.vb
```

## 🛠 Tips

- Works with SDK-style projects
- Remove `[assembly: AssemblyVersion(...)]` etc. from your existing AssemblyInfo files to avoid duplicate attribute errors.
- Works with VB.NET, C# and F# projects
- Supports F# with correct module ordering via .props/.targets
- Use `BuildMetadata` for prerelease labels (e.g., alpha, rc.1)
- Use `BuildIdentifier` for commit hashes or CI run IDs
