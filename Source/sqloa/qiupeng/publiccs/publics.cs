namespace qiupeng.publiccs
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Management;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class publics
    {
        private static string Key = "ABCDEGHIJKLMNPQRSTUVXYZ";
        private static byte[] Keys = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();

        public void addfenye(string yema)
        {
            string sql = "select fenye from qp_oa_fenye where username='" + HttpContext.Current.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "Update qp_oa_fenye  Set fenye='", yema, "'  where Username='", HttpContext.Current.Session["username"], "'" });
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = string.Concat(new object[] { "insert into qp_oa_fenye (fenye,username) values ('", yema, "','", HttpContext.Current.Session["username"], "')" });
                this.List.ExeSql(str3);
            }
            list.Close();
        }

        private void BindChild(string Table, string ParentID, string separator, DropDownList _DropDownList, string sql, string sort)
        {
            string str = "select id,Name from " + Table + " where ParentNodesID=" + ParentID + " " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item = new ListItem();
                item.Text = separator + list["Name"].ToString();
                item.Value = list["id"].ToString();
                _DropDownList.Items.Add(item);
                string str2 = separator + "---";
                this.BindChild(Table, list["id"].ToString(), str2, _DropDownList, sql, sort);
            }
            list.Close();
        }

        private void BindChildDesk(string Table, string ParentID, string separator, DropDownList _DropDownList, string sql, string sort)
        {
            string str = "select A.id,A.Name from " + Table + " where ParentNodesID=" + ParentID + " " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item = new ListItem();
                item.Text = separator + list["Name"].ToString();
                item.Value = list["id"].ToString();
                _DropDownList.Items.Add(item);
                string str2 = separator + "---";
                this.BindChildDesk(Table, list["id"].ToString(), str2, _DropDownList, sql, sort);
            }
            list.Close();
        }

        private void BindChildListBox(string Table, string ParentID, string separator, ListBox _DropDownList, string sql, string sort)
        {
            string str = "select id,Name from " + Table + " where ParentNodesID=" + ParentID + " " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item = new ListItem();
                item.Text = separator + list["Name"].ToString();
                item.Value = list["id"].ToString();
                _DropDownList.Items.Add(item);
                string str2 = separator + "---";
                this.BindChildListBox(Table, list["id"].ToString(), str2, _DropDownList, sql, sort);
            }
            list.Close();
        }

        public void BindListBm(string Table, DropDownList _DropDownList, string sql, string sort)
        {
            ListItem item = new ListItem();
            item.Text = "根节点";
            item.Value = "0";
            _DropDownList.Items.Add(item);
            string str = "select id,Name from " + Table + " where ParentNodesID=0 " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item2 = new ListItem();
                item2.Text = "|-" + list["Name"].ToString();
                item2.Value = list["id"].ToString();
                _DropDownList.Items.Add(item2);
                this.BindChild(Table, list["id"].ToString(), "|---", _DropDownList, sql, sort);
            }
            list.Close();
        }

        public void BindListBmDisk(string Table, DropDownList _DropDownList, string sql, string sort)
        {
            ListItem item = new ListItem();
            item.Text = "根节点";
            item.Value = "0";
            _DropDownList.Items.Add(item);
            string str = "select A.id,A.Name from " + Table + " where ParentNodesID=0 " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item2 = new ListItem();
                item2.Text = "|-" + list["Name"].ToString();
                item2.Value = list["id"].ToString();
                _DropDownList.Items.Add(item2);
                this.BindChildDesk(Table, list["id"].ToString(), "|---", _DropDownList, sql, sort);
            }
            list.Close();
        }

        public void BindListGd(string Table, DropDownList _DropDownList, string sql, string sort)
        {
            ListItem item = new ListItem();
            item.Text = "不归档";
            item.Value = "0";
            _DropDownList.Items.Add(item);
            string str = "select id,Name from " + Table + " where ParentNodesID=0 " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item2 = new ListItem();
                item2.Text = "|-" + list["Name"].ToString();
                item2.Value = list["id"].ToString();
                _DropDownList.Items.Add(item2);
                this.BindChild(Table, list["id"].ToString(), "|---", _DropDownList, sql, sort);
            }
            list.Close();
        }

        public void BindListkong(string Table, DropDownList _DropDownList, string sql, string sort)
        {
            ListItem item = new ListItem();
            item.Text = "";
            item.Value = "";
            _DropDownList.Items.Add(item);
            string str = "select id,Name from " + Table + " where ParentNodesID=0 " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item2 = new ListItem();
                item2.Text = "|-" + list["Name"].ToString();
                item2.Value = list["id"].ToString();
                _DropDownList.Items.Add(item2);
                this.BindChild(Table, list["id"].ToString(), "|---", _DropDownList, sql, sort);
            }
            list.Close();
        }

        public void BindListkongDisk(string Table, DropDownList _DropDownList, string sql, string sort)
        {
            ListItem item = new ListItem();
            item.Text = "";
            item.Value = "";
            _DropDownList.Items.Add(item);
            string str = "select A.id,A.Name from " + Table + " where ParentNodesID=0 " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item2 = new ListItem();
                item2.Text = "|-" + list["Name"].ToString();
                item2.Value = list["id"].ToString();
                _DropDownList.Items.Add(item2);
                this.BindChildDesk(Table, list["id"].ToString(), "|---", _DropDownList, sql, sort);
            }
            list.Close();
        }

        public void BindListListBox(string Table, ListBox _DropDownList, string sql, string sort)
        {
            string str = "select id,Name from " + Table + " where ParentNodesID=0 " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item = new ListItem();
                item.Text = "|-" + list["Name"].ToString();
                item.Value = list["id"].ToString();
                _DropDownList.Items.Add(item);
                this.BindChildListBox(Table, list["id"].ToString(), "|---", _DropDownList, sql, sort);
            }
            list.Close();
        }

        public void BindListNothing(string Table, DropDownList _DropDownList, string sql, string sort)
        {
            string str = "select id,Name from " + Table + " where ParentNodesID=0 " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item = new ListItem();
                item.Text = "|-" + list["Name"].ToString();
                item.Value = list["id"].ToString();
                _DropDownList.Items.Add(item);
                this.BindChild(Table, list["id"].ToString(), "|---", _DropDownList, sql, sort);
            }
            list.Close();
        }

        public void BindListNothingDisk(string Table, DropDownList _DropDownList, string sql, string sort)
        {
            string str = "select A.id,A.Name from " + Table + " where ParentNodesID=0 " + sql + " " + sort + "";
            SqlDataReader list = this.List.GetList(str);
            while (list.Read())
            {
                ListItem item = new ListItem();
                item.Text = "|-" + list["Name"].ToString();
                item.Value = list["id"].ToString();
                _DropDownList.Items.Add(item);
                this.BindChildDesk(Table, list["id"].ToString(), "|---", _DropDownList, sql, sort);
            }
            list.Close();
        }

        public string CheckBoxChange(string str)
        {
            if (str == "True")
            {
                str = "1";
                return str;
            }
            str = "0";
            return str;
        }

        public string CheckInt(string str)
        {
            if (str == "1")
            {
                str = "是";
                return str;
            }
            str = "否";
            return str;
        }

        public string CheckText(string str)
        {
            if (str == "True")
            {
                str = "是";
                return str;
            }
            str = "否";
            return str;
        }

        public string Daibanshiyi(string Name)
        {
            string str2;
            string str = "0";
            if (Name == "未读新闻")
            {
                str2 = "select count(id) from qp_oa_NewsMg where CHARINDEX('," + HttpContext.Current.Session["username"] + ",',','+YdUsername+',')   =0";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "未读消息")
            {
                str2 = "select count(id) from qp_oa_Messages where sfck='0' and acceptusername='" + HttpContext.Current.Session["username"] + "' and tablekey='1'";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "未读邮件")
            {
                str2 = "select count(id) from qp_oa_NbEmail_sj where  IfRead='0' and  IfDel='0' and  JsUsername='" + HttpContext.Current.Session["username"] + "'";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "文件接收")
            {
                str2 = string.Concat(new object[] { "select count(id) from qp_oa_InfoSend where  CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+JsUsername+',') > 0 and CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+YdUsername+',')   =0" });
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "今日日程")
            {
                str2 = string.Concat(new object[] { "select count(id) from qp_oa_MyRicheng where username='", HttpContext.Current.Session["username"], "'  and convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('", DateTime.Now.ToShortDateString(), "' as datetime),120)" });
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "今日会议")
            {
                str2 = string.Concat(new object[] { "select count(id) from qp_oa_MettingApply where  (State='2' or State='3'  or State='4' or State='5' ) and   CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+NbPeopleUser+',')   >   0   and convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('", DateTime.Now.ToShortDateString(), "' as datetime),120)" });
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "未读通知")
            {
                str2 = string.Concat(new object[] { "select count(id) from qp_oa_BumenNewsMg where  ((CHARINDEX(',", HttpContext.Current.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) and CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+YdUsername+',')   =0" });
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "部门主页")
            {
                str2 = string.Concat(new object[] { "select count(A.id) from [qp_oa_BumenWz] as [A] inner join [qp_oa_BumenZy] as [C] on [A].[ZhuyeId] = [C].[Id] inner join [qp_oa_Bumen] as [B] on [C].[BuMenId] = [B].[Id] inner join [qp_oa_BumenWzLb] as [D] on [A].[WzLeibie] = [D].[Id]  where ((CHARINDEX(',", HttpContext.Current.Session["BuMenId"], ",',','+C.ZdBumenId1+',') > 0 and C.States1='2') or (CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+C.ZdUsername1+',') > 0 and C.States1='3') or (C.States1='1')) and CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+A.YdUsername+',')   =0" });
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "会议审批")
            {
                str2 = "select count(id) from qp_oa_MettingApply where  CHARINDEX('," + HttpContext.Current.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "车辆审批")
            {
                str2 = "select count(A.id) from [qp_oa_CarApply] as [A] join [qp_oa_CarInfo] as [C] on [A].[CarId] = [C].id where CHARINDEX('," + HttpContext.Current.Session["username"] + ",',','+A.DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "计划监控")
            {
                str2 = string.Concat(new object[] { "select count(A.id) from [qp_oa_MyPlan] as [A] inner join [qp_oa_MyPlanLx] as [B] on [A].[Leixing] = [B].[Id] where 1=1 and  CHARINDEX(','+A.Username+',',','+(select RyUsername from qp_oa_MyPlanSz where ZgUsername='", HttpContext.Current.Session["username"], "')+',') > 0 and CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+YdUsername+',')   =0" });
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "日志批注")
            {
                str2 = string.Concat(new object[] { "select count(A.id) from [qp_oa_MyRizhi] as [A] inner join [qp_oa_RizhiLx] as [B] on [A].[LeiBie] = [B].[Id]  where CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_Rizhisz where ZgUsername='", HttpContext.Current.Session["username"], "')+',') > 0 and CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+YdUsername+',')   =0" });
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "任务监控")
            {
                int num = 0;
                string sql = string.Concat(new object[] { "select A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime, B.[name] as LeiBieName from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id] left join [qp_oa_RenwuXb] as [C] on [A].[id] = [C].[Keyid]  where ((CHARINDEX(','+A.ZbUsername+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='", HttpContext.Current.Session["username"], "')+',') > 0) or (CHARINDEX(','+C.Username+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='", HttpContext.Current.Session["username"], "')+',') > 0)) and CHARINDEX(',", HttpContext.Current.Session["username"], ",',','+YdUsername+',')   =0  group by  A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime,B.[name] " });
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    num++;
                }
                list.Close();
                str = "" + num + "";
            }
            if (Name == "待办流程")
            {
                str2 = "select count(A.id)  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile and [A].[UpNodeNum] = [C].xuhao and [A].[GlNum] = [C].GlNum where BLusername='" + HttpContext.Current.Session["username"] + "' and ((States='未接收' and State='正在办理') or (States='办理中' and State='正在办理')) and Ifdel='0'";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "物品购买审批")
            {
                str2 = "select count(A.id) from [qp_oa_ResGm] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + HttpContext.Current.Session["username"] + ",',','+A.DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "物品报废审批")
            {
                str2 = "select count(A.id) from [qp_oa_ResBf] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + HttpContext.Current.Session["username"] + ",',','+A.DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "物品借用审批")
            {
                str2 = "select count(A.id) from [qp_oa_ResAppJy] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + HttpContext.Current.Session["username"] + ",',','+A.DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "物品使用审批")
            {
                str2 = "select count(A.id) from [qp_oa_ResAppSy] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + HttpContext.Current.Session["username"] + ",',','+A.DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')";
                str = "" + this.List.GetCount(str2) + "";
            }
            if (Name == "物品维修审批")
            {
                str2 = "select count(A.id) from [qp_oa_ResWx] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + HttpContext.Current.Session["username"] + ",',','+A.DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')";
                str = "" + this.List.GetCount(str2) + "";
            }
            return str;
        }

        public bool delCookie(string strName)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(strName);
                cookie.Expires = DateTime.Now.AddDays(-1.0);
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string DESDecrypt(string encryptedValue, string key, string IV)
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

        public string DESEncrypt(string encryptStr, string key, string IV)
        {
            key = key + "12345678";
            IV = IV + "12345678";
            key = key.Substring(0, 8);
            IV = IV.Substring(0, 8);
            SymmetricAlgorithm algorithm = new DESCryptoServiceProvider();
            algorithm.Key = Encoding.UTF8.GetBytes(key);
            algorithm.IV = Encoding.UTF8.GetBytes(IV);
            ICryptoTransform transform = algorithm.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(encryptStr);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            string str = Convert.ToBase64String(stream.ToArray());
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                str = str.Substring(0, (2 * i) + 1) + Convert.ToChar((int) (random.Next(0x24) + 0x41)).ToString() + str.Substring((2 * i) + 1);
            }
            return str;
        }

        public string fenye()
        {
            string str = null;
            string sql = "select fenye from qp_oa_fenye where username='" + HttpContext.Current.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["fenye"].ToString();
            }
            else
            {
                str = "15";
            }
            list.Close();
            return str;
        }

        public string GetChecked(CheckBoxList checkList)
        {
            string str = "0,";
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].Selected)
                {
                    str = str + "" + checkList.Items[i].Value + ",";
                }
            }
            return (str + "0");
        }

        public string GetCheckedText(CheckBoxList checkList)
        {
            string str = "";
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].Selected)
                {
                    str = str + "" + checkList.Items[i].Text + ",";
                }
            }
            return str;
        }

        public string getCookie(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie != null)
            {
                return cookie.Value.ToString();
            }
            return null;
        }

        public void GetFile(string num, Label _Label)
        {
            string sql = "select  * from qp_oa_fileupload where KeyField='" + num + "' order by id desc";
            SqlDataReader list = this.List.GetList(sql);
            _Label.Text = null;
            int num2 = 0;
            _Label.Text = _Label.Text + "<table width=100% border=0 cellspacing=0 cellpadding=4>";
            _Label.Text = _Label.Text + "<tr>";
            while (list.Read())
            {
                string text = _Label.Text;
                _Label.Text = text + " <td width=100% ><img src=\"/oaimg/filetype/" + list["filetype"].ToString() + ".gif\" align=\"baseline\"/> <a href=/file_down.aspx?number=" + list["NewName"].ToString() + "  target=_blank>" + list["Name"].ToString() + "</a><a href='javascript:void(0)' onclick=\"fileadd('" + list["NewName"].ToString() + "')\" class=zccss>[转存]</a></td>";
                num2++;
                if (num2 == 1)
                {
                    _Label.Text = _Label.Text + "</tr><TR>";
                    num2 = 0;
                }
            }
            _Label.Text = _Label.Text + " </table>";
            list.Close();
        }

        public string GetFileBBS(string num)
        {
            string str = null;
            string sql = "select  * from qp_oa_fileupload where KeyField='" + num + "' order by id desc";
            SqlDataReader list = this.List.GetList(sql);
            int num2 = 0;
            str = str + "<table width=100% border=0 cellspacing=0 cellpadding=4>" + "<tr>";
            while (list.Read())
            {
                string str4 = str;
                str = str4 + " <td width=100% ><img src=\"/oaimg/filetype/" + list["filetype"].ToString() + ".gif\" align=\"baseline\"/> <a href=/file_down.aspx?number=" + list["NewName"].ToString() + "  target=_blank>" + list["Name"].ToString() + "</a><a href='javascript:void(0)' onclick=\"fileadd('" + list["NewName"].ToString() + "')\" class=zccss>[转存]</a></td>";
                num2++;
                if (num2 == 1)
                {
                    str = str + "</tr><TR>";
                    num2 = 0;
                }
            }
            str = str + " </table>";
            list.Close();
            return str;
        }

        public string GetFileNameName(string id)
        {
            string str = null;
            string sql = "select FormName from qp_oa_DIYForm   where  id in (" + id + "0)";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                str = str + "" + list["FormName"].ToString() + ",";
            }
            list.Close();
            return str;
        }

        public string GetFileNameNumber(string id)
        {
            string str = null;
            string sql = "select Number from qp_oa_DIYForm   where  id in (" + id + "0)";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                str = str + "'" + list["Number"].ToString() + "',";
            }
            list.Close();
            return (str + "'0'");
        }

        public void GetFileSj(string num, Label _Label)
        {
            string sql = "select  * from qp_oa_fileupload where KeyField='" + num + "' order by id desc";
            SqlDataReader list = this.List.GetList(sql);
            _Label.Text = null;
            int num2 = 0;
            _Label.Text = _Label.Text + "<table width=100% border=0 cellspacing=0 cellpadding=4>";
            _Label.Text = _Label.Text + "<tr>";
            while (list.Read())
            {
                string text = _Label.Text;
                _Label.Text = text + " <td width=100% ><img src=\"/oaimg/filetype/" + list["filetype"].ToString() + ".gif\" align=\"baseline\"/> <a href=/file_down.aspx?number=" + list["NewName"].ToString() + "  target=_blank>" + list["Name"].ToString() + "</a></td>";
                num2++;
                if (num2 == 1)
                {
                    _Label.Text = _Label.Text + "</tr><TR>";
                    num2 = 0;
                }
            }
            _Label.Text = _Label.Text + " </table>";
            list.Close();
        }

        public string Getfiletype(string rightName)
        {
            string str = null;
            string sql = "select * from qp_oa_filetype   where name='" + rightName + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["name"].ToString().Replace(".", "");
            }
            else
            {
                str = "unknow";
            }
            list.Close();
            return str;
        }

        public string GetFormatStr(string AStr)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("<", "〈");
            AStr = AStr.Replace(">", "〉");
            AStr = AStr.Replace("'", "’");
            AStr = AStr.Trim();
            return AStr;
        }

        public string GetFormatStrbjq(string AStr)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("'", "’");
            return AStr;
        }

        public string GetFormatStrbjq_show(string AStr)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("’", "'");
            return AStr;
        }

        public string GetFormatStrmb(string AStr)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("'", "’");
            return AStr;
        }

        public string GetGongZuoLiu(string strname)
        {
            string str = "";
            if (strname == "1")
            {
                str = "合同订单";
            }
            if (strname == "2")
            {
                str = "销售出库";
            }
            if (strname == "3")
            {
                str = "采购入库";
            }
            if (strname == "4")
            {
                str = "库存盘点";
            }
            if (strname == "5")
            {
                str = "销售费用";
            }
            if (strname == "6")
            {
                str = "采购订单";
            }
            if (strname == "7")
            {
                str = "合同流程";
            }
            if (strname == "8")
            {
                str = "会议申请流程";
            }
            if (strname == "9")
            {
                str = "用车申请流程";
            }
            if (strname == "10")
            {
                str = "手机短信申请流程";
            }
            if (strname == "11")
            {
                str = "物品购买申请流程";
            }
            if (strname == "12")
            {
                str = "物品报废申请流程";
            }
            if (strname == "13")
            {
                str = "物品借用申请流程";
            }
            if (strname == "14")
            {
                str = "物品使用申请流程";
            }
            if (strname == "15")
            {
                str = "物品维修申请流程";
            }
            if (strname == "16")
            {
                str = "出差管理流程";
            }
            if (strname == "17")
            {
                str = "休假管理流程";
            }
            if (strname == "18")
            {
                str = "加班管理流程";
            }
            if (strname == "19")
            {
                str = "报价审批流程";
            }
            if (strname == "20")
            {
                str = "投诉办理流程";
            }
            if (strname == "21")
            {
                str = "客服办理流程";
            }
            if (strname == "22")
            {
                str = "维修工单";
            }
            if (strname == "23")
            {
                str = "生产领料流程";
            }
            if (strname == "24")
            {
                str = "生产退料流程";
            }
            if (strname == "25")
            {
                str = "生产完工流程";
            }
            if (strname == "26")
            {
                str = "采购计划流程";
            }
            if (strname == "27")
            {
                str = "完工入库流程";
            }
            if (strname == "28")
            {
                str = "工程垫支流程";
            }
            if (strname == "29")
            {
                str = "支出申请流程";
            }
            if (strname == "30")
            {
                str = "材料预算流程";
            }
            if (strname == "31")
            {
                str = "采购计划流程";
            }
            if (strname == "32")
            {
                str = "采购订单流程";
            }
            if (strname == "33")
            {
                str = "材料入库流程";
            }
            if (strname == "34")
            {
                str = "材料领用流程";
            }
            if (strname == "35")
            {
                str = "材料调拨流程";
            }
            if (strname == "36")
            {
                str = "材料盘点流程";
            }
            if (strname == "37")
            {
                str = "运输车辆流程";
            }
            if (strname == "38")
            {
                str = "外包机械流程";
            }
            if (strname == "39")
            {
                str = "租赁材料流程";
            }
            if (strname == "40")
            {
                str = "设备领用流程";
            }
            if (strname == "41")
            {
                str = "设备归还流程";
            }
            if (strname == "42")
            {
                str = "资质领用流程";
            }
            if (strname == "43")
            {
                str = "资质归还流程";
            }
            if (strname == "44")
            {
                str = "甲供材料流程";
            }
            if (strname == "45")
            {
                str = "材料退库流程";
            }
            if (strname == "46")
            {
                str = "材料报损流程";
            }
            if (strname == "47")
            {
                str = "材料退货流程";
            }
            if (strname == "48")
            {
                str = "收入申请流程";
            }
            return str;
        }

        public string GetHeadBackColor()
        {
            if (HttpContext.Current.Session["yangshi"].ToString() == "NewStyleQian")
            {
                return "#454545";
            }
            return "#ffffff";
        }

        public string GetMAC()
        {
            string wK = null;
            wK = this.GetWK();
            return this.md5(wK, 0x20);
        }

        public string GetSms()
        {
            string str = null;
            string sql = "select * from qp_oa_smssy";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = "0," + list["content"].ToString() + "";
            }
            else
            {
                str = "0";
            }
            list.Close();
            return str;
        }

        public string GetWK()
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
            return str.Replace(" ", "").Replace("-", "").Replace(":", "");
        }

        public string Getyangshi()
        {
            string str = null;
            string sql = "select * from qp_oa_yangshi where Username='" + HttpContext.Current.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["name"].ToString();
            }
            else
            {
                str = "bluecss";
            }
            list.Close();
            return str;
        }

        public void Insertfile(string Name, string NewName, string KeyField, string filetype)
        {
            string sql = "insert into qp_oa_fileupload   (Name,NewName,KeyField,filetype) values ('" + this.GetFormatStr(Name) + "','" + NewName + "','" + KeyField + "','" + filetype + "')";
            this.List.ExeSql(sql);
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,BuMenId) values ('", Name, "','", MkName, "','", HttpContext.Current.Session["username"], "','", HttpContext.Current.Session["realname"], "','", DateTime.Now.ToString(), "','", HttpContext.Current.Request.UserHostAddress, "','", HttpContext.Current.Session["BuMenId"], "')" });
            this.List.ExeSql(sql);
        }

        public void InsertMessage(string titles, string acceptusername, string acceptrealname, string url)
        {
            Random random = new Random();
            string str = random.Next(0x2710).ToString();
            string str2 = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_Messages  (titles,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number,tablekey) values ('", titles, "','", DateTime.Now.ToString(), "','", acceptusername, "','", acceptrealname, "','", HttpContext.Current.Session["username"], "','", HttpContext.Current.Session["realname"], "','0','", url, "','", str2, 
                "','1')"
             });
            this.List.ExeSql(sql);
            string str4 = string.Concat(new object[] { 
                "insert into qp_oa_Messages  (titles,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number,tablekey) values ('", titles, "','", DateTime.Now.ToString(), "','", acceptusername, "','", acceptrealname, "','", HttpContext.Current.Session["username"], "','", HttpContext.Current.Session["realname"], "','0','", url, "','", str2, 
                "','2')"
             });
            this.List.ExeSql(str4);
        }

        public void InsertNaoZhong(string titles, string txtime, string Types, string NbSms, string SjSms, string LjUrl)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_Naozhong (titles,txtime,Types,Iftx,NbSms,SjSms,Username,LjUrl) values ('", titles, "','", txtime, "','", Types, "','0','", NbSms, "','", SjSms, "','", HttpContext.Current.Session["username"], "','", LjUrl, "')" });
            this.List.ExeSql(sql);
        }

        public void InsertNaoZhongSd(string titles, string txtime, string Types, string NbSms, string SjSms, string LjUrl, string User)
        {
            string sql = "insert into qp_oa_Naozhong (titles,txtime,Types,Iftx,NbSms,SjSms,Username,LjUrl) values ('" + titles + "','" + txtime + "','" + Types + "','0','" + NbSms + "','" + SjSms + "','" + User + "','" + LjUrl + "')";
            this.List.ExeSql(sql);
        }

        public void InsertSms(string MoveTel, string Msg)
        {
            if (MoveTel.Trim() != "")
            {
                string sql = string.Concat(new object[] { "insert into send_info   (s_mob,s_com,s_info,s_style,s_time,s_sendtime,s_userid,s_Client,s_Inputtime,s_realname) values ('", MoveTel, "','1','", Msg, "','0','", DateTime.Now.ToString(), "','','", HttpContext.Current.Session["username"], "','','", DateTime.Now.ToString(), "','", HttpContext.Current.Session["realname"], "')" });
                this.List.ExeSql(sql);
            }
        }

        public void InsertSmsSj(string MoveTel, string Msg, string Shijian)
        {
            if (MoveTel.Trim() != "")
            {
                if (HttpContext.Current.Session["duanxin"].ToString() == "1")
                {
                    string sql = string.Concat(new object[] { "insert into send_info   (s_mob,s_com,s_info,s_style,s_time,s_sendtime,s_userid,s_Client,s_Inputtime,s_realname) values ('", MoveTel, "','1','", Msg, "','0','", Shijian, "','','", HttpContext.Current.Session["username"], "','','", DateTime.Now.ToString(), "','", HttpContext.Current.Session["realname"], "')" });
                    this.List.ExeSql(sql);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language=javascript>alert('手机短信未开通');</script>");
                }
            }
        }

        public void InsertSmsSjUser(string MoveTel, string Msg, string Shijian, string s_userid, string s_realname)
        {
            if (MoveTel.Trim() != "")
            {
                if (HttpContext.Current.Session["duanxin"].ToString() == "1")
                {
                    string sql = "insert into send_info   (s_mob,s_com,s_info,s_style,s_time,s_sendtime,s_userid,s_Client,s_Inputtime,s_realname) values ('" + MoveTel + "','1','" + Msg + "','0','" + Shijian + "','','" + s_userid + "','','" + DateTime.Now.ToString() + "','" + s_realname + "')";
                    this.List.ExeSql(sql);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language=javascript>alert('手机短信未开通');</script>");
                }
            }
        }

        public bool ipquanstr(string Str1, string Str2)
        {
            if (Str2 != "*")
            {
                if (Str2.IndexOf(Str1) < 0)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public string JiFenDengji(string Username)
        {
            string str = null;
            string sql = "select top 18 jifen,username,realname from qp_oa_username where username='" + Username + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str3 = string.Concat(new object[] { "select dengji from qp_oa_Zst_dengji where  ", list["jifen"], ">=Fenshu1 and  ", list["jifen"], "<=Fenshu2" });
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    str = "d_" + reader2["dengji"] + ".gif";
                }
                reader2.Close();
            }
            list.Close();
            return str;
        }

        public string JifenGuize(string Leibie)
        {
            string str = null;
            string sql = "select * from qp_oa_Zst_guize where Leibie='" + Leibie + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["gongsi"].ToString() + list["Fenshu"].ToString();
            }
            list.Close();
            return str;
        }

        public string md5(string str, int code)
        {
            if (code == 0x10)
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 0x10);
            }
            if (code == 0x20)
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            }
            return "00000000000000000000000000000000";
        }

        public string pdafoot(string str)
        {
            string str2 = null;
            return ((str2 + "<li><a href=\"javascript:void(0)\" onclick=\"LoadingShow();location.href='" + str + "';\"><img src=\"/pda/images/2.png\" width=\"20\" height=\"19\" border=\"0\">刷新</a></li>") + "<li><a href=\"javascript:void(0)\" onclick=\"LoadingShow();location.href='/pda/LogOut.aspx';\"><img src=\"/pda/images/4.png\" width=\"20\" height=\"19\" border=\"0\">退出</a></li>");
        }

        public string pdamain(string str)
        {
            string str2 = null;
            string sql = "select " + str + " from qp_pda_SysMk";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str2 = list["" + str + ""].ToString();
            }
            list.Close();
            return str2;
        }

        public string pdauser()
        {
            string str = null;
            string sql = "select A.id,A.Username, A.Realname from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0' order by A.paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                object obj2 = str;
                str = string.Concat(new object[] { obj2, "<li><input name=\"test\" type=\"checkbox\"  value=\"", list["Username"], "|", list["Realname"], "\"/>", list["Realname"], "</li>" });
            }
            list.Close();
            return str;
        }

        public void QuanXianBack(string qxname, string qxstr)
        {
            if (!this.StrIFInStr(qxname, qxstr))
            {
                HttpContext.Current.Response.Redirect("/erqx.aspx");
            }
        }

        public void QuanXianVis(Control ctl, string qxname, string qxstr)
        {
            if (!this.StrIFInStr(qxname, qxstr))
            {
                ctl.Visible = false;
            }
            else
            {
                ctl.Visible = true;
            }
        }

        public bool scquanstr(string Str1, string Str2)
        {
            if (Str2 != "*")
            {
                if (Str2.IndexOf(Str1) < 0)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public string SetChecked(CheckBoxList checkList, string selval)
        {
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                checkList.Items[i].Selected = false;
                string str = "," + checkList.Items[i].Value + ",";
                if (selval.IndexOf(str) != -1)
                {
                    checkList.Items[i].Selected = true;
                }
            }
            return selval;
        }

        public bool setCookie(string strName, string strValue, int strDay)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(strName);
                cookie.Expires = DateTime.Now.AddDays((double) strDay);
                cookie.Value = HttpContext.Current.Server.UrlEncode(strValue);
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ShowDateTime(double strSecond)
        {
            string str = string.Empty;
            if (strSecond >= 0.0)
            {
                long num = Convert.ToInt64(strSecond);
                str = string.Concat(new object[] { num / 0x15180L, "天", (num % 0x15180L) / 0xe10L, "小时", ((num % 0x15180L) % 0xe10L) / 60L, "分钟", (((num % 0x15180L) % 0xe10L) % 60L) % 60L, "秒" });
            }
            return str;
        }

        public void SpInsertLog(string BuZhouName, string GlNumber, string Yijian, string Username, string Realname, string Zhuangtai, string GlNum, string CaoZuo, string Endtime, string Leixing)
        {
            string sql = "insert into qp_Pro_WorkFlowMsg (BuZhouName,GlNumber,Yijian,Username,Realname,Zhuangtai,Starttime,Endtime,GlNum,CaoZuo,Leixing) values ('" + BuZhouName + "','" + GlNumber + "','" + Yijian + "','" + Username + "','" + Realname + "','" + Zhuangtai + "','" + DateTime.Now.ToString() + "','" + Endtime + "','" + GlNum + "','" + CaoZuo + "','" + Leixing + "')";
            this.List.ExeSql(sql);
        }

        public void SpUpdateLog(string GlNumber, string Yijian, string Zhuangtai, string GlNum, string CaoZuo, string Endtime)
        {
            string str;
            if (Zhuangtai == "2")
            {
                str = "Update qp_Pro_WorkFlowMsg  Set  Zhuangtai='" + Zhuangtai + "',CaoZuo='" + CaoZuo + "',Endtime='" + Endtime + "' where GlNumber='" + GlNumber + "' and  GlNum='" + GlNum + "'";
                this.List.ExeSql(str);
            }
            else if (Yijian.Trim() != "")
            {
                str = string.Concat(new object[] { 
                    "Update qp_Pro_WorkFlowMsg  Set  Yijian=Yijian+'", Yijian, "(", HttpContext.Current.Session["realname"], "-", DateTime.Now.ToString(), ")<br>',Realname=replace(Realname,'", HttpContext.Current.Session["realname"], "','<font color=\"blue\">", HttpContext.Current.Session["realname"], "(", DateTime.Now.ToString(), ")</font>'),Zhuangtai='", Zhuangtai, "',CaoZuo='", CaoZuo, 
                    "',Endtime='", Endtime, "' where GlNumber='", GlNumber, "' and  GlNum='", GlNum, "'"
                 });
                this.List.ExeSql(str);
            }
            else
            {
                str = string.Concat(new object[] { 
                    "Update qp_Pro_WorkFlowMsg  Set  Realname=replace(Realname,'", HttpContext.Current.Session["realname"], "','<font color=\"blue\">", HttpContext.Current.Session["realname"], "(", DateTime.Now.ToString(), ")</font>'),Zhuangtai='", Zhuangtai, "',CaoZuo='", CaoZuo, "',Endtime='", Endtime, "' where GlNumber='", GlNumber, "' and  GlNum='", GlNum, 
                    "'"
                 });
                this.List.ExeSql(str);
            }
        }

        public bool StrCheckRight(string str)
        {
            if (str == ".asp")
            {
                return false;
            }
            if (str == ".cer")
            {
                return false;
            }
            if (str == ".asa")
            {
                return false;
            }
            if (str == ".cdx")
            {
                return false;
            }
            if (str == ".htr")
            {
                return false;
            }
            if (str == ".cgi")
            {
                return false;
            }
            if (str == ".aspx")
            {
                return false;
            }
            if (str == ".asp.jpg")
            {
                return false;
            }
            if (str == ".cer.jpg")
            {
                return false;
            }
            if (str == ".asa.jpg")
            {
                return false;
            }
            if (str == ".cdx.jpg")
            {
                return false;
            }
            if (str == ".htr.jpg,")
            {
                return false;
            }
            if (str == ".cgi.jpg")
            {
                return false;
            }
            if (str == ".aspx.jpg")
            {
                return false;
            }
            return true;
        }

        public bool StrIFInStr(string Str1, string Str2)
        {
            if (Str2.IndexOf(Str1) < 0)
            {
                return false;
            }
            return true;
        }

        public string SystemCode(string FieldName, string CodeId)
        {
            string str = null;
            string sql = "select * from SystemCode where FieldName='" + FieldName + "' and  CodeId='" + CodeId + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["CodeName"].ToString();
            }
            list.Close();
            return str;
        }

        public string TbToLb(string AStr)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("\n", "<br>");
            AStr = AStr.Replace(" ", "&nbsp;&nbsp;");
            return AStr;
        }

        public void ToExcel(Control ctl, string FileName)
        {
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            ctl.Page.EnableViewState = false;
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            ctl.RenderControl(writer2);
            HttpContext.Current.Response.Write(writer.ToString());
            HttpContext.Current.Response.End();
        }

        public void ToExcelChe(Control ctl, string FileName)
        {
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("" + FileName + ".xls", Encoding.UTF8) + "");
            ctl.Page.EnableViewState = false;
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            ctl.RenderControl(writer2);
            HttpContext.Current.Response.Write(writer.ToString());
            HttpContext.Current.Response.End();
        }

        public void ToWordChe(Control ctl, string FileName)
        {
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            HttpContext.Current.Response.ContentType = "application/ms-word";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("" + FileName + ".doc", Encoding.UTF8) + "");
            ctl.Page.EnableViewState = false;
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            ctl.RenderControl(writer2);
            HttpContext.Current.Response.Write(writer.ToString());
            HttpContext.Current.Response.End();
        }

        public string TypeCode(string Table, string CodeId)
        {
            string str = null;
            string sql = "select Name from " + Table + " where id='" + CodeId + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Name"].ToString();
            }
            list.Close();
            return str;
        }

        public string TypeCodeAll(string KeyData, string Table, string CodeId)
        {
            string str = null;
            string sql = "select " + KeyData + " from " + Table + " where id='" + CodeId + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["" + KeyData + ""].ToString();
            }
            list.Close();
            return str;
        }
    }
}

