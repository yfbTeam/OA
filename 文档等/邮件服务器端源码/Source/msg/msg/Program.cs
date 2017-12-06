namespace msg
{
    using System;
    using System.Windows.Forms;

    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new msg());
        }
    }
}

