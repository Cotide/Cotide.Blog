﻿//-------------------------------------------------------------------
//版权所有：版权所有(C) 2010，Microsoft(China) Co.,LTD
//系统名称： 
//文件名称：ShizongArticleTypeDto.cs
//模块名称：
//模块编号：
//作　　者：lhc
//创建时间：2013/3/22 12:02:57 
//功能说明：
//-----------------------------------------------------------------
//修改记录： 
//修改人：   
//修改时间： 
//修改内容： 
//-----------------------------------------------------------------  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cotide.Domain.Dtos
{
    public class ShizongArticleTypeDto
    { 
        public int Id { get; set; }
         
        public string TypeName { get; set; }
          
        public bool IsShow { get; set; }

        public int? Sort { get; set; }
    }
}
