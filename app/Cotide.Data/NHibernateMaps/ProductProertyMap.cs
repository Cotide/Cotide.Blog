﻿//-------------------------------------------------------------------
//版权所有：版权所有(C) 2010，Microsoft(China) Co.,LTD
//系统名称： 
//文件名称：ProductProertyMap.cs
//模块名称：
//模块编号：
//作　　者：lhc
//创建时间：2012/12/19 23:13:33 
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
using Cotide.Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Cotide.Infrastructure.NHibernateMaps
{
    public class ProductProertyMap : IAutoMappingOverride<ProductProerty>
    {
        #region Implementation of IAutoMappingOverride<ProductProerty>

        public void Override(AutoMapping<ProductProerty> mapping)
        {
             
        }

        #endregion
    }
}
