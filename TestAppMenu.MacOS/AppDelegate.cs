using System;
using AppKit;
using Foundation;

namespace TestAppMenu.MacOS
{

    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.MacOS.FormsApplicationDelegate
    {
        NSWindow window;
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 600, 500);
            window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            window.Title = "Xamarin.Forms on Mac!";
            window.TitleVisibility = NSWindowTitleVisibility.Visible;
        }

        public override NSWindow MainWindow
        {
            get { return window; }
        }


        public override void DidFinishLaunching(NSNotification notification)
        {
            NSApplication.SharedApplication.MainMenu = MakeMainMenu();

            Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            base.DidFinishLaunching(notification);
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        private NSMenu MakeMainMenu()
        {
            // top bar app menu
            NSMenu menubar = new NSMenu();
            NSMenuItem appMenuItem = new NSMenuItem();
            menubar.AddItem(appMenuItem);

            NSMenu appMenu = new NSMenu();
            appMenuItem.Submenu = appMenu;

            // add separator
            NSMenuItem separator = NSMenuItem.SeparatorItem;
            appMenu.AddItem(separator);

            // add quit menu item
            string quitTitle = String.Format("Quit {0}", "TestAppMenu");
            var quitMenuItem = new NSMenuItem(quitTitle, "q", delegate
            {
                NSApplication.SharedApplication.Terminate(menubar);
            });
            appMenu.AddItem(quitMenuItem);

            return menubar;
        }


    }
}
