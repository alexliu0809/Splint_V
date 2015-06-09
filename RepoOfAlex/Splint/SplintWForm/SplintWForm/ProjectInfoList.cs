using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplintWForm
{
    class ProjectInfoList
    {
        
        private List<EveryProjectInfo> ProjectInfoL;
        public ProjectInfoList()
        {
            ProjectInfoL = new List<EveryProjectInfo>();
        }
        /// <summary>
        /// Itemheader or FileInfoName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //public FileInfo FindFileInfoByTreeViewItemName(string name)
        //{

            
        //}
        public void RegisterProjecInfo(EveryProjectInfo tempEPI)
        {
            for (int i = ProjectInfoL.Count - 1; i >= 0; i--)
            {
                if (ProjectInfoL[i].infoType == EveryProjectInfo.projectInfoType.fInfo)
                {
                    if (ProjectInfoL[i].fileInfo.FullName == tempEPI.fileInfo.FullName)
                    {
                        ProjectInfoL[i]=tempEPI;
                        return ;
                    }
                }
            }
            ProjectInfoL.Add(tempEPI);
            return ;
        }
        public void removeProjecInfo(string name)
        {
            for (int i = ProjectInfoL.Count - 1; i >= 0; i--)
            {
                if (ProjectInfoL[i].infoType == EveryProjectInfo.projectInfoType.fInfo)
                {
                    if (ProjectInfoL[i].fileInfo.Name == name)
                    {
                        ProjectInfoL.RemoveAt(i);
                    }
                }
            }
        }
        public int getTotalLine()
        {
            int total = -1;
            if (this.ProjectInfoL.Count != 0 && this.ProjectInfoL != null)
            {
                total = 0;
                for (int i = 0; i < ProjectInfoL.Count; i++)
                {
                    total += ProjectInfoL[i].Code.Split(new[] { "\r\n" }, StringSplitOptions.None).Length-1;
                }
            }
            return total;
        }

        /// <summary>
        /// 出错返回-1，没有返回0，
        /// </summary>
        /// <returns></returns>
        public int getTotalError()
        {
            int total = -1;
            string ans = ProjectInfoL[0].ans;
            if (ans.Contains("Cannot continue."))
            {
                return -1; 
            }
            else
            {
                total = 0;
                string[] temp = ans.Split(new[] { "\r\n" }, StringSplitOptions.None);
                for (int i = 1; i < temp.Length; i++)
                {
                    if (temp[i].Contains("Total")&&temp[i-1].Contains("==="))
                    {
                        string pattern = @"[0-9]+";
                        Match match = System.Text.RegularExpressions.Regex.Match(temp[i], pattern);
                        if (match.Success == true)
                        {
                            total = Convert.ToInt32(match.Value);
                            return total;
                        }
                    }
                }
                return total;
            }
            return -1;
        }

        public Data[] getErrorData(int total)
        {
            if (total==0)
            {
                return new Data[0];
            }
            string ans = ProjectInfoL[0].ans;
            if (ans.Contains("Cannot continue."))
            {
                Data[] temp = new Data[1];
                temp[0].name = "Cannot continue";
                temp[0].num = 1;
                return temp;
            }
            else
            {
                string[] tempString = ans.Split(new[] { "\r\n" }, StringSplitOptions.None);
                for (int i = 1; i < tempString.Length; i++)
                {
                    if (tempString[i].Contains("==="))
                    {
                        int len=0;
                        for (int j = 0; j < total; j++)
                        {
                            if (tempString[i + j + 1].Contains("==="))
                            {
                                break;
                            }
                            else
                            {
                                len++;
                            }
                        }


                        Data[] temp=new Data[len];
                        for (int j = 0; j < len; j++)
                        {
                            //if (tempString[i + j + 1].Contains("==="))
                            //{
                                
                            //    return temp;
                            //}
                            string pattern = @"\w+";
                            Match match = System.Text.RegularExpressions.Regex.Match(tempString[i+j+1], pattern);
                            temp[j] = new Data();
                            temp[j].name = match.Value.ToString();
                            pattern = @"\d+";
                            match = System.Text.RegularExpressions.Regex.Match(tempString[i + j + 1], pattern);
                            temp[j].num = Convert.ToInt32(match.Value);
                            
                        }
                        return temp;
                    }
                }
            }
            return new Data[0];
        }

        public void checkExist()
        {
        }

        public string getCodeByName()
        {
            return "";
        }
        public EveryProjectInfo getProjectInfoByFullName(string fullName)
        {
            for (int i = ProjectInfoL.Count - 1; i >= 0; i--)
            {
                if (ProjectInfoL[i].infoType == EveryProjectInfo.projectInfoType.fInfo)
                {
                    if (ProjectInfoL[i].fileInfo.FullName == fullName)
                    {
                        return ProjectInfoL[i];
                    }
                }
            }
            return null;
        }
        public void updateProjectInfo(EveryProjectInfo fi)
        {
            for (int i = ProjectInfoL.Count - 1; i >= 0; i--)
            {
                if (ProjectInfoL[i].fileInfo.FullName == fi.fileInfo.FullName)
                {
                    ProjectInfoL[i] = fi;
                }
            }
        }
        public int length()
        {
            return ProjectInfoL.Count;
        }
        public EveryProjectInfo getProjectInfoAt(int index)
        {
            EveryProjectInfo temp = new EveryProjectInfo();
            if (index <= ProjectInfoL.Count - 1)
            {
                temp = ProjectInfoL[index];
                return temp;
            }
            return null;
        }
        
    }
}
