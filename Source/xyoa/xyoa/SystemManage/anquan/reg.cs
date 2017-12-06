namespace xyoa.SystemManage.anquan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.IO;
    using System.Management;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class reg : Page
    {
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private static string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox TextBox1;
        protected TextBox TextBox2;

        protected void Button3_Click1(object sender, EventArgs e)
        {
            try
            {
                string str = null;
                str = DESDecrypt(this.TextBox1.Text, "5", "6");
                ArrayList list = new ArrayList();
                string[] strArray = str.Split(new char[] { '^' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    string str2 = "" + strArray[0] + "";
                    string str3 = "" + strArray[1] + "";
                    string str4 = "" + strArray[2] + "";
                    string str5 = "" + strArray[3] + "";
                    string sql = "Update qp_oa_filemain set cdkstr='" + this.TextBox1.Text + "',reg='2'";
                    this.List.ExeSql(sql);
                }
                base.Response.Write("<script language=javascript>alert('恭喜您，注册成功！');window.parent.location = '/main.aspx'</script>");
            }
            catch
            {
                base.Response.Write("<script>alert('注册失败，请检查序列号是否有效！');</Script>");
            }
        }

        public static string DESDecrypt(string encryptedValue, string key, string IV)
        {
            string str = encryptedValue;
            if (str.Length < 0x18)
            {
                return "";
            }
            for (int i = 0; i < 3; i++)
            {
                str = str.Substring(0, i + 1) + str.Substring(i + 2);
            }
            encryptedValue = str;
            key = key + "12345678";
            IV = IV + "12345678";
            key = key.Substring(0, 8);
            IV = IV.Substring(0, 8);
            try
            {
                SymmetricAlgorithm algorithm = new DESCryptoServiceProvider();
                algorithm.Key = Encoding.UTF8.GetBytes(key);
                algorithm.IV = Encoding.UTF8.GetBytes(IV);
                ICryptoTransform transform = algorithm.CreateDecryptor();
                byte[] buffer = Convert.FromBase64String(encryptedValue);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string GetCPU()
        {
            string str = null;
            ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                str = obj2["ProcessorId"].ToString();
            }
            return str;
        }

        private string GetMAC()
        {
            string str = null;
            ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                if ((bool) obj2["IPEnabled"])
                {
                    str = obj2["MacAddress"].ToString();
                }
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.TextBox2.Text = "" + this.GetCPU() + "" + this.GetMAC().Replace(":", "") + "";
                }
                this.Button3.Attributes["onclick"] = "javascript:return CheckForm();";
            }
        }
    }
}

