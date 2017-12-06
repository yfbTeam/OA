namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPage_wt_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected Label fujian;
        protected Label fujianZj;
        protected HtmlHead Head1;
        protected Label huida;
        protected HtmlImage IMG1;
        protected HtmlImage IMG2;
        protected HtmlImage IMG3;
        protected HtmlImage IMG4;
        private Db List = new Db();
        protected TextBox neirong_hd;
        protected TextBox neirong_zj;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected TextBox TextBox1;
        protected TextBox TextBox2;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_Zst_wenti  Set  Neirong=Neirong+'\n<b>追加内容：</b>\n", this.TextBox1.Text, "' where id='", int.Parse(base.Request.QueryString["id"]), "'  and Username='", this.Session["Username"], "' " });
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.TextBox1.Text = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_Zst_huida  (WentiId,Neirong,Username,Realname,Settimes,Zuijia,Yincang) values ('", int.Parse(base.Request.QueryString["id"]), "','", this.pulicss.GetFormatStr(this.TextBox2.Text), "','", this.Session["Username"].ToString(), "','", this.Session["Realname"].ToString(), "','", DateTime.Now.ToString(), "','2','1')" });
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "Update qp_oa_username  Set jifen=jifen", this.pulicss.JifenGuize("回答问题"), "  where username='", this.Session["username"], "'" });
            this.List.ExeSql(str2);
            string str3 = string.Concat(new object[] { "Update qp_oa_Zst_wenti   Set Huida=Huida+1,UsernameHd=UsernameHd+'", this.Session["username"], ",',RealnameHd=RealnameHd+'", this.Session["realname"], ",'  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(str3);
            this.DataBindToGridview();
            this.TextBox2.Text = null;
        }

        public void DataBindToGridview()
        {
            this.huida.Text = null;
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return select_hd();";
            string sql = string.Concat(new object[] { "select * from qp_oa_Zst_wenti  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and  Username='", this.Session["Username"], "'" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2;
                SqlDataReader reader2;
                string str3;
                string text;
                this.ViewState["Zhuti"] = list["Zhuti"].ToString();
                this.ViewState["Neirong"] = this.pulicss.TbToLb(list["Neirong"].ToString());
                this.ViewState["Number"] = list["Number"].ToString();
                this.ViewState["Username"] = list["Username"].ToString();
                this.ViewState["Realname"] = list["Realname"].ToString();
                this.ViewState["Settimes"] = list["Settimes"].ToString();
                this.ViewState["Dianji"] = list["Dianji"].ToString();
                this.ViewState["Huida"] = list["Huida"].ToString();
                this.ViewState["jiejue"] = list["jiejue"].ToString();
                this.ViewState["tuijian"] = list["tuijian"].ToString();
                if (this.Session["username"].ToString() == "admin")
                {
                    if (this.ViewState["tuijian"].ToString() == "1")
                    {
                        this.IMG1.Visible = false;
                        this.IMG2.Visible = true;
                        this.IMG3.Visible = true;
                    }
                    else
                    {
                        this.IMG1.Visible = true;
                        this.IMG2.Visible = true;
                        this.IMG3.Visible = false;
                    }
                }
                else
                {
                    this.IMG1.Visible = false;
                    this.IMG2.Visible = false;
                    this.IMG3.Visible = false;
                }
                if (this.Session["username"].ToString() == this.ViewState["Username"].ToString())
                {
                    this.IMG4.Visible = true;
                }
                else
                {
                    this.IMG4.Visible = false;
                }
                if (list["jiejue"].ToString() == "1")
                {
                    this.Panel1.Visible = true;
                    str2 = "select * from qp_oa_Zst_huida  where WentiId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and  Zuijia!='1'";
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        if (reader2["Yincang"].ToString() == "1")
                        {
                            if (this.Session["username"].ToString() == "admin")
                            {
                                text = this.huida.Text;
                                this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\">" + this.pulicss.TbToLb(reader2["Neirong"].ToString()) + "</td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"><a href='javascript:void(0)' onclick=\"openyincan('" + reader2["id"].ToString() + "','" + base.Request.QueryString["id"] + "')\"><img src=\"img/yincan.jpg\" hspace=\"2\" border=\"0\"></a></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                            }
                            else
                            {
                                text = this.huida.Text;
                                this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\">" + this.pulicss.TbToLb(reader2["Neirong"].ToString()) + "</td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                            }
                        }
                        else if (this.Session["username"].ToString() == "admin")
                        {
                            text = this.huida.Text;
                            this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\"><s>回答内容不符合规则，已隐藏</s></td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"><a href='javascript:void(0)' onclick=\"openyincan('" + reader2["id"].ToString() + "','" + base.Request.QueryString["id"] + "')\"><img src=\"img/yincan.jpg\" hspace=\"2\" border=\"0\"></a></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                        }
                        else
                        {
                            text = this.huida.Text;
                            this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\"><s>回答内容不符合规则，已隐藏</s></td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                        }
                    }
                    reader2.Close();
                    str3 = "select count(id) from qp_oa_Zst_huida  where WentiId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and  Zuijia!='1'";
                    this.ViewState["heji"] = "" + this.List.GetCount(str3) + "";
                }
                else
                {
                    str2 = "select * from qp_oa_Zst_huida  where WentiId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        if (reader2["Yincang"].ToString() == "1")
                        {
                            if (this.Session["username"].ToString() == this.ViewState["Username"].ToString())
                            {
                                if (this.Session["username"].ToString() == "admin")
                                {
                                    text = this.huida.Text;
                                    this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\">" + this.pulicss.TbToLb(reader2["Neirong"].ToString()) + "</td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"><a href='javascript:void(0)' onclick=\"opencaina('" + reader2["id"].ToString() + "','" + base.Request.QueryString["id"] + "')\"><img src=\"img/caina.jpg\" hspace=\"2\" border=\"0\"></a><a href='javascript:void(0)' onclick=\"openyincan('" + reader2["id"].ToString() + "','" + base.Request.QueryString["id"] + "')\"><img src=\"img/yincan.jpg\" hspace=\"2\" border=\"0\"></a></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                                }
                                else
                                {
                                    text = this.huida.Text;
                                    this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\">" + this.pulicss.TbToLb(reader2["Neirong"].ToString()) + "</td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"><a href='javascript:void(0)' onclick=\"opencaina('" + reader2["id"].ToString() + "','" + base.Request.QueryString["id"] + "')\"><img src=\"img/caina.jpg\" hspace=\"2\" border=\"0\"></a></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                                }
                            }
                            else if (this.Session["username"].ToString() == "admin")
                            {
                                text = this.huida.Text;
                                this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\">" + this.pulicss.TbToLb(reader2["Neirong"].ToString()) + "</td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"><a href='javascript:void(0)' onclick=\"opencaina('" + reader2["id"].ToString() + "','" + base.Request.QueryString["id"] + "')\"><img src=\"img/caina.jpg\" hspace=\"2\" border=\"0\"></a><a href='javascript:void(0)' onclick=\"openyincan('" + reader2["id"].ToString() + "','" + base.Request.QueryString["id"] + "')\"><img src=\"img/yincan.jpg\" hspace=\"2\" border=\"0\"></a></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                            }
                            else
                            {
                                text = this.huida.Text;
                                this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\">" + this.pulicss.TbToLb(reader2["Neirong"].ToString()) + "</td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                            }
                        }
                        else if (this.Session["username"].ToString() == "admin")
                        {
                            text = this.huida.Text;
                            this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\"><s>回答内容不符合规则，已隐藏</s></td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"><a href='javascript:void(0)' onclick=\"openyincan('" + reader2["id"].ToString() + "','" + base.Request.QueryString["id"] + "')\"><img src=\"img/yincan.jpg\" hspace=\"2\" border=\"0\"></a></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                        }
                        else
                        {
                            text = this.huida.Text;
                            this.huida.Text = text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\"><tr><td valign=\"top\"><s>回答内容不符合规则，已隐藏</s></td></tr><tr><td height=\"30\" background=\"img/ll.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"40%\"></td><td width=\"18%\" align=\"right\">回答人：<a href='javascript:void(0)' onclick='senduser(\"" + reader2["username"].ToString() + "\")' class=\"LinkLine\"><font color=\"#4D3CCF\">" + reader2["realname"].ToString() + "</font></a></td><td width=\"13%\"><img src=\"img/d_5.gif\" width=\"84\" height=\"16\"></td><td width=\"29%\"><font color=\"#666666\">回答时间：" + reader2["Settimes"].ToString() + "</font></td></tr></table></td></tr></table>";
                        }
                    }
                    reader2.Close();
                    this.Panel1.Visible = false;
                    str3 = "select count(id) from qp_oa_Zst_huida  where WentiId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    this.ViewState["heji"] = "" + this.List.GetCount(str3) + "";
                }
                this.pulicss.GetFile(this.ViewState["Number"].ToString(), this.fujian);
            }
            list.Close();
            string str4 = "select * from qp_oa_Zst_huida  where WentiId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and  Zuijia='1'";
            SqlDataReader reader3 = this.List.GetList(str4);
            if (reader3.Read())
            {
                if (reader3["Yincang"].ToString() == "1")
                {
                    this.ViewState["NeirongZj"] = this.pulicss.TbToLb(reader3["Neirong"].ToString());
                }
                else
                {
                    this.ViewState["NeirongZj"] = "<s>回答内容违规，已隐藏</s>";
                }
                this.ViewState["UsernameZj"] = reader3["Username"].ToString();
                this.ViewState["RealnameZj"] = reader3["Realname"].ToString();
                this.ViewState["SettimesZj"] = reader3["Settimes"].ToString();
            }
            reader3.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "Update qp_oa_Zst_wenti   Set Dianji=Dianji+1  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and  Username='", this.Session["Username"], "'" });
                this.List.ExeSql(sql);
                this.DataBindToGridview();
            }
        }
    }
}

