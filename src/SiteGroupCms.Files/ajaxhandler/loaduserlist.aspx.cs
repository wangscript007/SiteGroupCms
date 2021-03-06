﻿using System;
using System.Web;
using SiteGroupCms.Utils;
using SiteGroupCms.DBUtility;

namespace SiteGroupCms.ajaxhandler
{
    /// <summary>
    /// 用户列表加载控制层
    /// </summary>
    public partial class loaduserlist:SiteGroupCms.Ui.AdminCenter
    {
        string type = String.Empty;
        int currentpage = 1;
        int pagesize = 1;
        string sortname = "islock";
        string sortorder = "asc";
        string where = "1=1";
        SiteGroupCms.Dal.AdminDal admindal = new SiteGroupCms.Dal.AdminDal();
        SiteGroupCms.Entity.Admin admin = new SiteGroupCms.Entity.Admin();
        string _response = String.Empty;
        SiteGroupCms.Entity.Admin _admin = new SiteGroupCms.Entity.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Admin_Load("1", "json");
                _admin = (SiteGroupCms.Entity.Admin)Session["admin"];
                //where += " and siteid="+_admin.CurrentSite;
            }
          // if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            //    type = Request.QueryString["type"];
            if (Request.Form["sortname"] != null && Request.Form["sortname"] != "state")
                sortname = Request.Form["sortname"];
            if (Request.Form["sortorder"] != null && Request.Form["sortorder"] != "")
                sortorder = Request.Form["sortorder"];
            if (Request.Form["page"] != null && Request.Form["page"] != "")
                currentpage = Validator.StrToInt(Request.Form["page"], 1);
            if (Request.Form["pagesize"] != null && Request.Form["pagesize"] != "")
                pagesize = Validator.StrToInt(Request.Form["pagesize"], 1);
            if (Request.Form["where"] != null)
                where = Request.Form["where"];
            admindal.GetListJSON(1,currentpage, pagesize, where, ref _response, sortname, sortorder);
            Response.Write(_response);
        }
    }
}
