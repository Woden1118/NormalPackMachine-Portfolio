# NormalPackMachine Portfolio — Industrial Vision WPF Showcase

This is a **sanitized, independently authored portfolio**, not production-machine source code. It demonstrates general engineering approaches to a Windows industrial HMI, with a **from-scratch WPF simulator** using synthetic data and no actual hardware connections.

**Stack represented:** C#, WPF, MVVM, .NET Framework 4.8, industrial vision and PLC / OPC UA / MES integration concepts.

## Included

- An independent WPF simulation example for inspection counts, Start/Stop commands, cancellation, notifications and log display.
- Abstract architecture notes, validation checklist and release-safety guidance.
- A custom NormalPack app icon and splash screen.
- No production code, private DLLs, recipes, customer configurations, device addresses, licenses, passwords, production data or original Git history.

## Run the simulator

Open [examples/WpfSimulator/WpfSimulator.csproj](examples/WpfSimulator/WpfSimulator.csproj) in Visual Studio 2022 on Windows with the .NET Framework 4.8 Developer Pack. No camera, PLC, HALCON or commercial SDK is required.

**Verification:** This portfolio has not yet been compiled or run under Windows/Visual Studio 2022. The simulator is educational and not suitable for industrial production.

See [README in Chinese](README.md), [architecture notes](docs/ARCHITECTURE.md), and [verification](docs/VALIDATION.md). Claims about actual contributions and outcomes should be independently verified before including them in a résumé.
