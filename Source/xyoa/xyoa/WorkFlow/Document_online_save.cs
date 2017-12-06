namespace xyoa.WorkFlow
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web.UI;

    public class Document_online_save : Page
    {
        private readonly int enterCount = 12;
        private string[] requestValues = new string[2];

        protected void Page_Load(object sender, EventArgs e)
        {
            FileStream output = new FileStream(base.Server.MapPath(".") + @"\" + base.Request.QueryString["file"].Replace(@"\", @"\\") + "", FileMode.Create, FileAccess.Write);
            BinaryReader reader = new BinaryReader(base.Request.InputStream);
            BinaryWriter writer = new BinaryWriter(output);
            reader.BaseStream.Seek(0L, SeekOrigin.Begin);
            writer.BaseStream.Seek(0L, SeekOrigin.End);
            int num = 0;
            int num2 = 0;
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                num2++;
                char ch = (char) reader.ReadByte();
                if (num >= this.enterCount)
                {
                    break;
                }
                if (ch == '\n')
                {
                    num++;
                }
            }
            reader.BaseStream.Seek(0L, SeekOrigin.Begin);
            string str2 = Encoding.Default.GetString(reader.ReadBytes(num2 - 1));
            while (reader.BaseStream.Position < (reader.BaseStream.Length - 0x26L))
            {
                writer.Write(reader.ReadByte());
            }
            reader.Close();
            writer.Flush();
            writer.Close();
            string[] strArray = new string[] { "RecordID", "UserID" };
            for (int i = 0; i < strArray.Length; i++)
            {
                string str3 = "Content-Disposition: form-data; name=\"" + strArray[i] + "\"\r\n\r\n";
                int num4 = str2.IndexOf(str3) + str3.Length;
                if (num4 != (str3.Length - 1))
                {
                    for (int j = num4; j < str2.Length; j++)
                    {
                        string[] strArray2;
                        IntPtr ptr;
                        if (str2[j] == '\r')
                        {
                            break;
                        }
                        (strArray2 = this.requestValues)[(int) (ptr = (IntPtr) i)] = strArray2[(int) ptr] + str2[j];
                    }
                }
            }
        }
    }
}

