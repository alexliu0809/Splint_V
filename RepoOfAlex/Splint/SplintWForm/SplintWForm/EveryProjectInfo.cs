using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplintWForm
{
    public class EveryProjectInfo
    {
        public enum projectInfoType
        {
            fInfo = 1,
            dInfo=2,
            noInfo=-1,
        }
        public TreeNode treeItem;
        public FileInfo fileInfo;
        public DirectoryInfo directoryInfo;
        public string ans;//测试用。
        public List<string> Descriptions = new List<string>();
        public string Code;
        public projectInfoType infoType;
        public EveryProjectInfo()
        {
            this.infoType=EveryProjectInfo.projectInfoType.noInfo;
        }
    }
}
