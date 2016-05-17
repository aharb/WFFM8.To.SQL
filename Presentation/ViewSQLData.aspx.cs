using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WFFM8.To.SQL.Model;



namespace WFFM8.To.SQL.Presentation
{
    public partial class ViewSQLData : System.Web.UI.Page
    {

        #region Propirties
        private readonly FormRepository _formRepository = new FormRepository();
        private readonly CsvColumnRepository _csvColumnRepository = new CsvColumnRepository();

        private string _itemName = null;
        private string ItemName
        {
            get
            {
                if (_itemName == null)
                    _itemName = HttpContext.Current.Server.UrlDecode(Request.QueryString[Constants.QueryString.Name.ItemName]) ?? string.Empty;
                return _itemName;
            }
        }
        private string _itemID = null;
        private string ItemID
        {
            get
            {
                if (_itemID == null)
                    _itemID = HttpContext.Current.Server.UrlDecode(Request.QueryString[Constants.QueryString.Name.ItemId]) ?? string.Empty;
                return _itemID;
            }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

            //you have to be logged in, and have the form id as a query string
            if (!Sitecore.Context.IsLoggedIn ||
                string.IsNullOrEmpty(this.ItemID) ||
                string.IsNullOrEmpty(this.ItemName))
            {
                // NotLoggedLoggedInPlaceHolder.Visible = true;
                return;
            }

            if (!IsPostBack)
            {
                txtFrom.Text = _formRepository.OldestFormSubmission(new ID(this.ItemID)).ToString(Constants.DateTime.DateFormat);
                txtTo.Text = DateTime.Now.ToString(Constants.DateTime.DateFormat);

                PopulateFormData();
 
            }

            
        }

        #endregion

        #region Methods 
        private void PopulateFormData()
        {
            DateTime from;
            if (!DateTime.TryParse(txtFrom.Text, out from))
            {
                warnFrom.Text = Constants.Texts.Warning.IncorrectDateFromat;
                return;
            }

            DateTime to;
            if (!DateTime.TryParse(txtTo.Text, out to))
            {
                warnTo.Text = Constants.Texts.Warning.IncorrectDateFromat; ;
                return;
            }

            // If passed in "3/17/2015"; covert it to "3/17/2015 23:59:59"
            if (to.Hour == 0 && to.Minute == 0 && to.Second == 0)
                to = to.Add(new TimeSpan(23, 59, 59));


            var formData = _formRepository.Get( new Sitecore.Data.ID(this.ItemID), from, to);

            if (formData.Any())
            {
                BindTableHeader(formData);
                BindTableRows(formData);
                foreach (var form in formData)
                {
                    IEnumerable<IField> fileds = form.Field;
                }
            }
        }

        private void BindTableHeader(IEnumerable<IForm> forms)
        {
            Dictionary<Guid, string> columns = _csvColumnRepository.Get(forms);
            rptHeaderFormData.DataSource = columns;
            rptHeaderFormData.DataBind();

        }

        private void BindTableRows(IEnumerable<IForm> forms)
        {
            rptFormData.DataSource = forms;
            rptFormData.DataBind();
        }

        protected void rptHeaderFormData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = (System.Collections.Generic.KeyValuePair<Guid, string>)e.Item.DataItem;
                var divHeader = (HtmlGenericControl)e.Item.FindControl("divHeader");
                divHeader.InnerText = item.Value;
            }
        }

        protected void rptFormData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var form = (IForm)e.Item.DataItem;
                var trData = (HtmlTableRow)e.Item.FindControl("trData");

                foreach (var field in form.Field)
                {
                    HtmlTableCell c = new HtmlTableCell();
                    c.InnerText = field.Value;
                    trData.Controls.Add(c);
                    
                }
            }
        }
        #endregion

        

        

    }
}