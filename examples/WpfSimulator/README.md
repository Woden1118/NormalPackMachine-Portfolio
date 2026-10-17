# WPF 工业检测模拟器（独立原创示例）

用于演示 C# WPF、MVVM、异步任务、取消令牌和 UI 属性绑定的最小上位机案例。

- **技术：** .NET Framework 4.8、WPF、INotifyPropertyChanged、ICommand、async/await、CancellationToken。
- **模拟：** 双工位交替检测、随机 OK/NG、统计计数、滚动日志。
- **资源：** 独立设计的 `Assets/NormalPack.ico` 图标，`SplashWindow.xaml` 启动画面。
- **运行：** Windows + Visual Studio 2022 + .NET Framework 4.8 Developer Pack；打开 `WpfSimulator.csproj`。
- **限制：** 不涉及 HALCON、工业相机、PLC、OPC UA、MES、MySQL 或现场设备通讯；不得用于生产。
- **验证：** 当前尚未完成 Windows 环境构建，详见 [验证清单](../../docs/VALIDATION.md)。

首次打开时，启动窗口仅显示约 1.5 秒，然后进入模拟控制台。按“启动模拟”开始合成检测，按“停止模拟”发送取消请求。
