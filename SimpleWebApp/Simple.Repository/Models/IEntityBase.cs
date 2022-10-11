﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Repository.Models
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }

    public interface ITenant
    {
        public Guid TenantId { get; set; }
    }

    public interface ICreatedInfo : ICreatedTime, ICreatedUser { }

    public interface ICreatedTime
    {
        public DateTime? CreatedTime { get; set; }
    }

    public interface ICreatedUser
    {
        public Guid? CreatedUserId { get; set; }
    }

    public interface IUpdatedInfo : IUpdatedTime, IUpdatedUser { }

    public interface IUpdatedTime
    {
        public DateTime? UpdatedTime { get; set; }
    }

    public interface IUpdatedUser
    {
        public Guid? UpdatedUserId { get; set; }
    }

    public interface IConcurrency
    {
        public long RowVersion { get; set; }
    }

    public interface IRowVersion
    {
        public byte[] RowVersion { get; set; }
    }
}