﻿using CBSS.Framework.Contract.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSS.IBS.IBLL
{
    public interface IIBSResource
    {
        APIResponse GetBookSubjects();
    }
}
