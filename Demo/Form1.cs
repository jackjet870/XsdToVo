using System.Collections.Generic;
using System.Windows.Forms;
using XsdToVo.Method;
using XsdToVo.Vo;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateVo.CreateDirectory();
        }

        #region  字段和属性
        private List<AnalysisVo> voList = new List<AnalysisVo>();
        /// <summary>
        /// 实体类列表
        /// </summary>
        public List<AnalysisVo> VoList
        {
            get
            {
                return voList;
            }

            set
            {
                voList = value;
            }
        }

        private Dictionary<string, string> dicType = new Dictionary<string, string>();
        /// <summary>
        /// 键值对Type
        /// </summary>
        public Dictionary<string, string> DicType
        {
            get
            {
                return dicType;
            }

            set
            {
                dicType = value;
            }
        }

        #endregion

        /// <summary>
        /// 打开基础类XSD文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBaseXsd_Click(object sender, System.EventArgs e)
        {
            if (DicType.Count > 0)
                DicType.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XSD文件（.xsd）|*.xsd";
            openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                txtboxBaseXsd.Text = openFileDialog.FileName;
                AnalysisBaseType analysisyBaseType = new AnalysisBaseType(openFileDialog.FileName);
                analysisyBaseType.Analysis();
                DicType = analysisyBaseType.DicType;
                if (DicType.Count <= 0)
                {
                    MessageBox.Show("导入的基础库无法解析成键值对集合，请确认导入的是否是基础库，如果是基础库又出现此提示请联系闫超。");
                    return;
                }
                else
                {
                    MessageBox.Show("文件读取成功");
                }
            }
            ReplaceContent();
        }
        /// <summary>
        /// 打开要解析的XSD文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalXsd_Click(object sender, System.EventArgs e)
        {
            if (VoList.Count > 0)
                VoList.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XSD文件（.xsd）|*.xsd";
            openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                txtboxAnalXsd.Text = openFileDialog.FileName;
                AnalysisXsd analysisXsd = new AnalysisXsd(openFileDialog.FileName);
                analysisXsd.Analysis();
                VoList = analysisXsd.VoList;
                if (VoList.Count <= 0)//无法解析
                {
                    MessageBox.Show("导入的库无法解析成泛型集合，请确认导入的库是否正确，如果正确又出现此提示请联系闫超。");
                    return;
                }
                else
                {
                    MessageBox.Show("文件读取成功");
                }
            }
            ReplaceContent();
        }
        /// <summary>
        /// 判断是否都不为空，如果是，则进行替换，如果是，则return
        /// </summary>
        private void ReplaceContent()
        {
            if (VoList.Count > 0 && DicType.Count > 0)
            {
                try
                {
                    ReplaceType replaceType = new ReplaceType();
                    replaceType.VoList = VoList;
                    replaceType.DicType = DicType;
                    replaceType.ReplaceListContent();
                    VoList = replaceType.VoList;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                return;
        }
        /// <summary>
        /// 创建VO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateVo(object sender, System.EventArgs e)
        {
            if (VoList.Count > 0 && DicType.Count > 0)
            {
                switch (((Button)sender).Name)
                {
                    case "btnOrg":
                        CreateVo.CreateVoNoINotifyPropertyChanged(txtboxNameSpace.Text, VoList);
                        break;
                    case "btnNotice":
                        CreateVo.CreateVoWithINotifyPropertyChanged(txtboxNameSpace.Text, VoList);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("请确保基础文件和解析文件都已成功读取了。");
            }
        }
        /// <summary>
        /// 创建通知基础类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCs_Click(object sender, System.EventArgs e)
        {
            CreateVo.CreateRaisePropertyChangedCS(txtboxNameSpace.Text);
        }
        /// <summary>
        /// 选择路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPath_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择要生成的路径";
            if(fbd.ShowDialog()==DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath;
                CreateVo.PathVo1 = txtPath.Text;
                CreateVo.PathVo2 = txtPath.Text;
            }
            else
            {
                txtPath.Text = "";
                CreateVo.PathVo1 = @"Dis/VoWithoutNotify";
                CreateVo.PathVo2 = @"Dis/VoWithNotify";
            }
        }
    }
}
