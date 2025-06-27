# Versioning.Common

**Versioning.Common** provides a simple, centralized way to manage version numbers across multiple .NET projects using MSBuild. It works both for local development and automated CI builds (e.g., Azure DevOps, GitHub Actions).

## ✨ Features

- Automatically sets:
  - `Version`
  - `AssemblyVersion`
  - `FileVersion`
  - `InformationalVersion`
- Supports CI/CD overrides via MSBuild properties (like `BaseVersion` or `BuildMetadata`)
- Clean fallback defaults for local development
- No manual version duplication across projects
- Auto-imported when used as a NuGet package (`.props` and `.targets` support)

## 📦 Usage

### 1. Add the Package

```xml
<PackageReference Include="Versioning.Common" Version="1.0.0" />
```

Once added, no further imports are necessary. MSBuild will automatically pick up the .props and .targets files.

### 2. Set Base Version (Optional)

In your .csproj (optional — for local development):

```xml
<PropertyGroup>
  <BaseVersion>2.0.0</BaseVersion>
</PropertyGroup>
```

If you decide you don't want the version info in the build log, you can add this to your project to turn it off:

```xml
<PropertyGroup>
  <LogVersionInfo Condition="'$(LogVersionInfo)' == ''">false</LogVersionInfo>
</PropertyGroup>
```

With that in your project, you can still have it showing in your build pipeline while not showing in Visual Studio.

If you want to roll your own AssemblyInfo file in your project to control other attributes, you can set the following property. Versioning.Common will then only generate the version-related attributes automatically, and leave the rest to you:

```xml
<PropertyGroup>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
</PropertyGroup>
```

In your CI build (recommended):

```bash
msbuild /p:BaseVersion=2.0.0 /p:BuildMetadata=beta1
```

### 3. Resulting Versions

```text
MSBuild Property        Example Output
AssemblyVersion         2.0.0.0
FileVersion             2.0.0.0
Version                 2.0.0-beta1
InformationalVersion    2.0.0-beta1
```

### ⚠ Special Note for F# Projects

F# requires all compile files to be known up front and expects the AssemblyInfo-style file to appear before the main program module. To handle this:

✅ The package provides a .props file which pre-registers the path to the generated assembly info file.

✅ The .targets file then writes the content to that file before compile.

This means you do not have to change your F# source file ordering — just reference the package normally and let MSBuild handle it.

## 🛠 How It Works

The .targets file sets the versions, and generates the AssemblyInfo file, and then writes to the build log.

Local builds use BaseVersion; CI builds can override via CLI.

### Build Variables Available

- BaseVersion - The major, minor and patch indicators for the version.
- BuildMetadata - optional version metadata that can identify the build as a beta or release candidate.
- BuildIdentifier - optional data used to specifically identify the build this is from.
- VersionRevision - optional version revision number.  Normally this defaults to 0.  It is used for the fourth part of the version number.
- LogVersionInfo - turn on or off the logging of the version information in the build output.  If not set to true, logging will be turned off.

Each of these variables can be set in your project file, and/or supplied by your automated build process.  You can make them work one way in Visual Studio and another in your automated build.

If you are setting versions in your AssemblyInfo file, then you will want to remove those so that the build process will use this process instead.  If they are not removed, you will get duplicate attribute compiler errors from your AssemblyInfo file.

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

### Testing the files

There is a solution and 6 projects in the Code folder, which all reference the props and targets files.  When making changes to the main goal of this repository, these projects can be used to test the components without having to make the package, distribute it and import it to test it.

### ✅ Compatibility

- .NET SDK-style projects (all frameworks)

- Works with C#, VB.NET and F# projects

- Supports F# with correct module ordering (via .props and .targets coordination)

- Compatible with MSBuild 16.0+

- CI support: Azure DevOps, GitHub Actions, TeamCity, etc.

### 📄 License

[MIT License](LICENSE)

### 📄 Package Storage

[Versioning.Common Package](https://www.nuget.org/packages/Versioning.Common)
