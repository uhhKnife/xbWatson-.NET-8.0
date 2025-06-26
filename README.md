# xbWatson (.NET 8.0)

Decompilation of xbWatson included in the Xbox 360 SDK, rebuilt for .NET 8.0 with modern WinForms support.

---

## Table of Contents
- [Requirements](#requirements)
- [Build Instructions](#build-instructions)
- [Publish Standalone EXE](#publish-standalone-exe)
- [Features](#features)
- [Notes](#notes)

---

## Requirements

- **Visual Studio 2022**
- **.NET 8.0 SDK**
- **Windows 10/11**

## Build Instructions

1. Open the solution (`xbWatson.sln`) in **Visual Studio 2022**.
2. Ensure the target framework is set to **.NET 8.0**.
3. Build the solution in **Release** mode.
4. The output will be located in `bin\Release\net8.0-windows8.0`.

## Publish Standalone EXE

To create a single-file standalone executable, run the following command in **Developer PowerShell for VS 2022**:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true
```

## Features
- Modernized for .NET 8.0 and WinForms
- Compatible with modern Windows versions
- Intended for use with Xbox 360 developer consoles for log monitoring and debugging

## Notes
- Based on the original xbWatson tool bundled with the Xbox 360 XDK.
- For use with developer/rgh/jtag consoles only.

---

## Disclaimer

This software is provided **for educational purposes only**. It is not affiliated with or endorsed by any company or trademark holder. All trademarks and copyrights belong to their respective owners.
