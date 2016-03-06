using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XsdToVo.Vo
{
    public class AnalysisVo
    {
        private string name;
        private string note;
        private string type;
        private List<AnalysisVo> children;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        /// <summary>
        /// 子集
        /// </summary>
        public List<AnalysisVo> Children
        {
            get
            {
                return children;
            }

            set
            {
                children = value;
            }
        }
    }
}
