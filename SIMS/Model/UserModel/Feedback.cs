// File:    Feedback.cs
// Author:  Geri
// Created: 18. april 2020 20:34:11
// Purpose: Definition of Class Feedback

using System;
using System.Collections.Generic;
using SIMS.Repository.Abstract;

namespace SIMS.Model.UserModel
{
    public class Feedback : IIdentifiable<long>
    {
        private long _id;
        private User _user;
        private List<Rating> _rating;

        public Feedback(User user,string comment)
        {
            _user = user;
            Comment = comment;
            _rating = new List<Rating>();
        }

        public Feedback(long id, User user, string comment)
        {
            _id = id;
            _user = user;
            Comment = comment;
            _rating = new List<Rating>();
        }

        public Feedback(User user,string comment, List<Rating> rating)
        {
            _user = user;
            Comment = comment;
            if (rating == null)
                _rating = new List<Rating>();
            else
                _rating = rating;


        }

        public Feedback(long id, User user, string comment, List<Rating> rating)
        {
            _id = id;
            _user = user;
            Comment = comment;
            if (rating == null)
                _rating = new List<Rating>();
            else
                _rating = rating;


        }

        public Feedback(long id)
        {
            _id = id;
            Comment = "";
            _rating = new List<Rating>();
        }

   
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Comment { get; set; }

        /// <summary>
        /// Property for collection of Rating
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Rating> Rating
        {
            get
            {
                if (_rating == null)
                    _rating = new List<Rating>();
                return _rating;
            }
            set
            {
                RemoveAllRating();
                if (value != null)
                {
                    foreach (Rating oRating in value)
                        AddRating(oRating);
                }
            }
        }

        /// <summary>
        /// Add a new Rating in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddRating(Rating newRating)
        {
            if (newRating == null)
                return;
            if (_rating == null)
                _rating = new List<Rating>();
            if (!_rating.Contains(newRating))
                _rating.Add(newRating);
        }

        /// <summary>
        /// Remove an existing Rating from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveRating(Rating oldRating)
        {
            if (oldRating == null)
                return;
            if (_rating != null)
                if (_rating.Contains(oldRating))
                    _rating.Remove(oldRating);
        }

        /// <summary>
        /// Remove all instances of Rating from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllRating()
        {
            if (_rating != null)
                _rating.Clear();
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;
    }
}