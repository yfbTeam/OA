namespace xyoa.HumanResources.ZhaoPin.LuYong
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class LuYong_add : Page
    {
        protected DropDownList Bumen;
        protected Button Button1;
        protected CheckBox CheckBox2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Hunyin;
        protected RadioButtonList Iflogin;
        protected DropDownList JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected TextBox Number;
        protected TextBox Password;
        private publics pulicss = new publics();
        protected TextBox SetTimes;
        protected TextBox Username;
        protected RadioButtonList Xingbie;
        protected TextBox Xingming;
        protected TextBox Xingmingid;
        protected DropDownList Zhiwei;

        public void BindAttribute()
        {
            this.Xingming.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_LuYong  (Xingming,Bumen,Zhiwei,Neirong,Username,Realname,SetTimes) values ('" + this.Xingming.Text + "','" + this.Bumen.SelectedValue + "','" + this.Zhiwei.SelectedValue + "','" + this.pulicss.GetFormatStrbjq(this.Neirong.Value) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + this.SetTimes.Text + "')";
            this.List.ExeSql(sql);
            string str2 = "Update qp_hr_JianLi Set Zhuangtai='2' where id='" + this.Xingmingid.Text + "'";
            this.List.ExeSql(str2);
            if (this.CheckBox2.Checked)
            {
                this.UserAdd();
                string str3 = "insert into qp_hr_Yuangong  (Jiangcheng,Chuanzhen,Shouji,QQ,MSN,Neibu,Youbian,Username,Xiangpian,Xingming,Bianhao,Xingbie,Chusheng,Mingzhu,Jiguan,Mianmao,Hunyin,Xuexi,Yuanxiao,Zhuanye,Shenfenzheng,Hukou,Jiating,Youxiang,Dizhi,Bumen,Leixing,Zhiwei,Zhicheng,CjShijian,JrShijian,Shehui,GzJingli,XxJingli,Jineng,Tijian,Beizhu,Zaizhi) values ('','','','','','','','" + this.Username.Text + "','/HumanResources/Employee/Yuangong/file/0.jpg','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','','" + this.Xingbie.SelectedValue + "','','','','','" + this.Hunyin.SelectedValue + "','','','','','','','','','" + this.Bumen.SelectedValue + "','','" + this.Zhiwei.SelectedValue + "','','','','','','','','','','1')";
                this.List.ExeSql(str3);
            }
            this.pulicss.InsertLog("新增正式录用", "正式录用");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='LuYong.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_Juese order by id asc";
                this.list.Bind_DropDownList_nothing(this.JueseId, sQL, "id", "name");
                this.pulicss.BindListkong("qp_oa_Bumen", this.Bumen, "", "order by Bianhao asc");
                string str2 = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, str2, "id", "name");
                string sql = "select * from qp_hr_MoBanZp  where Types='3'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Neirong.Value = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                }
                list.Close();
                this.SetTimes.Text = DateTime.Now.ToShortDateString();
                this.BindAttribute();
            }
        }

        public void UserAdd()
        {
            if (int.Parse(this.Session["cdk4"].ToString()) < 500)
            {
                string str = "select count(id) from  qp_oa_username where Iflogin='1'";
                if (this.List.GetCount(str) >= int.Parse(this.Session["cdk4"].ToString()))
                {
                    base.Response.Write("<script>alert('您当前版本，软件使用人数限制为" + this.Session["cdk4"].ToString() + "人！如需增加用户数请联系开发商！');</Script>");
                    return;
                }
            }
            string str2 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
            string sql = "select * from qp_oa_username where Username='" + this.pulicss.GetFormatStr(this.Username.Text) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('此用户名在用户管理中已经存在，不能重复！');</script>");
            }
            else
            {
                list.Close();
                string str4 = null;
                string str5 = "select Perstr from qp_oa_Juese where id='" + this.JueseId.SelectedValue + "'";
                SqlDataReader reader2 = this.List.GetList(str5);
                if (reader2.Read())
                {
                    str4 = reader2["Perstr"].ToString();
                }
                reader2.Close();
                string str6 = null;
                string str7 = "select QxString from qp_oa_Bumen where id='" + this.Bumen.SelectedValue + "'";
                SqlDataReader reader3 = this.List.GetList(str7);
                if (reader3.Read())
                {
                    str6 = reader3["QxString"].ToString();
                }
                reader3.Close();
                string str8 = "insert into qp_oa_username (Username,Password,Realname,BuMenId,JueseId,IfResponUpdate,Zhiweiid,StardType,Email,MoveTel,Iflogin,Sex,Remark,settime,ResponQx,QxString,guanzhu,lasttime,onlinetime,ifdel) values ('" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + str2 + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','" + this.Bumen.SelectedValue + "','" + this.JueseId.SelectedValue + "','1','" + this.Zhiwei.SelectedValue + "','1','','','" + this.Iflogin.SelectedValue + "','" + this.Xingbie.SelectedValue + "','','" + DateTime.Now.ToString() + "','" + str4 + "','" + str6 + "','','" + DateTime.Now.AddDays(-1.0).ToString() + "','0','0')";
                this.List.ExeSql(str8);
                string str9 = "insert into qp_oa_yangshi (Username,Name) values ('" + this.pulicss.GetFormatStr(this.Username.Text) + "','bluecss')";
                this.List.ExeSql(str9);
                string str10 = "insert into qp_oa_MyReminded (iftx,txtime,Sound,Username) values ('1','30000','8.swf','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str10);
                string str11 = "insert into qp_oa_MyState (States,Username) values ('在线','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str11);
                string str12 = "insert into qp_oa_MyWeituo (States,Username) values ('0','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str12);
                string str13 = "insert into qp_oa_Menu  (Username) values ('" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str13);
                string str14 = "insert into qp_oa_MyData (Bothday,Username,Realname,Unit,Post,Sex,Email,MoveTel) values ('','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','" + this.Bumen.SelectedItem.Text.Replace("|", "").Replace("-", "") + "','" + this.Zhiwei.SelectedItem.Text.Replace("|", "").Replace("-", "") + "','" + this.Xingbie.SelectedValue + "','','')";
                this.List.ExeSql(str14);
                string str15 = "insert into qp_oa_OpenMenu  (Url,Username) values ('MyWorkMenu.aspx','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str15);
                string str16 = "insert into qp_oa_DIYMould  (Name,UrlMath,PaiXun,Username,Realname,LookMuch,target) values ('通知公告','/PublicWork/BumenNewsMg/BumenNewsMgList.aspx','1','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','5','rform')";
                this.List.ExeSql(str16);
                string str17 = "insert into qp_oa_DIYMould  (Name,UrlMath,PaiXun,Username,Realname,LookMuch,target) values ('工作流程-待办工作','/WorkFlow/WorkFlowList.aspx','2','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','5','rform')";
                this.List.ExeSql(str17);
                string str18 = "insert into qp_oa_DIYMould  (Name,UrlMath,PaiXun,Username,Realname,LookMuch,target) values ('内部邮件-收件箱','/InfoManage/nbemail/NbEmail_sj.aspx','3','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','5','rform')";
                this.List.ExeSql(str18);
                string str19 = "insert into qp_oa_DIYMould  (Name,UrlMath,PaiXun,Username,Realname,LookMuch,target) values ('内部消息-未读消息','/InfoManage/messages/Messages.aspx','4','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','5','rform')";
                this.List.ExeSql(str19);
                string str20 = "insert into qp_oa_MakeTing (content,Username) values ('','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str20);
            }
        }
    }
}

