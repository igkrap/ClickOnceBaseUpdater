using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using ModuleContracts;

namespace MainApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppendLog("애플리케이션이 시작되었습니다.");
        }

        private void OnCheckUpdateClick(object sender, RoutedEventArgs e)
        {
            AppendLog("업데이트 확인 토스트를 표시합니다.");
            var toast = new UpdateToastWindow
            {
                Owner = this
            };

            var result = toast.ShowDialog();
            if (result == true)
            {
                AppendLog("사용자가 업데이트를 선택했습니다.");
                StartUpdaterAndExit();
            }
            else
            {
                AppendLog("사용자가 업데이트를 취소했습니다.");
            }
        }

        private void OnRunModuleClick(object sender, RoutedEventArgs e)
        {
            var modulePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules", "HelloModule.dll");
            if (!File.Exists(modulePath))
            {
                AppendLog($"모듈을 찾을 수 없습니다: {modulePath}");
                MessageBox.Show("Modules/HelloModule.dll을 출력 폴더에 복사해주세요.");
                return;
            }

            try
            {
                var assembly = Assembly.LoadFrom(modulePath);
                var moduleType = assembly.GetTypes()
                    .FirstOrDefault(type => typeof(IModule).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

                if (moduleType == null)
                {
                    AppendLog("IModule 구현체를 찾을 수 없습니다.");
                    return;
                }

                var module = (IModule)Activator.CreateInstance(moduleType);
                var result = module.Execute("MainApplication");
                AppendLog($"모듈 실행 결과: {result}");
                MessageBox.Show(result, module.Name);
            }
            catch (Exception ex)
            {
                AppendLog($"모듈 로드 실패: {ex.Message}");
                MessageBox.Show("모듈 로드에 실패했습니다.");
            }
        }

        private void StartUpdaterAndExit()
        {
            var updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater.exe");
            if (!File.Exists(updaterPath))
            {
                AppendLog("Updater.exe를 찾지 못했습니다.");
                MessageBox.Show("Updater.exe가 같은 폴더에 있어야 합니다.");
                return;
            }

            var mainExePath = Assembly.GetEntryAssembly()?.Location;
            var startInfo = new ProcessStartInfo
            {
                FileName = updaterPath,
                Arguments = mainExePath != null ? $"\"{mainExePath}\"" : string.Empty,
                UseShellExecute = false
            };

            Process.Start(startInfo);
            AppendLog("Updater를 실행하고 종료합니다.");
            Application.Current.Shutdown();
        }

        private void AppendLog(string message)
        {
            LogTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            LogTextBox.ScrollToEnd();
        }
    }
}
