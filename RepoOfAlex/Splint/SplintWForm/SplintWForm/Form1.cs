using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
//using Microsoft.Office.Tools.Word;

namespace SplintWForm
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 保存项目分析结果
        /// </summary>
        databaseInfoClass dbIC;
        /// <summary>
        /// 只存文件不存文件夹
        /// </summary>
        private ProjectInfoList projectInfoList = new ProjectInfoList();
        private RunProcess myRunProcess = new RunProcess();
        private EveryProjectInfo curProjectInfo = null;
        private string projectHeadString = null;
        /// <summary>
        /// 存储更目录信息，可以是文件或者是文加件
        /// </summary>
        private string rootPath="";
        private string projectEndString = null;
        private string projectWholeAns = null;
        private string flagCommand = "";
        private bool analyzed=false;
        private ScintillaNET.Scintilla TB_CodeArea = new ScintillaNET.Scintilla();
        public MainForm()
        {
            InitializeComponent();
            SetToDefault();
            Control.CheckForIllegalCrossThreadCalls = false;
            SetScintilla();
            
           // Thread checkPosition = new Thread(CodeAreaCursorChanged);
           // checkPosition.IsBackground = true;
           // checkPosition.Start();
        }
        private void SetScintilla()
        {
            TB_CodeArea.Margins[0].Width = 50;
            TB_CodeArea.Margins[0].AutoToggleMarkerNumber = 0;
            TB_CodeArea.Margins[0].Mask = 2;
            TB_CodeArea.Location = new System.Drawing.Point(230, 75);
            TB_CodeArea.Size = new Size(673, 230);
            TB_CodeArea.ConfigurationManager.Language = "cpp";
            TB_CodeArea.IsReadOnly = true;
            //_CodeArea_SelectionChanged+= new System.EventHandler(this.TB_CodeArea_SelectionChanged);
            TB_CodeArea.SelectionChanged += new System.EventHandler(this.TB_CodeArea_SelectionChanged);
            this.Controls.Add(TB_CodeArea);
            TB_CodeArea.Show();
        }
        private void 生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 用Slpint生成本文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TB_DebugInfo.Text = "";//Clear
            if (curProjectInfo != null)
            {
                UseSplintToAnalyzeSingleFile(curProjectInfo);
                SetAnalysisAnsOnly(curProjectInfo.ans);
                
                if (rootPath.Contains(".h")||rootPath.Contains(".c"))
                {
                    analyzed=true;
                }

            }
            else
            {
                AppendDebugArea("No Source File opened!\n");
            }

        }
        public string[] ansArray1;
        /// <summary>
        /// 打开文件后创建文件信息
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        private EveryProjectInfo CreateInfo(FileInfo fi)
        {
            //代码，文件信息
            EveryProjectInfo everyProjectInfo = new EveryProjectInfo();
            everyProjectInfo.fileInfo = fi;
            everyProjectInfo.Code = ReadCodeFromFile(fi);
            everyProjectInfo.infoType = EveryProjectInfo.projectInfoType.fInfo;
            return everyProjectInfo;
        }
        private EveryProjectInfo CreateInfo(DirectoryInfo di)
        {
            //代码，文件信息
            EveryProjectInfo everyProjectInfo = new EveryProjectInfo();
            everyProjectInfo.directoryInfo = di;
            everyProjectInfo.infoType = EveryProjectInfo.projectInfoType.dInfo;
            return everyProjectInfo;
        }

        private void AppendDebugArea(string tmp)
        {
            TB_DebugInfo.AppendText(tmp);
        }


        private string adjustAnsArray(string[] ansArray)
        {
            List<string> tempList=new List<string>();
            string tempString = "";
            bool connectFlag=false;
            for (int i = 0; i < ansArray.Length - 1; i++)
            {
                if (ansArray[i].Contains("Cannot continue.") || ansArray[i].Contains("Finished checking") || ansArray[i].Contains("Error Type"))
                {
                    tempString += "\r\n";
                    tempList.Add(tempString);//结束上面一句
                    for (int j = i; j < ansArray.Length - 1; j++)
                    {
                        tempString = ansArray[j];
                        tempString += "\r\n";
                        tempList.Add(tempString);
                        
                    }
                    break;
                    
                }
                if (ansArray[i].Contains(@":\") == false && !connectFlag) //不含不连接，单独一句
                {
                    ansArray[i] += "\r\n";
                    tempList.Add(ansArray[i]);
                    connectFlag = false;
                }
                else if (ansArray[i].Contains(@":\") == true && !connectFlag) //第一句，开始连
                {
                    tempString = ansArray[i];
                    connectFlag = true;
                }
                else if (ansArray[i].Contains(@":\") == false && connectFlag) //继续链接
                {
                    tempString += ansArray[i];
                }
                else if (ansArray[i].Contains(@":\") == true && connectFlag)//链接结束
                {
                    tempString += "\r\n";
                    tempList.Add(tempString);//结束上面一句
                    tempString = ansArray[i];
                }
            }

            //string[] adjustedArray = new string[tempList.Count];
            //for (int i = 0; i <= tempList.Count - 1; i++)
            //{
            //    adjustedArray[i] = tempList[i];
            //}
            //return adjustedArray;

            string finalAns = "";
            for (int i = 0; i <= tempList.Count - 1; i++)
            {
                finalAns += tempList[i];
            }
            return finalAns;
        }

        /// <summary>
        /// 使用Splint分析整个工程
        /// </summary>
        private void UseSplintToAnalyzeProjectFile()
        {
            string commandLine = "";
            for (int i = 0; i <= projectInfoList.length() - 1; i++)
            {
                commandLine += projectInfoList.getProjectInfoAt(i).fileInfo.FullName;
                commandLine += " ";
                
            }
            string ans = myRunProcess.Run(@".\splint.exe", ff.getFlagCommand()+commandLine);
            AppendDebugArea("项目使用Splint分析完毕\n");

            string[] ansArray = ans.Split(new[] { "\r\n" }, StringSplitOptions.None);
           // string[] ajustedArray=adjustAnsArray(ansArray);
            string adjustedString = adjustAnsArray(ansArray);
            projectWholeAns = adjustedString;

            for (int i = 0; i <= projectInfoList.length() - 1; i++)
            {
                projectInfoList.getProjectInfoAt(i).ans = adjustedString;

            }
            curProjectInfo = projectInfoList.getProjectInfoAt(projectInfoList.length()-1);


        }
        /// <summary>
        /// 使用Splint分析特定文件,注意判空。
        /// </summary>
        /// <param name="fi"></param>
        private void UseSplintToAnalyzeSingleFile(EveryProjectInfo fi)
        {

            string ans = myRunProcess.Run(@".\splint.exe", ff.getFlagCommand()+fi.fileInfo.FullName);
            string[] ansArray = ans.Split(new[] { "\r\n" }, StringSplitOptions.None);
            ansArray1 = ansArray;
            // string[] ajustedArray=adjustAnsArray(ansArray);
            string adjustedString = adjustAnsArray(ansArray);
            fi.ans = adjustedString;
            projectInfoList.updateProjectInfo(fi);
            AppendDebugArea(fi.fileInfo.Name + "使用Splint分析完毕\n");

        }
        private void SetAnalysisAnsOnly(string ans)
        {
            TB_AnalyzeResult.Text = "";
            TB_AnalyzeResult.Text = ans;
            return;
        }
        private void SetCodeOnly(string code)
        {
            TB_CodeArea.IsReadOnly = false;
            TB_CodeArea.Text = code;
            TB_CodeArea.IsReadOnly = true;
        }
        /// <summary>
        /// 使用文件信息读取其中的代码
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        private string ReadCodeFromFile(FileInfo fi)
        {
            try
            {
                using (StreamReader SR = new StreamReader(fi.FullName))
                {
                    string Code = null;
                    Code = SR.ReadToEnd();//读取字符文件
                    return Code;
                }
            }
            catch
            {
                AppendDebugArea("读入数据出错");
                return null;
            }
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "(*.c,*.h)|*.c|(*.c,*.h)|*.h";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                //清空
                SetToDefault();
                
                FileInfo SingleFileInformation = new FileInfo(OFD.FileName);
                EveryProjectInfo tempProjectInfo = CreateInfo(SingleFileInformation);//生成INFO
                rootPath=tempProjectInfo.fileInfo.FullName;//保存文件地址
                CreateNode(null, tempProjectInfo);//添加到Tree
                projectInfoList.RegisterProjecInfo(tempProjectInfo);
                curProjectInfo = tempProjectInfo;
                SetCodeArea(curProjectInfo.fileInfo.Name, curProjectInfo.Code);
                ChangeSourceFileNameLabel(curProjectInfo.fileInfo.Name);
                TB_CodeArea.Focus();
            }
        }
        private void SetToDefault()
        {
            analyzed=false;
            TV_ProjectInfo.Nodes.Clear();

            SetCodeOnly("");

            TB_DebugInfo.Text = "";
            TB_AnalyzeResult.Text = "";
            L_SourceFileName.Text = "源文件名";
            projectInfoList = new ProjectInfoList();
            curProjectInfo = null;
            projectWholeAns = "";
            rootPath="";
        }
        private void ChangeSourceFileNameLabel(string name)
        {
            L_SourceFileName.Text = name;
        }

        private void 打开项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            // if (FBD.ShowDialog() == DialogResult.OK || FBD.ShowDialog() == DialogResult.Yes)
            // {
            try
            {

                FBD.ShowDialog();
                if (FBD.SelectedPath != null)
                {
                    SetToDefault();
                    string beginPath = FBD.SelectedPath;
                    rootPath=beginPath;
                    DirectoryInfo tempDI = new DirectoryInfo(beginPath);
                    EveryProjectInfo tempPI = CreateInfo(tempDI);
                    CreateTree(null, tempPI);
                }
            }
            catch
            {
                AppendDebugArea("打开地址不对！\n");
            }
            // }
        }

        private void CreateTree(TreeNode parNode, EveryProjectInfo everyProjectInfo)
        {
            TreeNode tempTreeNode = new TreeNode();
            if (everyProjectInfo.infoType == EveryProjectInfo.projectInfoType.dInfo)
            {
                SetNodeInfo(tempTreeNode, everyProjectInfo.directoryInfo);
            }
            else if (everyProjectInfo.infoType == EveryProjectInfo.projectInfoType.fInfo)
            {
                SetNodeInfo(tempTreeNode, everyProjectInfo.fileInfo);
            }

            if (parNode == null)
            {
                TV_ProjectInfo.Nodes.Add(tempTreeNode);
                everyProjectInfo.treeItem = tempTreeNode;

                if (everyProjectInfo.infoType == EveryProjectInfo.projectInfoType.dInfo)
                {
                    //文件夹
                    foreach (string dirPath in Directory.GetDirectories(everyProjectInfo.directoryInfo.FullName))
                    {
                        DirectoryInfo tempDI = new DirectoryInfo(dirPath);
                        EveryProjectInfo tempPI = CreateInfo(tempDI);
                        CreateTree(tempTreeNode, tempPI);
                    }
                    //文件
                    foreach (string filePath in Directory.GetFiles(everyProjectInfo.directoryInfo.FullName))
                    {

                        FileInfo tempDI = new FileInfo(filePath);
                        if (tempDI.Name.EndsWith(".c") || tempDI.Name.EndsWith(".h"))
                        {
                            EveryProjectInfo tempPI = CreateInfo(tempDI);
                            TreeNode sonTreeNode = new TreeNode();
                            SetNodeInfo(sonTreeNode, tempDI);

                            tempTreeNode.Nodes.Add(sonTreeNode);
                            tempPI.treeItem = sonTreeNode;
                            projectInfoList.RegisterProjecInfo(tempPI);
                          //  curProjectInfo = tempPI;
                        }
                    }
                }
                else
                {
                    projectInfoList.RegisterProjecInfo(everyProjectInfo);
                   // curProjectInfo = everyProjectInfo;
                }
            }
            else
            {
                parNode.Nodes.Add(tempTreeNode);
                everyProjectInfo.treeItem = tempTreeNode;
                if (everyProjectInfo.infoType == EveryProjectInfo.projectInfoType.dInfo)
                {
                    foreach (string dirPath in Directory.GetDirectories(everyProjectInfo.directoryInfo.FullName))
                    {
                        DirectoryInfo tempDI = new DirectoryInfo(dirPath);
                        EveryProjectInfo tempPI = CreateInfo(tempDI);
                        CreateTree(tempTreeNode, tempPI);
                    }
                    //如果是文件的话，继续扩展
                    foreach (string filePath in Directory.GetFiles(everyProjectInfo.directoryInfo.FullName))
                    {
                        FileInfo tempDI = new FileInfo(filePath);
                        if (tempDI.Name.EndsWith(".c") || tempDI.Name.EndsWith(".h"))
                        {
                            EveryProjectInfo tempPI = CreateInfo(tempDI);
                            TreeNode sonTreeNode = new TreeNode();
                            SetNodeInfo(sonTreeNode, tempDI);
                            tempTreeNode.Nodes.Add(sonTreeNode);
                            tempPI.treeItem = sonTreeNode;
                            projectInfoList.RegisterProjecInfo(tempPI);
                          //  curProjectInfo = tempPI ;
                        }
                    }
                }
                else
                {
                    projectInfoList.RegisterProjecInfo(everyProjectInfo);
                   // curProjectInfo = everyProjectInfo;
                }

            }

        }

        /// <summary>
        /// 自动创建TreeView节点。
        /// </summary>
        /// <param name="parNode"></param>
        /// <param name="everyProjectInfo"></param>
        private void CreateNode(TreeNode parNode, EveryProjectInfo everyProjectInfo)
        {
            TreeNode tempTreeNode = new TreeNode();
            SetNodeInfo(tempTreeNode, everyProjectInfo.fileInfo);
            if (parNode == null)
            {
                TV_ProjectInfo.Nodes.Add(tempTreeNode);
                everyProjectInfo.treeItem = tempTreeNode;

            }
            else
            {
                parNode.Nodes.Add(tempTreeNode);
                everyProjectInfo.treeItem = tempTreeNode;
            }

        }

        private void TV_ProjectInfo_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name.EndsWith(".c") || e.Node.Name.EndsWith(".h"))
            {
                EveryProjectInfo temp = projectInfoList.getProjectInfoByFullName(e.Node.Name);
                if (temp != curProjectInfo)
                {
                    curProjectInfo = temp;
                    if (curProjectInfo == null)
                    {
                        AppendDebugArea("读取出错,重置数据！\n");
                        SetToDefault();
                    }
                    else
                    {
                        SetCodeArea(curProjectInfo.fileInfo.Name, curProjectInfo.Code);
                        SetAnalysisAnsOnly(curProjectInfo.ans);
                    }
                }
            }
        }
        /// <summary>
        /// 双击输出结果是使用
        /// </summary>
        private void AnalyzeResult_NodeMouseDoubleClick(EveryProjectInfo e)
        {
            if (e.fileInfo.Name.EndsWith(".c") || e.fileInfo.Name.EndsWith(".h"))
            {
               

                    curProjectInfo = e;
                    if (curProjectInfo == null)
                    {
                        AppendDebugArea("读取出错,重置数据！\n");
                        SetToDefault();
                    }
                    else
                    {
                        SetCodeArea(curProjectInfo.fileInfo.Name, curProjectInfo.Code);
                    }
                }
            
        }

        private void SetNodeInfo(TreeNode sonTreeNode, FileInfo tempPI)
        {
            sonTreeNode.Text = tempPI.Name;
            sonTreeNode.Name = tempPI.FullName;
        }
        private void SetNodeInfo(TreeNode sonTreeNode, DirectoryInfo tempPI)
        {
            sonTreeNode.Text = tempPI.Name;
            sonTreeNode.Name = tempPI.FullName;
        }
        private void SetCodeArea(string labe, string code)
        {
            TB_CodeArea.IsReadOnly = false;
            TB_CodeArea.Text = code;
            TB_CodeArea.IsReadOnly = true;
            L_SourceFileName.Text = labe;
        }
        private void SetAnalysisArea(List<string> ans)
        {
            TB_AnalyzeResult.Text = "";
            if (ans != null)
            {
                for (int i = 0; i <= ans.Count - 1; i++)
                {
                    TB_AnalyzeResult.AppendText(ans[i]);
                }
            }
        }

        private void 用Splint生成本项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EveryProjectInfo temp = new EveryProjectInfo();
            if (projectInfoList.length() > 0)
            {
                TB_DebugInfo.Text = "";//Clear
                for (int i = 0; i <= projectInfoList.length() - 1; i++)
                {
                    temp = projectInfoList.getProjectInfoAt(i);
                    if (temp != null)
                    {
                        UseSplintToAnalyzeSingleFile(temp);
                    }

                }
                if (temp != null)
                {
                    curProjectInfo = temp;
                    SetAnalysisAnsOnly(curProjectInfo.ans);
                    SetCodeArea(curProjectInfo.fileInfo.Name, curProjectInfo.Code);
                    if (TV_ProjectInfo.SelectedNode != null)
                    {
                        TV_ProjectInfo.SelectedNode.Checked = false;
                    }
                    //Focus到调试窗口
                    ChangeFocusOfTreeView();

                }
            }
            else
            {
                AppendDebugArea("当前打开目录为空!\n");
            }
        }

        private void ChangeFocusOfTreeView()
        {
            TravelTreeRecursive(TV_ProjectInfo.Nodes);
        }
        private void TravelTreeRecursive(TreeNodeCollection tmp)
        {
            foreach (TreeNode n in tmp)
            {
                if (n.Name == curProjectInfo.fileInfo.FullName)
                {
                    n.Checked = true;
                    TV_ProjectInfo.SelectedNode = n;
                    TV_ProjectInfo.Focus();
                    return;
                }
                TravelTreeRecursive(n.Nodes);
            }
        }
        
        //private void CodeAreaCursorChanged()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            if (TB_CodeArea.Text != "" && TB_CodeArea.SelectionStart >= 0)
        //            {
        //                int lineIndex = TB_CodeArea.SelectionStart;
        //                int line = TB_CodeArea.GetLineFromCharIndex(lineIndex);
        //                L_CodeLine.Text = "第" + (line + 1).ToString() + "行\n";
        //            }
        //            else
        //            {
        //                L_CodeLine.Text = "光标位置\n";
        //            }
        //            Thread.Sleep(100);
        //            //// MessageBox.Show(lineIndex.ToString());
        //            //int line = TB_CodeArea.GetLineIndexFromCharacterIndex(lineIndex);
        //            //MessageBox.Show(line.ToString());
        //            //获取鼠标所在行
        //            //TB_CodeArea.SelectionStart = TB_CodeArea.GetFirstCharIndexFromLine(line);
        //            //TB_CodeArea.Focus();
        //        }
        //    }
        //    catch
        //    {
        //    }

        //}
        private void TB_CodeArea_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (TB_CodeArea.Text != "" && TB_CodeArea.Selection.Start >= 0)
                {
                    int lineIndex = TB_CodeArea.Selection.Start;
                    int line = TB_CodeArea.Lines.Current.Number;
                    L_CodeLine.Text = "第" + (line + 1).ToString() + "行\n";
                }
                else
                {
                    L_CodeLine.Text = "光标位置\n";
                }
                Thread.Sleep(400);
                //// MessageBox.Show(lineIndex.ToString());
                //int line = TB_CodeArea.GetLineIndexFromCharacterIndex(lineIndex);
                //MessageBox.Show(line.ToString());
                //获取鼠标所在行
                //TB_CodeArea.SelectionStart = TB_CodeArea.GetFirstCharIndexFromLine(line);
                //TB_CodeArea.Focus();
            }

            catch
            {
            }
        }
        private void L_CodeLine_Click(object sender, EventArgs e)
        {

        }

        private void 导出WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbIC = new databaseInfoClass();
            dbIC.fullPath = rootPath;
            dbIC.ver = DataBase.BanbenOfWenjian(rootPath) + 1;
            int totalLine = this.projectInfoList.getTotalLine();
            int totalError = this.projectInfoList.getTotalError();

            Data[] errorData = this.projectInfoList.getErrorData(totalError);

            if (totalError == -1)
            {
                dbIC.errorLevel = 5;
            }
            else if (totalError == 0)
            {
                dbIC.errorLevel = 1;
            }
            else
            {
                double rate = totalError / totalLine;
                if (rate <= 0.1)
                {
                    dbIC.errorLevel = 1;
                }
                else if (rate <= 0.4)
                {
                    dbIC.errorLevel = 2;
                }
                else if (rate <= 0.7)
                {
                    dbIC.errorLevel = 3;
                }
                else if (rate <= 1.0)
                {
                    dbIC.errorLevel = 4;
                }
                else
                {
                    dbIC.errorLevel = 5;
                }
            }
            dbIC.addList(errorData);
            
            //string name, int banbenhao, Data[] data, int cuowuleixingshumu, int dengji
            string str2 = Environment.CurrentDirectory;
            int a = Word.StoreWord(dbIC.fullPath, dbIC.ver, errorData, errorData.Length, dbIC.errorLevel, str2 + "//22.doc", str2 + "//new.dot");
            int aa = DataBase.storedata(dbIC.fullPath, dbIC.ver, errorData, errorData.Length, dbIC.errorLevel);
            Thread.Sleep(100);
            Process tempP = System.Diagnostics.Process.Start(str2 + "//22.doc");
    
        }
        

        private void 用Splint整体分析项目文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectInfoList.length() > 0)
            {
                TB_AnalyzeResult.Text = "";
                TB_CodeArea.Text = "";
                TB_DebugInfo.Text = "";
                EveryProjectInfo temp = new EveryProjectInfo();
                UseSplintToAnalyzeProjectFile();
                SetAnalysisAnsOnly(curProjectInfo.ans);
                SetCodeArea(curProjectInfo.fileInfo.Name, curProjectInfo.Code);
                if (TV_ProjectInfo.SelectedNode != null)
                {
                    TV_ProjectInfo.SelectedNode.Checked = false;
                }
                analyzed=true;
                //Focus到调试窗口
                ChangeFocusOfTreeView();
            }
            else
            {
                AppendDebugArea("Error:No file opened");
            }
        }

        private void TB_AnalyzeResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TB_AnalyzeResult.Text != "")
            {

                int lineIndex = TB_AnalyzeResult.SelectionStart;
                int line = TB_AnalyzeResult.GetLineFromCharIndex(lineIndex);
                string pattern = @"\(\d+?,\d+?\)";
                string thisLineString = TB_AnalyzeResult.Lines[line];

                //Match match = System.Text.RegularExpressions.Regex.Match(thisLineString, pattern);
                //if (match.Success == true && thisLineString.Contains(curProjectInfo.fileInfo.FullName))
                //{
                //    string value = match.Groups[0].Value;
                //    char[] charValue = value.ToCharArray();
                //    char[] tempCharArray = new char[1000];
                //    int index = value.IndexOf(',');
                //    for (int i = 1; i <= index - 1; i++)
                //    {
                //        tempCharArray[i - 1] = charValue[i];
                //    }
                //    int codeLine = Convert.ToInt32(new string(tempCharArray));

                //    TB_CodeArea.Selection.Start = TB_CodeArea.Lines[codeLine - 1].StartPosition;
                //    TB_CodeArea.Selection.End = TB_CodeArea.Lines[codeLine - 1].EndPosition;
                //    //   TB_CodeArea.SelectionStart = TB_CodeArea.GetFirstCharIndexFromLine(codeLine - 1);
                //    //   TB_CodeArea.SelectionLength = TB_CodeArea.Lines[codeLine - 1].Length;
                //    TB_CodeArea.Focus();
                //}
                int flag=0;
                Match match = System.Text.RegularExpressions.Regex.Match(thisLineString, pattern);
                if (match.Success == true )
                {
                    EveryProjectInfo tempEPI=new EveryProjectInfo();
                    for (int i=0;i<projectInfoList.length();i++)
                    {
                        tempEPI=projectInfoList.getProjectInfoAt(i);
                        if (tempEPI.infoType==EveryProjectInfo.projectInfoType.fInfo)
                        {
                            if (thisLineString.Contains(tempEPI.fileInfo.FullName) == true)
                            {
                                flag = 1;
                                break;
                            }
                                    
                        }
                    }
                    if (flag==1)
                    {


                        string value = match.Groups[0].Value;
                        char[] charValue = value.ToCharArray();
                        char[] tempCharArray = new char[1000];
                        int index = value.IndexOf(',');
                        for (int i = 1; i <= index - 1; i++)
                        {
                            tempCharArray[i - 1] = charValue[i];
                        }
                        int codeLine = Convert.ToInt32(new string(tempCharArray));
                        AnalyzeResult_NodeMouseDoubleClick(tempEPI);
                        TB_CodeArea.Selection.Start = TB_CodeArea.Lines[codeLine - 1].StartPosition;
                        TB_CodeArea.Selection.End = TB_CodeArea.Lines[codeLine - 1].EndPosition;
                        //   TB_CodeArea.SelectionStart = TB_CodeArea.GetFirstCharIndexFromLine(codeLine - 1);
                        //   TB_CodeArea.SelectionLength = TB_CodeArea.Lines[codeLine - 1].Length;
                        TB_CodeArea.Focus();
                    }
                }


            }
        }
        Form2 form2;
        Form3 form3;
        Form5 form5;
        //Form3 form3;
        private void 生成报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2=new Form2();
            form2.ShowDialog(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 历史版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.ShowDialog();
        }

        private void TB_CodeArea_TextChanged(object sender, EventArgs e)
        {

        }


        


        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rootPath != null && rootPath != "")
            {

                if (analyzed == true)
                {
                    dbIC = new databaseInfoClass();
                    dbIC.fullPath = rootPath;
                    dbIC.ver = DataBase.BanbenOfWenjian(rootPath) + 1;
                    int totalLine = this.projectInfoList.getTotalLine();
                    int totalError = this.projectInfoList.getTotalError();

                    Data[] errorData = this.projectInfoList.getErrorData(totalError);

                    if (totalError == -1)
                    {
                        dbIC.errorLevel = 5;
                    }
                    else if (totalError == 0)
                    {
                        dbIC.errorLevel = 1;
                    }
                    else
                    {
                        double rate = totalError / totalLine;
                        if (rate <= 0.1)
                        {
                            dbIC.errorLevel = 1;
                        }
                        else if (rate <= 0.4)
                        {
                            dbIC.errorLevel = 2;
                        }
                        else if (rate <= 0.7)
                        {
                            dbIC.errorLevel = 3;
                        }
                        else if (rate <= 1.0)
                        {
                            dbIC.errorLevel = 4;
                        }
                        else
                        {
                            dbIC.errorLevel = 5;
                        }
                    }
                    dbIC.addList(errorData);
                    int aa = DataBase.storedata(dbIC.fullPath, dbIC.ver, errorData, errorData.Length, dbIC.errorLevel);
                    AppendDebugArea("保存成功");


                }
                else
                {
                    AppendDebugArea("请先分析文件");
                }

            }
            else
            {
                AppendDebugArea("请先打开文件");
            }
        }
        FormFlag ff=new FormFlag(); 
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff.Show();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form5 = new Form5();
            form5.ShowDialog();
        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
