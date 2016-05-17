using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;


namespace WFFM8.To.SQL.Infrastructure.Commands
{
    public class ViewSQLData : Command
    {
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            Assert.IsNotNull(context.Items, "context items are null");
            Assert.IsTrue(context.Items.Length > 0, "context items length is 0");

            Item contextItem = context.Items[0];
            Assert.IsNotNull(contextItem, "First context item is null");
            OpenNewWindow(contextItem.ID, contextItem.Name);
        }

        private void OpenNewWindow(ID id, string name)
        {
            Assert.ArgumentNotNull(id, "id");
            UrlString url = new UrlString(Constants.Url.ViewSQLData);
            url.Append(Constants.QueryString.Name.ItemId, HttpContext.Current.Server.UrlEncode(id.ToString()));
            url.Append(Constants.QueryString.Name.ItemName, HttpContext.Current.Server.UrlEncode(name));
            SheerResponse.Eval(string.Format("window.open('{0}');", url));
        }
    }
}