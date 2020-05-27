// File:    Message.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Message

using System;

namespace SIMS.Model.UserModel
{
    public class Message : Content
    {
        private bool opened;

        private User recipient;
        private User sender;

        /// <summary>
        /// Property for User
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public User Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }

    }
}