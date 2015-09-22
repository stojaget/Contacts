using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kontakti.Validation;


public partial class Controls_ErrorList : System.Web.UI.UserControl
{
    private BrokenRulesCollection _brokenRules;

    public BrokenRulesCollection BrokenRules
    {
        get { return _brokenRules; }
        set
        {
            ErrorList.DataSource = value;
            ErrorList.DataBind();
            _brokenRules = value;
        }
    }
}