using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfSimulator.Infrastructure;
using WpfSimulator.Services;

namespace WpfSimulator.ViewModels
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        private readonly IInspectionService _service;
        private readonly RelayCommand _startCommand;
        private readonly RelayCommand _stopCommand;
        private CancellationTokenSource _cancellation;
        private bool _isRunning;
        private int _totalCount;
        private int _okCount;
        private int _ngCount;

        public MainViewModel(IInspectionService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            LogEntries = new ObservableCollection<string>();
            _startCommand = new RelayCommand(_ => Start(), _ => !IsRunning);
            _stopCommand = new RelayCommand(_ => Stop(), _ => IsRunning);
            AddLog("独立模拟器已加载。未连接任何真实设备。");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> LogEntries { get; }
        public ICommand StartCommand => _startCommand;
        public ICommand StopCommand => _stopCommand;
        public string StatusText => IsRunning ? "模拟运行中" : "已停止";

        public bool IsRunning
        {
            get => _isRunning;
            private set
            {
                if (_isRunning == value) return;
                _isRunning = value;
                Notify();
                Notify(nameof(StatusText));
                _startCommand.RaiseCanExecuteChanged();
                _stopCommand.RaiseCanExecuteChanged();
            }
        }

        public int TotalCount { get => _totalCount; private set { _totalCount = value; Notify(); } }
        public int OkCount { get => _okCount; private set { _okCount = value; Notify(); } }
        public int NgCount { get => _ngCount; private set { _ngCount = value; Notify(); } }

        private void Start()
        {
            if (IsRunning) return;
            _cancellation?.Dispose();
            _cancellation = new CancellationTokenSource();
            IsRunning = true;
            AddLog("开始模拟检测。所有数值均为合成数据。");
            _ = RunLoopAsync(_cancellation.Token);
        }

        public void Stop()
        {
            if (!IsRunning) return;
            IsRunning = false;
            _cancellation?.Cancel();
            AddLog("停止请求已发送。");
        }

        private async Task RunLoopAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var result = await _service.InspectAsync(token);
                    if (token.IsCancellationRequested) break;
                    // Resume on WPF dispatcher context for bound collection updates.
                    TotalCount++;
                    if (result.IsOk) OkCount++; else NgCount++;
                    AddLog(string.Format("{0:HH:mm:ss} | {1} | {2} | 偏移 {3:F3} mm (模拟)",
                        result.Timestamp, result.Station, result.IsOk ? "OK" : "NG", result.SimulatedOffsetMm));
                }
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested)
            {
                // Operator-requested cancellation.
            }
            catch (Exception ex)
            {
                AddLog("模拟程序异常：" + ex.Message);
            }
            finally
            {
                // Prevent a previous loop from stopping a newer run.
                if (_cancellation != null && _cancellation.Token == token)
                    IsRunning = false;
            }
        }

        private void AddLog(string message)
        {
            LogEntries.Insert(0, "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message);
            while (LogEntries.Count > 150) LogEntries.RemoveAt(LogEntries.Count - 1);
        }

        private void Notify([CallerMemberName] string property = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
