using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HPIT.ClockIn.Web.Content
{
    public class EncryptHelper
    {
        public static string GerMd5Hash(string str)
        {
            using (MD5 md5Obj = MD5.Create())
            {
                //把原始字符串转成字节数组
                byte[] by = Encoding.UTF8.GetBytes(str);
                byte[] md5Bytes = md5Obj.ComputeHash(by);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5Bytes.Length; i++)
                {
                    //拼接
                    sb.Append(md5Bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}