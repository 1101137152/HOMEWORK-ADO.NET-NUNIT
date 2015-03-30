using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YEAR;
namespace WebApplication1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            Class1 cal = new Class1();
            int inputAge = 0;
            Class1.YearFormat inputFormat = (Class1.YearFormat)Enum.Parse(typeof(Class1.YearFormat), ddlYearFormat.SelectedValue, false);

            int.TryParse(txtAge.Text, out inputAge);
            if (inputAge > 0)
            {
                lblYear.Text = cal.GetBirthYear(inputAge, inputFormat).ToString();
            }
        }
    }
}