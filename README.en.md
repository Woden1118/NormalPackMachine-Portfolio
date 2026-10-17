# NormalPack Studio

**Industrial Vision HMI · C# / WPF Engineering Showcase**

NormalPack Studio explores the design of Windows desktop software for automated packaging and visual inspection workflows. The focus is on **inspection orchestration, equipment status, production feedback, and operator interaction**, with attention to asynchronous execution, observable failures, and maintainable application structure.

C# · WPF · MVVM · .NET Framework 4.8 · PLC / OPC UA · Machine Vision

[中文介绍](README.md)

## Overview

An industrial vision HMI brings inspection tasks, equipment states, and production information into one desktop application. This repository presents an architectural overview of that workflow alongside a standalone WPF example for exploring the interaction patterns.

![Architecture overview](assets/architecture.svg)

## Engineering highlights

| Area | Focus |
| --- | --- |
| **WPF / MVVM** | Commands, data binding, property-change notifications, and separation of UI from state |
| **Asynchronous execution** | Task start/stop/cancellation with `async/await` and `CancellationToken` |
| **Inspection feedback** | Two-station status, OK/NG counters, and rolling operation logs |
| **Vision workflow** | Separation of acquisition, inspection, judgement, and result recording |
| **System integration** | Architectural boundaries for PLC / OPC UA communication, MES, and traceability |
| **Maintainability** | Thread safety, dependency compatibility, fault handling, and validation |

The **WPF interaction, task control, and result statistics** are covered by example code. **Vision algorithms, PLC connectivity, and MES coordination** are discussed as architecture concepts.

## WPF example

The [WpfSimulator](examples/WpfSimulator/) project demonstrates a branded splash screen, an operator dashboard, simulated inspection cycles, start/stop commands, and log updates.

- Alternating inspection cycles across two example stations
- OK/NG result statistics and activity logs
- Cancellation-aware background execution and UI state updates
- A dedicated inspection service interface and custom app icon

The example generates inspection data locally; no physical equipment is required.

## Run locally

**Requirements:** Windows, Visual Studio 2022, and the .NET Framework 4.8 Developer Pack.

1. Clone the repository.
2. Open `examples/WpfSimulator/WpfSimulator.csproj` in Visual Studio.
3. Build and launch with **Debug / Any CPU**.
4. Explore task status, simulated inspection results, and the activity log.

> Windows / VS2022 build and runtime validation is still pending. See the [validation checklist](docs/VALIDATION.md).

## Documentation

[Architecture](docs/ARCHITECTURE.md) · [Branding](docs/BRANDING.md) · [Validation](docs/VALIDATION.md) · [Publication checklist](docs/PUBLICATION-CHECKLIST.md)

## Scope

This repository focuses on reusable desktop-application patterns and industrial vision workflow design. Inspection data in the example is generated locally, while equipment integration is described at an architectural level. Deployment to production machinery requires separate hardware integration, licensed dependencies, and onsite validation.

No open-source license is included at this time.
