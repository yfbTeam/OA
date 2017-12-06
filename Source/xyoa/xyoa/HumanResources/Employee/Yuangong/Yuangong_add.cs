namespace xyoa.HumanResources.Employee.Yuangong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Yuangong_add : Page
    {
        protected TextBox Beizhu;
        protected TextBox Bianhao;
        protected DropDownList Bumen;
        protected Button Button1;
        protected CheckBox CheckBox2;
        protected TextBox Chuanzhen;
        protected TextBox Chusheng;
        protected TextBox CjShijian;
        protected TextBox Dizhi;
        protected HtmlForm form1;
        protected TextBox GzJingli;
        protected HtmlHead Head1;
        protected TextBox Hukou;
        protected RadioButtonList Hunyin;
        protected RadioButtonList Iflogin;
        protected TextBox Jiangcheng;
        protected TextBox Jiating;
        protected DropDownList Jiguan;
        protected TextBox Jineng;
        protected TextBox JrShijian;
        protected DropDownList JueseId;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Mianmao;
        protected DropDownList Mingzhu;
        protected TextBox MSN;
        protected TextBox Neibu;
        protected TextBox Password;
        private publics pulicss = new publics();
        protected TextBox QQ;
        protected TextBox Shehui;
        protected TextBox Shenfenzheng;
        protected TextBox Shouji;
        protected TextBox Tijian;
        protected HtmlInputFile uploadFile;
        protected TextBox Username;
        protected RadioButtonList Xingbie;
        protected TextBox Xingming;
        protected DropDownList Xuexi;
        protected TextBox XxJingli;
        protected TextBox Youbian;
        protected TextBox Youxiang;
        protected TextBox Yuanxiao;
        protected DropDownList Zhicheng;
        protected DropDownList Zhiwei;
        protected DropDownList Zhuanye;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str8;
            string str = base.Server.MapPath("file/");
            string truePath = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                truePath = str3 + extension;
                str8 = "insert into qp_hr_Yuangong  (Jiangcheng,Chuanzhen,Shouji,QQ,MSN,Neibu,Youbian,Username,Xiangpian,Xingming,Bianhao,Xingbie,Chusheng,Mingzhu,Jiguan,Mianmao,Hunyin,Xuexi,Yuanxiao,Zhuanye,Shenfenzheng,Hukou,Jiating,Youxiang,Dizhi,Bumen,Leixing,Zhiwei,Zhicheng,CjShijian,JrShijian,Shehui,GzJingli,XxJingli,Jineng,Tijian,Beizhu,Zaizhi) values ('" + this.pulicss.GetFormatStr(this.Jiangcheng.Text) + "','" + this.pulicss.GetFormatStr(this.Chuanzhen.Text) + "','" + this.pulicss.GetFormatStr(this.Shouji.Text) + "','" + this.pulicss.GetFormatStr(this.QQ.Text) + "','" + this.pulicss.GetFormatStr(this.MSN.Text) + "','" + this.pulicss.GetFormatStr(this.Neibu.Text) + "','" + this.pulicss.GetFormatStr(this.Youbian.Text) + "','" + this.Username.Text + "','/HumanResources/Employee/Yuangong/file/" + truePath + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','" + this.pulicss.GetFormatStr(this.Bianhao.Text) + "','" + this.Xingbie.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Chusheng.Text) + "','" + this.Mingzhu.SelectedValue + "','" + this.Jiguan.SelectedValue + "','" + this.Mianmao.SelectedValue + "','" + this.Hunyin.SelectedValue + "','" + this.Xuexi.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Yuanxiao.Text) + "','" + this.Zhuanye.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Shenfenzheng.Text) + "','" + this.pulicss.GetFormatStr(this.Hukou.Text) + "','" + this.pulicss.GetFormatStr(this.Jiating.Text) + "','" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "','" + this.pulicss.GetFormatStr(this.Dizhi.Text) + "','" + this.Bumen.SelectedValue + "','" + this.Leixing.SelectedValue + "','" + this.Zhiwei.SelectedValue + "','" + this.Zhicheng.SelectedValue + "','" + this.pulicss.GetFormatStr(this.CjShijian.Text) + "','" + this.pulicss.GetFormatStr(this.JrShijian.Text) + "','" + this.pulicss.GetFormatStr(this.Shehui.Text) + "','" + this.pulicss.GetFormatStr(this.GzJingli.Text) + "','" + this.pulicss.GetFormatStr(this.XxJingli.Text) + "','" + this.pulicss.GetFormatStr(this.Jineng.Text) + "','" + this.pulicss.GetFormatStr(this.Tijian.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "','1')";
                this.List.ExeSql(str8);
            }
            else
            {
                str8 = "insert into qp_hr_Yuangong  (Jiangcheng,Chuanzhen,Shouji,QQ,MSN,Neibu,Youbian,Username,Xiangpian,Xingming,Bianhao,Xingbie,Chusheng,Mingzhu,Jiguan,Mianmao,Hunyin,Xuexi,Yuanxiao,Zhuanye,Shenfenzheng,Hukou,Jiating,Youxiang,Dizhi,Bumen,Leixing,Zhiwei,Zhicheng,CjShijian,JrShijian,Shehui,GzJingli,XxJingli,Jineng,Tijian,Beizhu,Zaizhi) values ('" + this.pulicss.GetFormatStr(this.Jiangcheng.Text) + "','" + this.pulicss.GetFormatStr(this.Chuanzhen.Text) + "','" + this.pulicss.GetFormatStr(this.Shouji.Text) + "','" + this.pulicss.GetFormatStr(this.QQ.Text) + "','" + this.pulicss.GetFormatStr(this.MSN.Text) + "','" + this.pulicss.GetFormatStr(this.Neibu.Text) + "','" + this.pulicss.GetFormatStr(this.Youbian.Text) + "','" + this.Username.Text + "','/HumanResources/Employee/Yuangong/file/0.jpg','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','" + this.pulicss.GetFormatStr(this.Bianhao.Text) + "','" + this.Xingbie.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Chusheng.Text) + "','" + this.Mingzhu.SelectedValue + "','" + this.Jiguan.SelectedValue + "','" + this.Mianmao.SelectedValue + "','" + this.Hunyin.SelectedValue + "','" + this.Xuexi.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Yuanxiao.Text) + "','" + this.Zhuanye.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Shenfenzheng.Text) + "','" + this.pulicss.GetFormatStr(this.Hukou.Text) + "','" + this.pulicss.GetFormatStr(this.Jiating.Text) + "','" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "','" + this.pulicss.GetFormatStr(this.Dizhi.Text) + "','" + this.Bumen.SelectedValue + "','" + this.Leixing.SelectedValue + "','" + this.Zhiwei.SelectedValue + "','" + this.Zhicheng.SelectedValue + "','" + this.pulicss.GetFormatStr(this.CjShijian.Text) + "','" + this.pulicss.GetFormatStr(this.JrShijian.Text) + "','" + this.pulicss.GetFormatStr(this.Shehui.Text) + "','" + this.pulicss.GetFormatStr(this.GzJingli.Text) + "','" + this.pulicss.GetFormatStr(this.XxJingli.Text) + "','" + this.pulicss.GetFormatStr(this.Jineng.Text) + "','" + this.pulicss.GetFormatStr(this.Tijian.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "','1')";
                this.List.ExeSql(str8);
            }
            this.UserAdd(truePath);
            if (this.CheckBox2.Checked)
            {
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_CompanyGroup   (Name,BuMenId,JueseId,Zhiweiid,Sex,BothDay,Officetel,Fax,MoveTel,HomeTel,Email,QQNum,MsnNum,NbNum,Address,ZipCode,Remark,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(this.Xingming.Text), "','", this.Bumen.SelectedValue, "','0','", this.Zhiwei.SelectedValue, "','", this.pulicss.GetFormatStr(this.Xingbie.SelectedItem.Text), "','", this.pulicss.GetFormatStr(this.Chusheng.Text), "','", this.pulicss.GetFormatStr(this.Jiating.Text), "','", this.pulicss.GetFormatStr(this.Chuanzhen.Text), "','", this.pulicss.GetFormatStr(this.Shouji.Text), 
                    "','','", this.pulicss.GetFormatStr(this.Youxiang.Text), "','", this.pulicss.GetFormatStr(this.QQ.Text), "','", this.pulicss.GetFormatStr(this.MSN.Text), "','", this.pulicss.GetFormatStr(this.Neibu.Text), "','", this.pulicss.GetFormatStr(this.Dizhi.Text), "','", this.pulicss.GetFormatStr(this.Youbian.Text), "','','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(sql);
            }
            this.pulicss.InsertLog("新增员工档案[" + this.Xingming.Text + "]", "员工档案");
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'> winClose(1);</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee4aa", this.Session["perstr"].ToString());
                this.pulicss.BindListkong("qp_oa_Bumen", this.Bumen, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                string str2 = "select id,Name from qp_hr_YuangongLx where Type=1 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Mingzhu, str2, "id", "Name");
                string str3 = "select id,Name from qp_hr_YuangongLx where Type=2 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Jiguan, str3, "id", "Name");
                string str4 = "select id,Name from qp_hr_YuangongLx where Type=3 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Mianmao, str4, "id", "Name");
                string str5 = "select id,Name from qp_hr_YuangongLx where Type=4 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Xuexi, str5, "id", "Name");
                string str6 = "select id,Name from qp_hr_YuangongLx where Type=5 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhuanye, str6, "id", "Name");
                string str7 = "select id,Name from qp_hr_YuangongLx where Type=6 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhicheng, str7, "id", "Name");
                string str8 = "select id,Name from qp_hr_YuangongLx where Type=7 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, str8, "id", "Name");
                this.Bumen.SelectedValue = base.Request.QueryString["bmid"].ToString();
                string str9 = "select id,name  from qp_oa_Juese order by id asc";
                this.list.Bind_DropDownList_nothing(this.JueseId, str9, "id", "name");
                this.BindAttribute();
            }
        }

        public void UserAdd(string TruePath)
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
                string str8;
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
                if (this.uploadFile.PostedFile.ContentLength != 0)
                {
                    str8 = "insert into qp_oa_username (pic,Kehushu,jifen,Username,Password,Realname,BuMenId,JueseId,IfResponUpdate,Zhiweiid,StardType,Email,MoveTel,Iflogin,Sex,Remark,settime,ResponQx,QxString,guanzhu,lasttime,onlinetime,ifdel) values ('/HumanResources/Employee/Yuangong/file/" + TruePath + "','0','0','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + str2 + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','" + this.Bumen.SelectedValue + "','" + this.JueseId.SelectedValue + "','1','" + this.Zhiwei.SelectedValue + "','1','" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "','" + this.pulicss.GetFormatStr(this.Shouji.Text) + "','" + this.Iflogin.SelectedValue + "','" + this.Xingbie.SelectedValue + "','','" + DateTime.Now.ToString() + "','" + str4 + "','" + str6 + "','','" + DateTime.Now.AddDays(-1.0).ToString() + "','0','0')";
                    this.List.ExeSql(str8);
                }
                else
                {
                    str8 = "insert into qp_oa_username (pic,Kehushu,jifen,Username,Password,Realname,BuMenId,JueseId,IfResponUpdate,Zhiweiid,StardType,Email,MoveTel,Iflogin,Sex,Remark,settime,ResponQx,QxString,guanzhu,lasttime,onlinetime,ifdel) values ('0.jpg','0','0','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + str2 + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','" + this.Bumen.SelectedValue + "','" + this.JueseId.SelectedValue + "','1','" + this.Zhiwei.SelectedValue + "','1','" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "','" + this.pulicss.GetFormatStr(this.Shouji.Text) + "','" + this.Iflogin.SelectedValue + "','" + this.Xingbie.SelectedValue + "','','" + DateTime.Now.ToString() + "','" + str4 + "','" + str6 + "','','" + DateTime.Now.AddDays(-1.0).ToString() + "','0','0')";
                    this.List.ExeSql(str8);
                }
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
                string str14 = "insert into qp_oa_MyData (Bothday,Username,Realname,Unit,Post,Sex,Email,MoveTel) values ('','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','" + this.Bumen.SelectedItem.Text.Replace("|", "").Replace("-", "") + "','" + this.Zhiwei.SelectedItem.Text.Replace("|", "").Replace("-", "") + "','" + this.Xingbie.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "','" + this.pulicss.GetFormatStr(this.Shouji.Text) + "')";
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

