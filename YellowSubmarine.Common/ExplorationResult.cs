﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YellowSubmarine.Common
{
    public class ExplorationResult
    {
        private StringBuilder builder;
        private readonly string _id = Guid.NewGuid().ToString();
        private readonly string _pk;
        public string id { get { return _id; } }
        public ExplorationResult() 
        {
            this.ResultDateTime = DateTime.UtcNow;
            builder = new StringBuilder();
            Random r = new Random();
            int randomNumber = r.Next(1, 1000);
            _pk = randomNumber.ToString();
        }
        public string PartitionKey { get { return _pk; } }
        public InspectionResultType Type { get; set; }
        public string Acls { get; set; }
        public string Path { get; set; }
        public string RequestId { get; set; }
        public DateTime ResultDateTime { get; }
        public string ETag { get; set; }
        public string ModifiedDateTime { get; set; }
        public int Depth { get; set; }
        public long ContentLength { get; set; }

        public string ToCsv()
        {
            builder.Clear();
            builder.Append(Type);
            builder.Append(',');
            builder.Append(Path);
            builder.Append(',');
            builder.Append(ResultDateTime.ToString());
            builder.Append(',');
            builder.Append(ETag);
            builder.Append(',');
            builder.Append(ModifiedDateTime);
            builder.Append(',');
            builder.Append(Depth);
            return builder.ToString();
        }
    }

    public enum InspectionResultType { Directory, File}
}
