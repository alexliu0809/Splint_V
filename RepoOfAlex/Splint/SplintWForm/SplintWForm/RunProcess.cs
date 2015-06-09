using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SplintWForm
{
    class ReadErrorThread
    {
        System.Threading.Thread m_Thread;
        System.Diagnostics.Process m_Process;
        String m_Error;
        bool m_HasExisted;
        object m_LockObj = new object();

        public String Error
        {
            get
            {
                return m_Error;
            }
        }

        public bool HasExisted
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_HasExisted;
                }
            }

            set
            {
                lock (m_LockObj)
                {
                    m_HasExisted = value;
                }
            }
        }

        private void ReadError()
        {
            StringBuilder strError = new StringBuilder();
            while (!m_Process.HasExited)
            {
                strError.Append(m_Process.StandardError.ReadLine());
            }

            strError.Append(m_Process.StandardError.ReadToEnd());

            m_Error = strError.ToString();
            HasExisted = true;
        }

        public ReadErrorThread(System.Diagnostics.Process p)
        {
            HasExisted = false;
            m_Error = "";
            m_Process = p;
            m_Thread = new Thread(new ThreadStart(ReadError));
            m_Thread.Start();
        }

    }

    class RunProcess
    {
        private String m_Error;
        private String m_Output;

        public String Error
        {
            get
            {
                return m_Error;
            }
        }

        public String Output
        {
            get
            {
                return m_Output;
            }
        }

        public bool HasError
        {
            get
            {
                return m_Error != "" && m_Error != null;
            }
        }

        public string Run(String fileName, String para)
        {
            StringBuilder outputStr = new StringBuilder();

            try
            {
                //		para	"C:\\Users\\Alex's Alienware\\Documents\\Visual Studio 2012\\Projects\\Project5\\Project5\\源.c"	string

                //disable the error report dialog. 
                //reference: http://www.devcow.com/blogs/adnrg/archive/2006/07/14/Disable-Error-Reporting-Dialog-for-your-application-with-the-registry.aspx 
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"software\microsoft\PCHealth\ErrorReporting\", true);
                int doReport = (int)key.GetValue("DoReport");

                if (doReport != 0)
                {
                    key.SetValue("DoReport", 0);
                }

                int showUI = (int)key.GetValue("ShowUI");
                if (showUI != 0)
                {
                    key.SetValue("ShowUI", 0);
                }
            }
            catch
            {
            }


            m_Error = "";
            m_Output = "";
            try
            {
                //前面都不用管。
                System.Diagnostics.Process p = new System.Diagnostics.Process();

                p.StartInfo.FileName = fileName;
                p.StartInfo.Arguments = para; //参数可以不需要
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;  //是否创建窗口

                p.Start();

                ReadErrorThread readErrorThread = new ReadErrorThread(p);
                //p.StandardInput.WriteLine(@"cd C:\splint\splint-3.1.2\bin");
                //p.StandardInput.WriteLine(@"splint.exe a.c");
                Thread.Sleep(10);
             //  while (!p.HasExited)
         //       {
                //    //string outstr, instr;
                //    //读取字符操作：
                //    //p.StandardInput.WriteLine("hello");

                //    //Console.WriteLine(p.StandardOutput.ReadLine());

                //    //注意进程关闭的问题
                //    //向进程输出关闭命令。或者P.kill
                //    //p.Kill();

                //    Console.WriteLine(p.StandardOutput.ReadLine());
                 //   outputStr.Append(p.StandardOutput.ReadToEnd());
              //      p.StandardInput.WriteLine("exit");
             //   }
                Thread.Sleep(10);
                outputStr.Append(p.StandardOutput.ReadToEnd());
                //Console.WriteLine(outputStr);
                while (!readErrorThread.HasExisted)
                {
                    Thread.Sleep(1);
                }

                m_Error = readErrorThread.Error;
                m_Output = outputStr.ToString();
                return outputStr.ToString();
            }
            catch (Exception e)
            {

                return "启动Splint出错";
                m_Error = e.Message;
            }
        }
    }
}
  