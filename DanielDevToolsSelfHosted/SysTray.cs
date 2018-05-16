using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanielDevToolsSelfHosted
{
    public class SysTrayApp : Form
    {
        private readonly NotifyIcon _trayIcon;

        public SysTrayApp()
        {
            var trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("AppLogg", OnNavigateToAppLog);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", OnExit);

            _trayIcon = new NotifyIcon
            {
                Text = "Daniel Dev Tools",
                Icon = new Icon("favicon.ico", 40, 40),
                ContextMenu = trayMenu,
                Visible = true
            };

            StartServer();
        }

        private void OnNavigateToAppLog(object sender, EventArgs e)
        {
            GoToAppLog();
        }

        private void StartServer()
        {
            var cassiniDevServer = new CassiniDev.CassiniDevServer();
            cassiniDevServer.StartServer("C:\\X\\KK\\AppLogg\\AppLogg.Web\\bin\\Release\\PublishOutput");
            GoToAppLog();
        }

        private void GoToAppLog()
        {
            System.Diagnostics.Process.Start("http://localhost:8000");
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing) _trayIcon.Dispose();

            base.Dispose(isDisposing);
        }
    }
}