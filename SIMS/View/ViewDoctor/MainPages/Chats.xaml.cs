﻿using SIMS.View.ViewDoctor.MessagingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.ViewDoctor.MainPages
{
    /// <summary>
    /// Interaction logic for Chats.xaml
    /// </summary>
    public partial class Chats : Page
    {
        public Chats()
        {/*
            this.Height = height;
            this.Width = width;*/
            InitializeComponent();
        }

        public void addChat(ChatView chat)
        {
            this.MainPanel.Children.Add(chat);
        }
    }
}
