﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingsun.SynchronousStudy.Common
{

    public enum SubjectEnum
    {
        [StringValue("语文")]
        Chinese = 1,
        [StringValue("数学")]
        Math = 2,
        [StringValue("英语")]
        English = 3
    }
}
