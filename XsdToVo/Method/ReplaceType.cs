using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XsdToVo.Vo;

namespace XsdToVo.Method
{
    public class ReplaceType
    {
        #region 字段和属性
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
        /// 替换 整个list的Type值
        /// </summary>
        /// <returns></returns>
        public List<AnalysisVo> ReplaceListContent()
        {
            foreach (var root in VoList)
            {
                foreach (var node in root.Children)
                {
                    ReplaceContent(node);
                }
            }

            return VoList;
        }
        /// <summary>
        /// 替换Type相应字段
        /// </summary>
        /// <param name="node"></param>
        private void ReplaceContent(AnalysisVo node)
        {
            //正常在基础的字段表中存在
            if (DicType.ContainsKey(node.Type))
            {
                node.Type = DicType[node.Type];
            }//要解析的里面没有type字段，只有name字段   yanc 20160304            
            else if (string.IsNullOrEmpty(node.Type) && DicType.ContainsKey(node.Name))
            {
                node.Type = DicType[node.Name];
            }
            else//List类型的没有存储在基础的字段表中，需要循环遍历本身的List列表
                if(!string.IsNullOrEmpty(node.Type)&&(node.Type.Substring(node.Type.Length - 4, 4).Equals("Grid") || node.Type.Substring(node.Type.Length - 4, 4).Equals("List")))
            {
                foreach (var root in VoList)
                {
                    if (root.Name.Equals(node.Type))
                    {
                        node.Type = root.Children.First().Type;
                    }
                }
            }//要解析的里面没有type字段，只有name字段   yanc 20160304
            else if(string.IsNullOrEmpty(node.Type) && (node.Name.Substring(node.Name.Length - 4, 4).Equals("Grid") || node.Name.Substring(node.Name.Length - 4, 4).Equals("List")))
            {
                foreach (var root in VoList)
                {
                    if (root.Name.Equals(node.Name))
                    {
                        node.Type = root.Children.First().Name;
                    }
                }
            }
            else
            {
                Console.WriteLine("未能转化的内容" + node.Name);
            }
        }
    }
}
