﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace LB.Controls
{
    public partial class LBToolStripButton : ToolStripButton
    {
        private string _LBPermissionName = "";
        [Description("权限名称")]//
        public string LBPermissionName
        {
            set
            {
                _LBPermissionName = value;
            }
            get
            {
                return _LBPermissionName;
            }
        }

        public LBToolStripButton()
        {
            InitializeComponent();
        }

        

        public LBToolStripButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
