using Newtonsoft.Json;
using SoftSunlight.Tool;
using SoftSunlightIM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftSunlightIM
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开注册界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.loginPanel.Visible = false;
            this.registerPanel.Visible = true;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAccount.Text.Trim()) || string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                MessageBox.Show("请填写用户名或密码");
                return;
            }
            string errorMsg = ClientSocket.Start();
            if (string.IsNullOrEmpty(errorMsg))
            {
                ClientSocket.Send(new Message<LoginVerifyMessage>() { CommandType = (int)CommandTypeEnum.Login, MessageBody = new LoginVerifyMessage() { Account = tbAccount.Text.Trim(), Password = tbPassword.Text.Trim() } });
            }
        }

        private void btnCofirmRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbRegisterAccount.Text.Trim()) || string.IsNullOrEmpty(tbRegisterPassword.Text.Trim()))
            {
                MessageBox.Show("请填写用户名或密码");
                return;
            }
            if (!tbRegisterPassword.Text.Trim().Equals(tbRegisterConfirmPassword.Text.Trim()))
            {
                MessageBox.Show("两次填写的密码不一致");
                return;
            }
            try
            {
                string requestUrl = "http://localhost:60567/User/Register";
                Dictionary<string, string> postParam = new Dictionary<string, string>()
                {
                    { "Account",tbRegisterAccount.Text.Trim() },
                    { "Password",tbRegisterPassword.Text.Trim() }
                };
                WebUtils webUtils = new WebUtils();
                string jsonResult = webUtils.DoPost(requestUrl, postParam, new Dictionary<string, string>() { { "Content-Type", "application/json" } });
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResult);
                if (apiResponse != null && apiResponse.Success)
                {
                    //注册成功
                    registerPanel.Visible = false;
                    loginPanel.Visible = true;
                }
                else
                {
                    if (apiResponse == null || string.IsNullOrEmpty(apiResponse.ErrorMsg))
                    {
                        MessageBox.Show("注册失败");
                    }
                    else
                    {
                        MessageBox.Show("注册失败，" + apiResponse.ErrorMsg);
                    }
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("请检查网络连接");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
