using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Updater
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            Console.WriteLine("Updater 시작");
            Thread.Sleep(2000);
            Console.WriteLine("업데이트 작업을 수행했습니다 (샘플)." );

            var mainExePath = args.Length > 0 ? args[0] : null;
            if (!string.IsNullOrWhiteSpace(mainExePath) && File.Exists(mainExePath))
            {
                Console.WriteLine("메인 애플리케이션 재실행: " + mainExePath);
                Process.Start(new ProcessStartInfo
                {
                    FileName = mainExePath,
                    UseShellExecute = false
                });
            }
            else
            {
                Console.WriteLine("메인 애플리케이션 경로가 전달되지 않았습니다.");
            }

            return 0;
        }
    }
}
