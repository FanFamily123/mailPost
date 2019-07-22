using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mailwinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string smtpService = "smtp.qq.com";
        public string sendEmail = "fanzhenmail@foxmail.com";//发送者
        public string receiveEmail = "fanzhenlol@163.com";//接收者
        public string sendpwd = "sxjyqgrauroqbbhc";//第三方登录码


        private void button1_Click(object sender, EventArgs e)
        {

            //确定smtp服务器地址 实例化一个Smtp客户端
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpService;
 
            //smtpClient.Port = "";//qq邮箱可以不用端口
            //构建发件地址和收件地址
            MailAddress sendAddress = new MailAddress(sendEmail, "SP的我");
 
            MailAddress receiverAddress = new MailAddress(receiveEmail);//收件人
 
            //构造一个Email的Message对象 内容信息
            MailMessage message = new MailMessage(sendAddress, receiverAddress);
            message.Subject = "邮件主题" + DateTime.Now;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = rtbContext.Text;
            message.BodyEncoding = Encoding.UTF8;
            //设置邮件的信息 如登陆密码 账号
            //邮件发送方式  通过网络发送到smtp服务器
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //如果服务器支持安全连接，则将安全连接设为true
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.UseDefaultCredentials = false;
                //发件用户登陆信息
                NetworkCredential senderCredential = new NetworkCredential(sendEmail, sendpwd);
                smtpClient.Credentials = senderCredential;
                //发送邮件
                smtpClient.Send(message);
                MessageBox.Show("发送成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        //    SmtpClient client = new SmtpClient();//生成SmtpClient实例，用它发送电子邮件
        //client.Host = "smtp.qq.com";//指定SMTP服务器主机
        //client.Port = 465;//指定要使用的端口
        //client.Credentials = new System.Net.NetworkCredential("fanzhenmail@foxmail.com", "Fanzhen1996...");//验证用户名和密码
        //MailMessage message = new MailMessage();
        //MailAddress from = new MailAddress(txtSender.Text);//获取输入的发件人邮箱地址
        //if (txtReceiver.Text != "")
        //{
        //    if (Regex.IsMatch(txtReceiver.Text, "\\w+@\\w+(\\.\\w+)+"))  //用正则表达式验证邮箱
        //    {
        //        MailAddress to = new MailAddress(txtReceiver.Text);//获取输入的收件人邮箱地址
        //        message.To.Add(to);//设置邮件接收人，MailMessage类的To属性可以Add多个接收人
        //    }
        //    else
        //    {
        //        MessageBox.Show("收件人邮箱地址不正确");
        //        return;
        //    }
        //}
        //else
        //{
        //    MessageBox.Show("收件人不能为空");
        //    return;
        //}


      
        //message.Subject = txtTitle.Text;//获取输入的邮件标题
        //message.Body = rtbContext.Text;//获取输入的邮件正文
        //message.From = from;//设置邮件发件人          
        //client.Send(message);
        //MessageBox.Show("发送成功");

        }
    }
}
