﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SpaceInvaders.Properties;

namespace SpaceInvaders
{
    class Enemy : PictureBox
    {
        private int imageExplosionCount = 0;

        private Timer timerAnimateExplosion = null;
        

        public Enemy()
        {
            InitializeEnemy();
            InitializeTimerAnimateExlosion();
        }

        private void InitializeEnemy()
        {
            this.BackColor = Color.Red;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Width = 40;
            this.Height = 40;
        }

        public void Explode()
        {
            this.BackColor = Color.Transparent;
            InitializeTimerAnimateExlosion();
        }

        private void InitializeTimerAnimateExlosion()
        {
            timerAnimateExplosion = new Timer();
            timerAnimateExplosion.Interval = 50;
            timerAnimateExplosion.Tick += TimerAnimateExplosion_Tick;
            timerAnimateExplosion.Start();
        }

        private void TimerAnimateExplosion_Tick(object sender, EventArgs e)
        {
            AnimateExplosion();
        }

        private void AnimateExplosion()
        {
            string imageName = "exp" + imageExplosionCount.ToString("000");
            this.Image = (Image)Resources.ResourceManager.GetObject(imageName);
            imageExplosionCount += 1;
            if (imageExplosionCount > 22)
            {
                imageExplosionCount = 0;
                timerAnimateExplosion.Stop();
                timerAnimateExplosion.Dispose();
                this.Top = 0;
                this.Dispose();
            }
        }
    }
}
