using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_.ServiceReference1;


namespace WebApplication_
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals("") || TextBox1.Text.Equals(""))
            {
                lblMsg.Text = "Sorry, Column can't Empty!!!";
            }
            else
            {
                InsertUser u = new InsertUser();
                u.Name = TextBox1.Text;
                u.Email = TextBox2.Text;
                string r = client.Insert(u);
                lblMsg.Text = r.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.gettestdata g = new ServiceReference1.gettestdata();
            g = client.GetInfo();
            DataTable dt = new DataTable();
            dt = g.usertab;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lblMsg.Text = "";
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals("") || TextBox1.Text.Equals("") || txtuid.Text.Equals(""))
            {
                lblMsg.Text = "Sorry, Column can't Empty!!!";
            }
            else
            {
                UpdateUser u = new UpdateUser();
                u.UID = int.Parse(txtuid.Text);
                u.Name = TextBox1.Text;
                u.Email = TextBox2.Text;
                string result = client.Update(u);
                lblMsg.Text = result.ToString();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (txtuid.Text.Equals(""))
            {
                lblMsg.Text = "UserID is Empty";
            }
            else
            {
                DeleteUser d = new DeleteUser();
                d.UID = int.Parse(txtuid.Text);
                string res = client.Delete(d);
                lblMsg.Text = res.ToString();
            }
        }
    }
}

    