﻿using Genshin_Checker.Core.General.Convert;
using Genshin_Checker.Core.HoYoLab;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.UI.Control.GameRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    public partial class CharacterFrame : UserControl
    {
        List<CharacterInfo> characters = new();
        public delegate void CharacterEventHandler<T>(T args);
        public event CharacterEventHandler<int>? ClickHandler;
        public CharacterFrame(Account account,string groupname, List<CharacterArgment> values,bool IsShowGroupBox=true)
        {
            InitializeComponent();
            values.Reverse();

            var records = account.GameRecords.Data;
            groupBox1.Text = $"{groupname}";
            if (records == null) {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = Localize.UIName_CharacterFrame_FailedToLoad;
                return;
            }
            if(values.Count == 0)
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = Localize.UIName_CharacterFrame_Nothing;
                return;
            }
            groupBox1.Visible = IsShowGroupBox;
            this.SuspendLayout();
            foreach (var argment in values)
            {
                var character = records.avatars.Find(a => a.id == argment.CharacterID);
                var icon = character==null?"":character.image;
                var control = new CharacterInfo(character==null?-1:character.rarity, icon, argment.Value, "", argment.CharacterID) { Dock = DockStyle.Left, Padding=new(2,0,2,0) };
                control.ClickHandler += a => ClickHandler?.Invoke(a);
                if (IsShowGroupBox) groupBox1.Controls.Add(control);
                else Controls.Add(control);
                characters.Add(control);
            }
            ResumeLayout(true);
            Disposed += (s, e) =>
            {
                foreach (var argment in characters)
                {
                    if (IsShowGroupBox) groupBox1.Controls.Remove(argment);
                    else Controls.Remove(argment);
                    argment.Dispose();
                }
            };
        }
        public class CharacterArgment {
            public int CharacterID;
            public string Value;
            public CharacterArgment(int characterID, string value)
            {
                CharacterID = characterID;
                Value = value;
            }
        }

        private void CharacterFrame_ControlRemoved(object sender, ControlEventArgs e)
        {
        }
    }
}
