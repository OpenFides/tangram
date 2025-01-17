﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Tangram.Core;
using Tangram.Utility;

namespace Tangram.Gecko
{
    [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisibleAttribute(true)]
    public class GlobalForScript
    {
        private Form form;
        public GlobalForScript(Form form)
        {
            this.form = form;
        }
        public FormForScript open(string url, string formName, string type, string features = "", string parent = "")
        {
            var newForm = ScreenManager.External.Open(url, formName, type, features, parent);
            return new FormForScript(newForm);
        }
        public FormForScript find(string formName = "")
        {
            if (string.IsNullOrEmpty(formName))
            {
                return new FormForScript(this.form);
            }
            return new FormForScript(ScreenManager.External.Find(formName));
        }

        public void exec(string name, string script)
        {
            ScreenManager.External.Exec(name, script);

        }
        public void invoke(string name, string method, params string[] args)
        {
            ScreenManager.External.Invoke(name, method, args);
        }
        public StoreForScript store
        {
            get
            {
                return new StoreForScript();
            }
            set
            {
            }
        }
        public StateForScript state()
        {
            return new StateForScript(this.form);
        }
        public SocketForScript socket(string url, string options)
        {
            return new SocketForScript(this.form.Text, url, SocketOptions.options(options));
        }


    }

}