﻿using System;

namespace TodoApp.Library.Models
{
    public class Task
    {
        string title = string.Empty;
        DateTime startDate = new DateTime();
        string message = string.Empty;
        int deadLine = 0;
        DateTime endDate = new DateTime();
        Guid id = Guid.NewGuid();

        //the title must have 1-128 charachters
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(this.title))
                {
                    throw new ArgumentException("You must enter a title name. The title must have 1-128 charachters!");
                }
                if (this.title.Length > 128)
                {
                    throw new ArgumentOutOfRangeException("The name is too long! The title must have 1-128 charachters!");
                }
                this.title = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate=DateTime.Now;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                if (this.message.Length > 1000)
                {
                    throw new ArgumentOutOfRangeException("Message too long! The message must be less than 1000 charachters!");
                }
                this.message = value;
            }
        }

        //the deadline includes satturday and sunday
        public int DeadLine
        {
            get
            {
                return this.deadLine;
            }
            set
            {
                this.deadLine = value;
            }
        }

        public TimeSpan TimeLeft()
        {
            TimeSpan timeLeft = this.EndDate.Subtract(this.startDate).Duration();

            return timeLeft;
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate = startDate.AddDays(this.deadLine);
            }
        }

        public Guid ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public Task() : this("None","Description...",0)
        {

        }
        public Task(string title, string message, int deadLine)
        {
            this.title = title;
            this.message = message;
            this.deadLine = deadLine;
        }

        public override string ToString()
        {
            string timeLeft = string.Format("{0}days {1}:{2}", TimeLeft().Days.ToString(), TimeLeft().Hours, TimeLeft().Minutes);
            return string.Format("title:{0}\nmessage:{1}\ncreated on:{2}\nterm to:{3}\ntime left:{4}", this.title, this.message, this.startDate, this.endDate, timeLeft);
        }
    }
}
