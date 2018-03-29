﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAS.Entity.BaseDAModels;

namespace CAS.Entity.GJBEntity
{
    public class SYS_AutoTemplate : DBEntity.SYSAutoTemplate
    {
        [SQLReadOnly]
        public string createusername { get; set; }
        [SQLReadOnly]
        public string filename { get; set; }
        [SQLReadOnly]
        public string fileguid { get; set; }
    }
}