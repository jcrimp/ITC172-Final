using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FanRegistrationReference;

public partial class fanregister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //instantiate service
        FanRegistrationServiceClient registrationClient = new FanRegistrationServiceClient();

        //create instance of fan
        Fan f = new Fan();
        f.FanName = txtFirstName.Text + " " + txtLastName.Text;
        f.FanEmail = txtEmail.Text;
        f.FanDateEntered = DateTime.Now;

        //create instance of venue
        FanLogin fl = new FanLogin();
        fl.FanLoginUserName = txtUser.Text;
        fl.FanLoginPasswordPlain = txtPass.Text;
        fl.FanLoginDateAdded = DateTime.Now;

        //pass the values to RegisterFan, which returns a bool
        bool result = registrationClient.RegisterFan(f, fl);

        //if FanLogin returns true(was successful)
        if(result)
        {
            int key = registrationClient.Login(txtConfirmPass.Text, txtUser.Text);

            //check the results
            if (key != 0)
            {
                Session["fanKey"] = key;
                Response.Redirect("searchbyartist.aspx");
            }
            else
            {
                lblError.Text = "There was a problem logging you in";
            }
        }
        else
        {
            lblError.Text = "Registration Failed";
        }
            
    }
}